using AutoMapper;
using Contracts.AllRepository.UsersRepository;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Createuser(User user)
        {

            bool check = _repository.CreateUser(user);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", user);
        }

        [HttpGet("getalluser")]
        public IActionResult GetAlluser()
        {

            IEnumerable<User> useres = _repository.AllUser();

            return Ok(useres);
        }

        [HttpGet("getbyiduser/{id}")]
        public IActionResult GetByIduser(int id)
        {

            User user = _repository.GetUserById(id);

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
        public IActionResult Updateuser(User user, int id)
        {
            bool check = _repository.UpdateUser(id, user);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }







        

    }
}
