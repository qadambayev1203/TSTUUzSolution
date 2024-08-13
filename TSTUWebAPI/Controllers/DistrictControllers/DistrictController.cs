using AutoMapper;
using Contracts.AllRepository.DistrictsRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.DistrictsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DistrictsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DistrictControllers;

[Route("api/district")]
[ApiController]
public class DistrictController : ControllerBase
{
    private readonly IDistrictRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public DistrictController(IDistrictRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // District CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createdistrict")]
    public IActionResult CreateDistrict(DistrictCreatedDTO District1)
    {
        var District = _mapper.Map<District>(District1);
        District.status_id = _status.GetStatusId("Active");
        int id = _repository.CreateDistrict(District);

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
    [HttpGet("getalldistrict")]
    public IActionResult GetAllDistrict(int? territorie_id)
    {

        IEnumerable<District> Districts1 = _repository.AllDistrict(territorie_id);
        var Districts = _mapper.Map<IEnumerable<DistrictReadedDTO>>(Districts1);
        if (Districts == null) { }

        return Ok(Districts);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyiddistrict/{id}")]
    public IActionResult GetByIdDistrict(int id)
    {

        District District1 = _repository.GetDistrictById(id);
        if (District1 == null)
        {

        }
        var District = _mapper.Map<DistrictReadedIdDTO>(District1);
        if (District == null) { }
        return Ok(District);
    }

    [HttpGet("sitegetalldistrict")]
    public IActionResult GetAllDistrictsite(int territorie_id)
    {
        IEnumerable<District> Districts1 = _repository.AllDistrictSite(territorie_id);
        var Districts = _mapper.Map<IEnumerable<DistrictReadedSiteDTO>>(Districts1);
        if (Districts == null) { }

        return Ok(Districts);
    }

    [HttpGet("sitegetbyiddistrict/{id}")]
    public IActionResult GetByIdDistrictsite(int id)
    {

        District District1 = _repository.GetDistrictByIdSite(id);
        if (District1 == null)
        {

        }
        var District = _mapper.Map<DistrictReadedSiteDTO>(District1);
        if (District == null) { }
        return Ok(District);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteDistrict/{id}")]
    public IActionResult DeleteDistrict(int id)
    {
        bool check = _repository.DeleteDistrict(id);
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
    [HttpPut("updatedistrict/{id}")]
    public IActionResult UpdateDistrict(DistrictUpdatedDTO District1, int id)
    {
        try
        {
            if (District1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<District>(District1);

            bool updatedcheck = _repository.UpdateDistrict(id, dbupdated);
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







    //DistrictTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createdistricttranslation")]
    public IActionResult CreateDistrictTranslation(DistrictTranslationCreatedDTO Districttranslation1)
    {
        var Districttranslation = _mapper.Map<DistrictTranslation>(Districttranslation1);
        Districttranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)Districttranslation.language_id);
        int id = _repository.CreateDistrictTranslation(Districttranslation);
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
    [HttpGet("getalldistricttranslation")]
    public IActionResult GetAllDistrictTranslation(int? territorie_translation_id, string? language_code)
    {
        IEnumerable<DistrictTranslation> Districttranslations1 = _repository.AllDistrictTranslation(territorie_translation_id, language_code);
        var Districttranslations = _mapper.Map<IEnumerable<DistrictTranslationReadedDTO>>(Districttranslations1);
        if (Districttranslations == null) { }

        return Ok(Districttranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuziddistricttranslation/{uz_id}")]
    public IActionResult GetByIdDistrictTranslation(int uz_id, string language_code)
    {

        DistrictTranslation Districttranslation1 = _repository.GetDistrictTranslationById(uz_id, language_code);
        var Districttranslation = _mapper.Map<DistrictTranslationReadedIdDTO>(Districttranslation1);
        if (Districttranslation == null) { }

        return Ok(Districttranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyiddistricttranslation/{id}")]
    public IActionResult GetByIdDistrictTranslation(int id)
    {

        DistrictTranslation Districttranslation1 = _repository.GetDistrictTranslationById(id);
        var Districttranslation = _mapper.Map<DistrictTranslationReadedIdDTO>(Districttranslation1);
        if (Districttranslation == null) { }

        return Ok(Districttranslation);
    }

    [HttpGet("sitegetalldistricttranslation")]
    public IActionResult GetAllDistrictTranslationsite(int territorie_translation_id, string? language_code)
    {
        IEnumerable<DistrictTranslation> Districttranslations1 = _repository.AllDistrictTranslationSite(territorie_translation_id, language_code);
        var Districttranslations = _mapper.Map<IEnumerable<DistrictTranslationReadedSiteDTO>>(Districttranslations1);
        if (Districttranslations == null) { }

        return Ok(Districttranslations);
    }

    [HttpGet("sitegetbyuziddistricttranslation/{uz_id}")]
    public IActionResult GetByIdDistrictTranslationsite(int uz_id, string language_code)
    {

        DistrictTranslation Districttranslation1 = _repository.GetDistrictTranslationByIdSite(uz_id, language_code);
        var Districttranslation = _mapper.Map<DistrictTranslationReadedSiteDTO>(Districttranslation1);
        if (Districttranslation == null) { }

        return Ok(Districttranslation);
    }

    [HttpGet("sitegetbyiddistricttranslation/{id}")]
    public IActionResult GetByIdDistrictTranslationsite(int id)
    {

        DistrictTranslation Districttranslation1 = _repository.GetDistrictTranslationByIdSite(id);
        var Districttranslation = _mapper.Map<DistrictTranslationReadedSiteDTO>(Districttranslation1);
        if (Districttranslation == null) { }

        return Ok(Districttranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteDistricttranslation/{id}")]
    public IActionResult DeleteDistrictTranslation(int id)
    {
        bool check = _repository.DeleteDistrictTranslation(id);
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
    [HttpPut("updatedistricttranslation/{id}")]
    public IActionResult UpdateDistrictTranslation(DistrictTranslationUpdatedDTO Districttranslation1, int id)
    {
        try
        {
            if (Districttranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<DistrictTranslation>(Districttranslation1);

            bool updatedcheck = _repository.UpdateDistrictTranslation(id, dbupdated);
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
