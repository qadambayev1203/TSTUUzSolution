using AutoMapper;
using Contracts.AllRepository.UserTypesRepository;
using Entities.DTO.UserTypeDTOS;
using Entities.Model;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.UserTypeControllers
{
    [Route("api/usertype")]
    [ApiController]
    [Authorize]
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

        [Authorize(Roles="Admin")]       [Authorize(Roles="Admin")]       [HttpPost("createusertype")]
        public IActionResult CreateUserType(UserTypeCreatedDTO userType1)
        {
            var userType = _mapper.Map<UserType>(userType1);
            int check = _repository.CreateUserType(userType);

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

        [Authorize(Roles="Admin")]       [HttpGet("getallusertype")]
        public IActionResult GetAllUserType(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<UserType> userTypes1 = _repository.AllUserType(queryNum, pageNum);
            var userTypes = _mapper.Map<IEnumerable<UserTypeReadedDTO>>(userTypes1);
            if (userTypes == null || userTypes.Count() == 0) { return NotFound(); }
            return Ok(userTypes);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidusertype/{id}")]
        public IActionResult GetByIdUserType(int id)
        {

            UserType userType1 = _repository.GetUserTypeById(id);
            var userType = _mapper.Map<UserTypeReadedDTO>(userType1);
            if (userType == null) { return NotFound(); }
            return Ok(userType);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteusertype/{id}")]
        public IActionResult DeleteUserType(int id)
        {
            bool check = _repository.DeleteUserType(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updateusertype/{id}")]
        public IActionResult UpdateUserType(UserTypeUpdatedDTO userType1, int id)
        {
            try
            {
                var userType = _repository.GetUserTypeById(id);
                if (userType == null || userType1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(userType1, userType);
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







        //UserTypeTranslation CRUD
        [Authorize(Roles="Admin")]       [HttpPost("createusertypetranslation")]
        public IActionResult CreateUserTypeTranslation(UserTypeTranslationCreatedDTO userTypetranslation1)
        {
            var userTypetranslation = _mapper.Map<UserTypeTranslation>(userTypetranslation1);
            int check = _repository.CreateUserTypeTranslation(userTypetranslation);

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

        [Authorize(Roles="Admin")]       [HttpGet("getallusertypetranslation")]
        public IActionResult GetAllUserTypeTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<UserTypeTranslation> userTypetranslations1 = _repository.AllUserTypeTranslation(queryNum, pageNum, language_code);
            var userTypetranslations = _mapper.Map<IEnumerable<UserTypeTranslationReadedDTO>>(userTypetranslations1);
            if (userTypetranslations == null || userTypetranslations.Count() == 0) { return NotFound(); }
            return Ok(userTypetranslations);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidusertypetranslation/{id}")]
        public IActionResult GetByIdUserTypeTranslation(int id)
        {

            UserTypeTranslation userTypetranslation1 = _repository.GetUserTypeTranslationById(id);
            var userTypetranslation = _mapper.Map<UserTypeTranslationReadedDTO>(userTypetranslation1);
            if (userTypetranslation == null) { return NotFound(); }
            return Ok(userTypetranslation);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteusertypetranslation/{id}")]
        public IActionResult DeleteUserTypeTranslation(int id)
        {
            bool check = _repository.DeleteUserTypeTranslation(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updateusertypetranslation/{id}")]
        public IActionResult UpdateUserTypeTranslation(UserTypeTranslation userTypetranslation1, int id)
        {
            try
            {
                var userTypetranslation = _repository.GetUserTypeTranslationById(id);
                if (userTypetranslation == null || userTypetranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(userTypetranslation1, userTypetranslation);
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
