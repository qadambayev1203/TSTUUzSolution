using AutoMapper;
using Contracts.AllRepository.CountriesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.CountrysDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.CountrysModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.CountrieControllers;

[Route("api/country")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public CountryController(ICountryRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // Country CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createcountry")]
    public IActionResult CreateCountry(CountryCreatedDTO Country1)
    {
        var Country = _mapper.Map<Country>(Country1);
        Country.status_id = _status.GetStatusId("Active");
        int id = _repository.CreateCountry(Country);

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
    [HttpGet("getallcountry")]
    public IActionResult GetAllCountry()
    {
        IEnumerable<Country> Countrys1 = _repository.AllCountry();
        var Countrys = _mapper.Map<IEnumerable<CountryReadedDTO>>(Countrys1);
        if (Countrys == null) { }

        return Ok(Countrys);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidcountry/{id}")]
    public IActionResult GetByIdCountry(int id)
    {

        Country Country1 = _repository.GetCountryById(id);
        if (Country1 == null)
        {

        }
        var Country = _mapper.Map<CountryReadedDTO>(Country1);
        if (Country == null) { }
        return Ok(Country);
    }

    [HttpGet("sitegetallcountry")]
    public IActionResult GetAllCountrysite()
    {
        IEnumerable<Country> Countrys1 = _repository.AllCountrySite();
        var Countrys = _mapper.Map<IEnumerable<CountryReadedSiteDTO>>(Countrys1);
        if (Countrys == null) { }

        return Ok(Countrys);
    }

    [HttpGet("sitegetbyidcountry/{id}")]
    public IActionResult GetByIdCountrysite(int id)
    {

        Country Country1 = _repository.GetCountryByIdSite(id);
        if (Country1 == null)
        {

        }
        var Country = _mapper.Map<CountryReadedSiteDTO>(Country1);
        if (Country == null) { }
        return Ok(Country);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteCountry/{id}")]
    public IActionResult DeleteCountry(int id)
    {
        bool check = _repository.DeleteCountry(id);
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
    [HttpPut("updatecountry/{id}")]
    public IActionResult UpdateCountry(CountryUpdatedDTO Country1, int id)
    {
        try
        {
            if (Country1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<Country>(Country1);

            bool updatedcheck = _repository.UpdateCountry(id, dbupdated);
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







    //CountryTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createcountrytranslation")]
    public IActionResult CreateCountryTranslation(CountryTranslationCreatedDTO Countrytranslation1)
    {
        var Countrytranslation = _mapper.Map<CountryTranslation>(Countrytranslation1);
        Countrytranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)Countrytranslation.language_id);
        int id = _repository.CreateCountryTranslation(Countrytranslation);
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
    [HttpGet("getallcountrytranslation")]
    public IActionResult GetAllCountryTranslation(string language_code)
    {
        IEnumerable<CountryTranslation> Countrytranslations1 = _repository.AllCountryTranslation(language_code);
        var Countrytranslations = _mapper.Map<IEnumerable<CountryTranslationReadedDTO>>(Countrytranslations1);
        if (Countrytranslations == null) { }

        return Ok(Countrytranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidcountrytranslation/{id}")]
    public IActionResult GetByIdCountryTranslation(int id)
    {

        CountryTranslation Countrytranslation1 = _repository.GetCountryTranslationById(id);
        var Countrytranslation = _mapper.Map<CountryTranslationReadedDTO>(Countrytranslation1);
        if (Countrytranslation == null) { }

        return Ok(Countrytranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidcountrytranslation/{uz_id}")]
    public IActionResult GetByIdCountryTranslation(int uz_id, string language_code)
    {

        CountryTranslation Countrytranslation1 = _repository.GetCountryTranslationById(uz_id, language_code);
        var Countrytranslation = _mapper.Map<CountryTranslationReadedDTO>(Countrytranslation1);
        if (Countrytranslation == null) { }

        return Ok(Countrytranslation);
    }

    [HttpGet("sitegetallcountrytranslation")]
    public IActionResult GetAllCountryTranslationsite(string language_code)
    {
        IEnumerable<CountryTranslation> Countrytranslations1 = _repository.AllCountryTranslationSite(language_code);
        var Countrytranslations = _mapper.Map<IEnumerable<CountryTranslationReadedSiteDTO>>(Countrytranslations1);
        if (Countrytranslations == null) { }

        return Ok(Countrytranslations);
    }

    [HttpGet("sitegetbyuzidcountrytranslation/{uz_id}")]
    public IActionResult GetByIdCountryTranslationsite(int uz_id, string language_code)
    {

        CountryTranslation Countrytranslation1 = _repository.GetCountryTranslationByIdSite(uz_id, language_code);
        var Countrytranslation = _mapper.Map<CountryTranslationReadedSiteDTO>(Countrytranslation1);
        if (Countrytranslation == null) { }

        return Ok(Countrytranslation);
    }

    [HttpGet("sitegetbyidcountrytranslation/{id}")]
    public IActionResult GetByIdCountryTranslationsite(int id)
    {

        CountryTranslation Countrytranslation1 = _repository.GetCountryTranslationByIdSite(id);
        var Countrytranslation = _mapper.Map<CountryTranslationReadedSiteDTO>(Countrytranslation1);
        if (Countrytranslation == null) { }

        return Ok(Countrytranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteCountrytranslation/{id}")]
    public IActionResult DeleteCountryTranslation(int id)
    {
        bool check = _repository.DeleteCountryTranslation(id);
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
    [HttpPut("updatecountrytranslation/{id}")]
    public IActionResult UpdateCountryTranslation(CountryTranslationUpdatedDTO Countrytranslation1, int id)
    {
        try
        {
            if (Countrytranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<CountryTranslation>(Countrytranslation1);

            bool updatedcheck = _repository.UpdateCountryTranslation(id, dbupdated);
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
