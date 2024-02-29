using AutoMapper;
using Contracts.AllRepository.UserTypesRepository;
using Entities.DTO.UserTypeDTOS;
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
        public IActionResult CreateUserType(UserTypeCreatedDTO userType1)
        {
            var userType = _mapper.Map<UserType>(userType1);
            bool check = _repository.CreateUserType(userType);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallusertype")]
        public IActionResult GetAllUserType(int queryNum, int pageNum)
        {
            queryNum=Math.Abs(queryNum);
            pageNum=Math.Abs(pageNum);
            IEnumerable<UserType> userTypes1 = _repository.AllUserType(queryNum, pageNum);
            var userTypes = _mapper.Map<IEnumerable<UserTypeReadedDTO>>(userTypes1);
            if (userTypes == null|| userTypes.Count()==0) { return NotFound(); }
            return Ok(userTypes);
        }

        [HttpGet("getbyidusertype/{id}")]
        public IActionResult GetByIdUserType(int id)
        {

            UserType userType1 = _repository.GetUserTypeById(id);
            var userType = _mapper.Map<UserTypeReadedDTO>(userType1);
            if (userType == null) { return NotFound(); }
            return Ok(userType);
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
        public IActionResult UpdateUserType(UserTypeUpdatedDTO userType1, int id)
        {
            try
            {
                var userType = _repository.GetUserTypeById(id);
                if (userType == null)
                {
                    return NotFound();
                }
                _mapper.Map(userType1, userType);
                bool check = _repository.UpdateUserType();
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







        //UserTypeTranslation CRUD
        [HttpPost("createusertypetranslation")]
        public IActionResult CreateUserTypeTranslation(UserTypeTranslationCreatedDTO userTypetranslation1)
        {
            var userTypetranslation = _mapper.Map<UserTypeTranslation>(userTypetranslation1);
            bool check = _repository.CreateUserTypeTranslation(userTypetranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallusertypetranslation")]
        public IActionResult GetAllUserTypeTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<UserTypeTranslation> userTypetranslations1 = _repository.AllUserTypeTranslation(queryNum,pageNum, language_code);
            var userTypetranslations = _mapper.Map<IEnumerable<UserTypeTranslationReadedDTO>>(userTypetranslations1);
            if (userTypetranslations == null|| userTypetranslations.Count()==0) { return NotFound(); }
            return Ok(userTypetranslations);
        }

        [HttpGet("getbyidusertypetranslation/{id}")]
        public IActionResult GetByIdUserTypeTranslation(int id)
        {

            UserTypeTranslation userTypetranslation1 = _repository.GetUserTypeTranslationById(id);
            var userTypetranslation = _mapper.Map<UserTypeTranslationReadedDTO>(userTypetranslation1);
            if (userTypetranslation == null) { return NotFound(); }
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



        [HttpPut("updateusertypetranslation/{id}")]
        public IActionResult UpdateUserTypeTranslation(UserTypeTranslation userTypetranslation1, int id)
        {
            try
            {
                var userTypetranslation = _repository.GetUserTypeTranslationById(id);
                if (userTypetranslation == null)
                {
                    return NotFound();
                }
                _mapper.Map(userTypetranslation1, userTypetranslation);
                bool check = _repository.UpdateUserTypeTranslation();
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
