using AutoMapper;
using Contracts.AllRepository.DepartamentsTypeRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.DepartamentTypeDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DepartamentsTypeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DepartamentsTypeController;

[Route("api/deartamenttypecontroller")]

[ApiController]
public class DepartamentTypeController : ControllerBase
{
    private readonly IDepartamentTypeRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public DepartamentTypeController(IDepartamentTypeRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // DepartamentType CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createdepartamenttype")]
    public IActionResult CreateDepartamentType(DepartamentTypeCreatedDTO departamentType1)
    {
        var departamentType = _mapper.Map<DepartamentType>(departamentType1);
        departamentType.status_id = _status.GetStatusId("Active");
        int check = _repository.CreateDepartamentType(departamentType);

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
    [HttpGet("getalldepartamenttype")]
    public IActionResult GetAllDepartamentType(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<DepartamentType> departamentTypes1 = _repository.AllDepartamentType(queryNum, pageNum);
        var departamentTypes = _mapper.Map<IEnumerable<DepartamentTypeReadedDTO>>(departamentTypes1);
        if (departamentTypes == null) { }
        return Ok(departamentTypes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyiddepartamenttype/{id}")]
    public IActionResult GetByIdDepartamentType(int id)
    {

        DepartamentType departamentType1 = _repository.GetDepartamentTypeById(id);
        if (departamentType1 == null)
        {

        }
        var departamentType = _mapper.Map<DepartamentTypeReadedDTO>(departamentType1);
        if (departamentType == null) { }

        return Ok(departamentType);
    }

    [HttpGet("sitegetalldepartamenttype")]
    public IActionResult GetAllDepartamentTypesite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<DepartamentType> departamentTypes1 = _repository.AllDepartamentTypeSite(queryNum, pageNum);
        var departamentTypes = _mapper.Map<IEnumerable<DepartamentTypeReadedSiteDTO>>(departamentTypes1);
        if (departamentTypes == null) { }
        return Ok(departamentTypes);
    }

    [HttpGet("sitegetbyiddepartamenttype/{id}")]
    public IActionResult GetByIdDepartamentTypesite(int id)
    {

        DepartamentType departamentType1 = _repository.GetDepartamentTypeByIdSite(id);
        if (departamentType1 == null)
        {

        }
        var departamentType = _mapper.Map<DepartamentTypeReadedSiteDTO>(departamentType1);
        if (departamentType == null) { }

        return Ok(departamentType);
    }


    [HttpGet("sitegetbytitledepartamenttype/{type}")]
    public IActionResult GetByTitleDepartamentTypeSite(string type)
    {
        type = type.ToLower();
        var departamentType1 = _repository.AllDepartamentTypeSite(0, 0).FirstOrDefault(x => x.type.ToLower() == type);

        var departamentType = _mapper.Map<DepartamentTypeReadedSiteDTO>(departamentType1);
        if (departamentType == null) { }

        return Ok(departamentType);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletedepartamenttype/{id}")]
    public IActionResult DeleteDepartamentType(int id)
    {
        bool check = _repository.DeleteDepartamentType(id);
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
    [HttpPut("updatedepartamenttype/{id}")]
    public IActionResult UpdateDepartamentType(DepartamentTypeUpdatedDTO departamentType1, int id)
    {

        try
        {
            if (departamentType1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<DepartamentType>(departamentType1);

            bool updatedcheck = _repository.UpdateDepartamentType(id, dbupdated);
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







    //DepartamentTypeTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createdepartamenttypetranslation")]
    public IActionResult CreateDepartamentTypeTranslation(DepartamentTypeTranslationCreatedDTO departamentTypetranslation1)
    {
        var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslation>(departamentTypetranslation1);
        departamentTypetranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)departamentTypetranslation.language_id);
        int check = _repository.CreateDepartamentTypeTranslation(departamentTypetranslation);

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
    [HttpGet("getalldepartamenttypetranslation")]
    public IActionResult GetAllDepartamentTypeTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<DepartamentTypeTranslation> departamentTypetranslations1 = _repository.AllDepartamentTypeTranslation(queryNum, pageNum, language_code);
        var departamentTypetranslations = _mapper.Map<IEnumerable<DepartamentTypeTranslationReadedDTO>>(departamentTypetranslations1);
        if (departamentTypetranslations == null) { }

        return Ok(departamentTypetranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuziddepartamenttypetranslation/{uz_id}")]
    public IActionResult GetByIdDepartamentTypeTranslation(int uz_id, string language_code)
    {

        DepartamentTypeTranslation departamentTypetranslation1 = _repository.GetDepartamentTypeTranslationById(uz_id, language_code);
        var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslationReadedDTO>(departamentTypetranslation1);
        if (departamentTypetranslation == null) { }
        return Ok(departamentTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyiddepartamenttypetranslation/{id}")]
    public IActionResult GetByIdDepartamentTypeTranslation(int id)
    {

        DepartamentTypeTranslation departamentTypetranslation1 = _repository.GetDepartamentTypeTranslationById(id);
        var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslationReadedDTO>(departamentTypetranslation1);
        if (departamentTypetranslation == null) { }
        return Ok(departamentTypetranslation);
    }

    [HttpGet("sitegetalldepartamenttypetranslation")]
    public IActionResult GetAllDepartamentTypeTranslationsite(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<DepartamentTypeTranslation> departamentTypetranslations1 = _repository.AllDepartamentTypeTranslationSite(queryNum, pageNum, language_code);
        var departamentTypetranslations = _mapper.Map<IEnumerable<DepartamentTypeTranslationReadedSiteDTO>>(departamentTypetranslations1);
        if (departamentTypetranslations == null) { }

        return Ok(departamentTypetranslations);
    }

    [HttpGet("sitegetbyuziddepartamenttypetranslation/{uz_id}")]
    public IActionResult GetByIdDepartamentTypeTranslationsite(int uz_id, string language_code)
    {

        DepartamentTypeTranslation departamentTypetranslation1 = _repository.GetDepartamentTypeTranslationByIdSite(uz_id, language_code);
        var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslationReadedSiteDTO>(departamentTypetranslation1);
        if (departamentTypetranslation == null) { }
        return Ok(departamentTypetranslation);
    }

    [HttpGet("sitegetbyiddepartamenttypetranslation/{id}")]
    public IActionResult GetByIdDepartamentTypeTranslationsite(int id)
    {

        DepartamentTypeTranslation departamentTypetranslation1 = _repository.GetDepartamentTypeTranslationByIdSite(id);
        var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslationReadedSiteDTO>(departamentTypetranslation1);
        if (departamentTypetranslation == null) { }
        return Ok(departamentTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletedepartamenttypetranslation/{id}")]
    public IActionResult DeleteDepartamentTypeTranslation(int id)
    {
        bool check = _repository.DeleteDepartamentTypeTranslation(id);
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
    [HttpPut("updatedepartamenttypetranslation/{id}")]
    public IActionResult UpdateDepartamentTypeTranslation(DepartamentTypeTranslationUpdatedDTO departamentTypetranslation1, int id)
    {

        try
        {
            if (departamentTypetranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<DepartamentTypeTranslation>(departamentTypetranslation1);

            bool updatedcheck = _repository.UpdateDepartamentTypeTranslation(id, dbupdated);
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
