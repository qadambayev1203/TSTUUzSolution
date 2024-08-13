using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Contracts.AllRepository.UserTypesRepository;
using Entities.DTO.UserTypeDTOS;
using Entities.Model;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.UserTypeControllers;

[Route("api/usertype")]
[ApiController]
public class UserTypeController : ControllerBase
{
    private readonly IUserTypeRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public UserTypeController(IUserTypeRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // UserType CRUD


    [Authorize(Roles = "Admin")]
    [HttpPost("createusertype")]
    public IActionResult CreateUserType(UserTypeCreatedDTO userType1)
    {
        var userType = _mapper.Map<UserType>(userType1);
        userType.status_id = _status.GetStatusId("Active");
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

    [Authorize(Roles = "Admin")]
    [HttpGet("getallusertype")]
    public IActionResult GetAllUserType(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<UserType> userTypes1 = _repository.AllUserType(queryNum, pageNum);
        var userTypes = _mapper.Map<IEnumerable<UserTypeReadedDTO>>(userTypes1);
        if (userTypes == null) { }
        return Ok(userTypes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidusertype/{id}")]
    public IActionResult GetByIdUserType(int id)
    {

        UserType userType1 = _repository.GetUserTypeById(id);
        var userType = _mapper.Map<UserTypeReadedDTO>(userType1);
        return Ok(userType);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("selectgetallusertype")]
    public IActionResult GetAllUserTypeselect(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<UserType> userTypes1 = _repository.AllUserTypeSelect(queryNum, pageNum);
        var userTypes = _mapper.Map<IEnumerable<UserTypeReadedSiteDTO>>(userTypes1);
        return Ok(userTypes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("selectgetbyidusertype/{id}")]
    public IActionResult GetByIdUserTypeselect(int id)
    {

        UserType userType1 = _repository.GetUserTypeByIdSelect(id);
        var userType = _mapper.Map<UserTypeReadedSiteDTO>(userType1);
        return Ok(userType);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteusertype/{id}")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("updateusertype/{id}")]
    public IActionResult UpdateUserType(UserTypeUpdatedDTO userType1, int id)
    {
        try
        {
            if (userType1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<UserType>(userType1);

            bool updatedcheck = _repository.UpdateUserType(id, dbupdated);
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







    //UserTypeTranslation CRUD
    [Authorize(Roles = "Admin")]
    [HttpPost("createusertypetranslation")]
    public IActionResult CreateUserTypeTranslation(UserTypeTranslationCreatedDTO userTypetranslation1)
    {
        var userTypetranslation = _mapper.Map<UserTypeTranslation>(userTypetranslation1);
        userTypetranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)userTypetranslation.language_id);
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

    [Authorize(Roles = "Admin")]
    [HttpGet("getallusertypetranslation")]
    public IActionResult GetAllUserTypeTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<UserTypeTranslation> userTypetranslations1 = _repository.AllUserTypeTranslation(queryNum, pageNum, language_code);
        var userTypetranslations = _mapper.Map<IEnumerable<UserTypeTranslationReadedDTO>>(userTypetranslations1);
        return Ok(userTypetranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidusertypetranslation/{uz_id}")]
    public IActionResult GetByIdUserTypeTranslation(int uz_id, string language_code)
    {

        UserTypeTranslation userTypetranslation1 = _repository.GetUserTypeTranslationById(uz_id, language_code);
        var userTypetranslation = _mapper.Map<UserTypeTranslationReadedDTO>(userTypetranslation1);
        return Ok(userTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidusertypetranslation/{id}")]
    public IActionResult GetByIdUserTypeTranslation(int id)
    {

        UserTypeTranslation userTypetranslation1 = _repository.GetUserTypeTranslationById(id);
        var userTypetranslation = _mapper.Map<UserTypeTranslationReadedDTO>(userTypetranslation1);
        return Ok(userTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("selectgetallusertypetranslation")]
    public IActionResult GetAllUserTypeTranslationselect(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<UserTypeTranslation> userTypetranslations1 = _repository.AllUserTypeTranslationSelect(queryNum, pageNum, language_code);
        var userTypetranslations = _mapper.Map<IEnumerable<UserTypeTranslationReadedSiteDTO>>(userTypetranslations1);
        return Ok(userTypetranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("selectgetbyuzidusertypetranslation/{uz_id}")]
    public IActionResult GetByIdUserTypeTranslationselect(int uz_id, string language_code)
    {

        UserTypeTranslation userTypetranslation1 = _repository.GetUserTypeTranslationByIdSite(uz_id, language_code);
        var userTypetranslation = _mapper.Map<UserTypeTranslationReadedSiteDTO>(userTypetranslation1);
        return Ok(userTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("selectgetbyidusertypetranslation/{id}")]
    public IActionResult GetByIdUserTypeTranslationselect(int id)
    {

        UserTypeTranslation userTypetranslation1 = _repository.GetUserTypeTranslationByIdSelect(id);
        var userTypetranslation = _mapper.Map<UserTypeTranslationReadedSiteDTO>(userTypetranslation1);
        return Ok(userTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteusertypetranslation/{id}")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("updateusertypetranslation/{id}")]
    public IActionResult UpdateUserTypeTranslation(UserTypeTranslationUpdatedDTO userTypetranslation1, int id)
    {
        try
        {
            if (userTypetranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<UserTypeTranslation>(userTypetranslation1);

            bool updatedcheck = _repository.UpdateUserTypeTranslation(id, dbupdated);
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
