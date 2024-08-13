using AutoMapper;
using Contracts.AllRepository.EmployeesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.EmployeeTypesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.EmployeeTypesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.EmployeeTypeControllers;

[Route("api/employeetype")]
[ApiController]
public class EmployeeTypeController : ControllerBase
{
    private readonly IEmployeeTypeRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public EmployeeTypeController(IEmployeeTypeRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // EmployeeType CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createemployeetype")]
    public IActionResult CreateEmployeeType(EmployeeTypeCreatedDTO EmployeeType1)
    {
        var EmployeeType = _mapper.Map<EmployeeType>(EmployeeType1);
        EmployeeType.status_id = _status.GetStatusId("Active");
        int id = _repository.CreateEmployeeType(EmployeeType);

        if (id == 0)
        {
            return BadRequest();
        }

        CreatedItemId createdItemId = new CreatedItemId()
        {
            id = id,
            StatusCode = 200
        };

        return Ok(createdItemId);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallemployeetype")]
    public IActionResult GetAllEmployeeType(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<EmployeeType> EmployeeTypes1 = _repository.AllEmployeeType(queryNum, pageNum);
        var EmployeeTypes = _mapper.Map<IEnumerable<EmployeeTypeReadedDTO>>(EmployeeTypes1);
        if (EmployeeTypes == null) { }

        return Ok(EmployeeTypes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidemployeetype/{id}")]
    public IActionResult GetByIdEmployeeType(int id)
    {

        EmployeeType EmployeeType1 = _repository.GetEmployeeTypeById(id);
        if (EmployeeType1 == null)
        {

        }
        var EmployeeType = _mapper.Map<EmployeeTypeReadedDTO>(EmployeeType1);
        if (EmployeeType == null) { }
        return Ok(EmployeeType);
    }

    [HttpGet("sitegetallemployeetype")]
    public IActionResult GetAllEmployeeTypesite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<EmployeeType> EmployeeTypes1 = _repository.AllEmployeeTypeSite(queryNum, pageNum);
        var EmployeeTypes = _mapper.Map<IEnumerable<EmployeeTypeReadedSiteDTO>>(EmployeeTypes1);
        if (EmployeeTypes == null) { }

        return Ok(EmployeeTypes);
    }

    [HttpGet("sitegetemployeetypetitle/{title}")]
    public IActionResult GetEmployeeTypesiteTitle(string title)
    {
        EmployeeType EmployeeTypes1 = _repository.AllEmployeeTypeSite(0, 0).FirstOrDefault(x=>x.title==title);
        var EmployeeTypes = _mapper.Map<EmployeeTypeReadedSiteDTO>(EmployeeTypes1);
        return Ok(EmployeeTypes);
    }

    [HttpGet("sitegetbyidemployeetype/{id}")]
    public IActionResult GetByIdEmployeeTypesite(int id)
    {

        EmployeeType EmployeeType1 = _repository.GetEmployeeTypeByIdSite(id);
        if (EmployeeType1 == null)
        {

        }
        var EmployeeType = _mapper.Map<EmployeeTypeReadedSiteDTO>(EmployeeType1);
        if (EmployeeType == null) { }
        return Ok(EmployeeType);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteemployeetype/{id}")]
    public IActionResult DeleteEmployeeType(int id)
    {
        bool check = _repository.DeleteEmployeeType(id);
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
    [HttpPut("updateemployeetype/{id}")]
    public IActionResult UpdateEmployeeType(EmployeeTypeUpdatedDTO EmployeeType1, int id)
    {
        try
        {
            if (EmployeeType1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<EmployeeType>(EmployeeType1);

            bool updatedcheck = _repository.UpdateEmployeeType(id, dbupdated);
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







    //EmployeeTypeTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createemployeetypetranslation")]
    public IActionResult CreateEmployeeTypeTranslation(EmployeeTypeTranslationCreatedDTO EmployeeTypetranslation1)
    {
        var EmployeeTypetranslation = _mapper.Map<EmployeeTypeTranslation>(EmployeeTypetranslation1);
        EmployeeTypetranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)EmployeeTypetranslation.language_id);
        int id = _repository.CreateEmployeeTypeTranslation(EmployeeTypetranslation);
        if (id == 0)
        {
            return BadRequest();
        }

        if (id == 0)
        {
            return BadRequest();
        }
        CreatedItemId createdItemId = new CreatedItemId()
        {
            id = id,
            StatusCode = 200
        };

        return Ok(createdItemId);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallemployeetypetranslation")]
    public IActionResult GetAllEmployeeTypeTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<EmployeeTypeTranslation> EmployeeTypetranslations1 = _repository.AllEmployeeTypeTranslation(queryNum, pageNum, language_code);
        var EmployeeTypetranslations = _mapper.Map<IEnumerable<EmployeeTypeTranslationReadedDTO>>(EmployeeTypetranslations1);
        if (EmployeeTypetranslations == null) { }

        return Ok(EmployeeTypetranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidemployeetypetranslation/{uz_id}")]
    public IActionResult GetByIdEmployeeTypeTranslation(int uz_id, string language_code)
    {

        EmployeeTypeTranslation EmployeeTypetranslation1 = _repository.GetEmployeeTypeTranslationById(uz_id, language_code);
        var EmployeeTypetranslation = _mapper.Map<EmployeeTypeTranslationReadedDTO>(EmployeeTypetranslation1);
        if (EmployeeTypetranslation == null) { }

        return Ok(EmployeeTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidemployeetypetranslation/{id}")]
    public IActionResult GetByIdEmployeeTypeTranslation(int id)
    {

        EmployeeTypeTranslation EmployeeTypetranslation1 = _repository.GetEmployeeTypeTranslationById(id);
        var EmployeeTypetranslation = _mapper.Map<EmployeeTypeTranslationReadedDTO>(EmployeeTypetranslation1);
        if (EmployeeTypetranslation == null) { }

        return Ok(EmployeeTypetranslation);
    }

    [HttpGet("sitegetallemployeetypetranslation")]
    public IActionResult GetAllEmployeeTypeTranslationsite(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<EmployeeTypeTranslation> EmployeeTypetranslations1 = _repository.AllEmployeeTypeTranslationSite(queryNum, pageNum, language_code);
        var EmployeeTypetranslations = _mapper.Map<IEnumerable<EmployeeTypeTranslationReadedSiteDTO>>(EmployeeTypetranslations1);
        if (EmployeeTypetranslations == null) { }

        return Ok(EmployeeTypetranslations);
    }

    [HttpGet("sitegetbyuzidemployeetypetranslation/{uz_id}")]
    public IActionResult GetByIdEmployeeTypeTranslationsite(int uz_id, string language_code)
    {

        EmployeeTypeTranslation EmployeeTypetranslation1 = _repository.GetEmployeeTypeTranslationByIdSite(uz_id, language_code);
        var EmployeeTypetranslation = _mapper.Map<EmployeeTypeTranslationReadedSiteDTO>(EmployeeTypetranslation1);
        if (EmployeeTypetranslation == null) { }

        return Ok(EmployeeTypetranslation);
    }

    [HttpGet("sitegetbyidemployeetypetranslation/{id}")]
    public IActionResult GetByIdEmployeeTypeTranslationsite(int id)
    {

        EmployeeTypeTranslation EmployeeTypetranslation1 = _repository.GetEmployeeTypeTranslationByIdSite(id);
        var EmployeeTypetranslation = _mapper.Map<EmployeeTypeTranslationReadedSiteDTO>(EmployeeTypetranslation1);
        if (EmployeeTypetranslation == null) { }

        return Ok(EmployeeTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteemployeetypetranslation/{id}")]
    public IActionResult DeleteEmployeeTypeTranslation(int id)
    {
        bool check = _repository.DeleteEmployeeTypeTranslation(id);
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
    [HttpPut("updateemployeetypetranslation/{id}")]
    public IActionResult UpdateEmployeeTypeTranslation(EmployeeTypeTranslationUpdatedDTO EmployeeTypetranslation1, int id)
    {
        try
        {
            if (EmployeeTypetranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<EmployeeTypeTranslation>(EmployeeTypetranslation1);

            bool updatedcheck = _repository.UpdateEmployeeTypeTranslation(id, dbupdated);
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
