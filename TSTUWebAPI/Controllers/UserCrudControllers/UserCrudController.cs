using AutoMapper;
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
    [Authorize]
    public class UserCrudController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserCrudController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // user CRUD

        [Authorize(Roles="Admin")]       [HttpPost("createuser")]
        public IActionResult Createuser(UserCrudCreatedDTO user1)
        {
            string passwordhash = PasswordManager.EncryptPassword((user1.login + user1.password).ToString());
            var user = _mapper.Map<User>(user1);
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

        [Authorize(Roles="Admin")]       [HttpGet("getalluser")]
        public IActionResult GetAlluser(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<User> users1 = _repository.AllUser(queryNum, pageNum);
            var users = _mapper.Map<IEnumerable<UserCrudReadedDTO>>(users1);
            if (users == null || users.Count() == 0) { return NotFound(); }
            return Ok(users);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyiduser/{id}")]
        public IActionResult GetByIduser(int id)
        {

            User user1 = _repository.GetUserById(id);
            var user = _mapper.Map<UserCrudReadedDTO>(user1);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteuser/{id}")]
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



        [Authorize(Roles="Admin")]       [HttpPut("updateuser/{id}")]
        public IActionResult Updateuser(UserCrudUpdatedDTO user1, int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null || user1 == null)
            {
                return NotFound();
            }
            user1.password = PasswordManager.EncryptPassword((user1.login + user1.password).ToString());
            user.updated_at = DateTime.UtcNow;
            _mapper.Map(user1, user);
            bool check = _repository.SaveChanges();
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }









    }
}
