using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Contracts.AllRepository.UsersRepository;
using Entities.DTO.UserCrudDTOS;
using Entities.Model;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TSTUWebAPI.Controllers.UserCrudControllers
{
    [Route("api/usercrud")]
    [ApiController]
    public class UserCrudController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public UserCrudController(IUserRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // user CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createuser")]
        public IActionResult Createuser(UserCrudCreatedDTO user1)
        {
            string passwordhash = PasswordManager.EncryptPassword((user1.login + user1.password).ToString());
            var user = _mapper.Map<User>(user1);
            user.status_id = _status.GetStatusId("Active");
            user.password = passwordhash;
            int check = _repository.CreateUser(user);

            if (check == 0)
            {
                return BadRequest();
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalluser")]
        public IActionResult GetAlluser(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<User> users1 = _repository.AllUser(queryNum, pageNum);
            var users = _mapper.Map<IEnumerable<UserCrudReadedDTO>>(users1);
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiduser/{id}")]
        public IActionResult GetByIduser(int id)
        {

            User user1 = _repository.GetUserById(id);
            var user = _mapper.Map<UserCrudReadedDTO>(user1);
            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteuser/{id}")]
        public IActionResult Deleteuser(int id)
        {
            bool check = _repository.DeleteUser(id);
            if (!check)
            {
                return BadRequest();
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updateuser/{id}")]
        public IActionResult Updateuser(UserCrudUpdatedDTO user1, int id)
        {
            try
            {
                if (user1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<User>(user1);
                dbupdated.password = PasswordManager.EncryptPassword((user1.login + user1.password).ToString());
                
                bool updatedcheck = _repository.UpdateUser(id, dbupdated);
                if (!updatedcheck)
                {
                    return BadRequest();
                }
                bool check = _repository.SaveChanges();
                if (!check)
                {
                    return BadRequest();
                }
                return Ok("Updated");
            }
            catch
            {
                return BadRequest();
            }

        }









    }
}
