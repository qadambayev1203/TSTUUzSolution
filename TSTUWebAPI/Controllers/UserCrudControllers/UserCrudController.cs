using AutoMapper;
using Contracts.AllRepository.UsersRepository;
using Entities.DTO.GenderDTOS;
using Entities.Model;
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
        public UserCrudController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // user CRUD

        [HttpPost("createuser")]
        public IActionResult Createuser(UserCrudCreatedDTO user1)
        {
            string passwordhash = (user1.login + user1.password).GetHashCode().ToString();
            var user = _mapper.Map<User>(user1);
            user.password = passwordhash;
            bool check = _repository.CreateUser(user);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getalluser")]
        public IActionResult GetAlluser()
        {

            IEnumerable<User> users1= _repository.AllUser();
            var users = _mapper.Map<IEnumerable<UserCrudReadedDTO>>(users1);
            return Ok(users);
        }

        [HttpGet("getbyiduser/{id}")]
        public IActionResult GetByIduser(int id)
        {

            User user1 = _repository.GetUserById(id);
            var user = _mapper.Map<UserCrudReadedDTO>(user1);
            return Ok(user);
        }


        [HttpDelete("deleteuser/{id}")]
        public IActionResult Deleteuser(int id)
        {
            bool check = _repository.DeleteUser(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updateuser/{id}")]
        public IActionResult Updateuser(UserCrudUpdatedDTO user1, int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            user1.password= ((user1.login + user1.password).GetHashCode()).ToString();
            _mapper.Map(user1, user);
            bool check = _repository.UpdateUser();
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }







        

    }
}
