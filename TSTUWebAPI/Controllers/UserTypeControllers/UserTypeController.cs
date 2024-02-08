using AutoMapper;
using Contracts.AllRepository.UserTypesRepository;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.UserTypeControllers
{
    [Route("api/usertype")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeRepository _repository;
        private readonly IMapper _mapper;
        public UserTypeController(IUserTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // UserType CRUD

        [HttpPost("createusertype")]
        public IActionResult CreateUserType(UserType userType)
        {

            bool check = _repository.CreateUserType(userType);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", userType);
        }

        [HttpGet("getallusertype")]
        public IActionResult GetAllUserType()
        {

            IEnumerable<UserType> userTypees = _repository.AllUserType();

            return Ok(userTypees);
        }

        [HttpGet("getbyidusertype/{id}")]
        public IActionResult GetByIdUserType(int id)
        {

            UserType tserType = _repository.GetUserTypeById(id);

            return Ok(tserType);
        }


        [HttpDelete("deleteusertype/{id}")]
        public IActionResult DeleteUserType(int id)
        {
            bool check = _repository.DeleteUserType(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updateusertype/{id}")]
        public IActionResult UpdateUserType(UserType userType, int id)
        {
            bool check = _repository.UpdateUserType(id, userType);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }







        //UserTypeTranslation CRUD
        [HttpPost("createuseruypetranslation")]
        public IActionResult CreateUserTypeTranslation(UserTypeTranslation userTypetranslation)
        {

            bool check = _repository.CreateUserTypeTranslation(userTypetranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", userTypetranslation);
        }

        [HttpGet("getalluseruypetranslation")]
        public IActionResult GetAllUserTypeTranslation()
        {

            IEnumerable<UserTypeTranslation> userTypetranslationes = _repository.AllUserTypeTranslation();

            return Ok(userTypetranslationes);
        }

        [HttpGet("getbyiduseruypetranslation/{id}")]
        public IActionResult GetByIdUserTypeTranslation(int id)
        {

            UserTypeTranslation userTypetranslation = _repository.GetUserTypeTranslationById(id);

            return Ok(userTypetranslation);
        }


        [HttpDelete("deleteusertypetranslation/{id}")]
        public IActionResult DeleteUserTypeTranslation(int id)
        {
            bool check = _repository.DeleteUserTypeTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updateuseruypetranslation/{id}")]
        public IActionResult UpdateUserTypeTranslation(UserTypeTranslation userTypetranslation, int id)
        {
            bool check = _repository.UpdateUserTypeTranslation(id, userTypetranslation);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }

    }
}
