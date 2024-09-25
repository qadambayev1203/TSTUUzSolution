using Contracts.AllRepository.StatusesRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.PersonDataModel.PersonPortfolioModel;
using Entities.DTO.PersonDataDTOS.PersonPortfolioDTOS;
using Contracts.AllRepository.PersonsDataRepository.PersonPortfolioRepository;
using AutoMapper;
using Entities.Model.PersonDataModel;
using Entities.DTO.PersonDataDTOS;

namespace TSTUWebAPI.Controllers.PersonDataControllers.PersonPortfolioControllers;

[Route("api/personportfolio")]
[ApiController]
public class PersonPortfolioController : ControllerBase
{
    private readonly IPersonPortfolioRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public PersonPortfolioController(IPersonPortfolioRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }



    // PersonPortfolio CRUD

    [Authorize]
    [HttpPost("createpersonportfolio")]
    public IActionResult CreatePersonPortfolio(PersonPortfolioCreatedDTO blog)
    {
        var blogMap = _mapper.Map<PersonPortfolio>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolio(blogMap);

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
    [HttpPost("createpersonportfolioadmin")]
    public IActionResult CreatePersonPortfolioAdmin(PersonPortfolioCreatedAdminDTO blog)
    {
        var blogMap = _mapper.Map<PersonPortfolio>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolio(blogMap);

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
    [HttpGet("getallpersonportfolioadmin")]
    public IActionResult GetAllPersonPortfolio(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolio> PersonPortfoliosMap = _repository.AllPersonPortfolio(queryNum, pageNum, person_data_id, true);
        var PersonPortfolios = _mapper.Map<IEnumerable<PersonPortfolioReadedDTO>>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [Authorize]
    [HttpGet("getallpersonportfolioprofil")]
    public IActionResult GetAllPersonPortfolioProfil(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolio> PersonPortfoliosMap = _repository.AllPersonPortfolio(queryNum, pageNum, 0, false);
        var PersonPortfolios = _mapper.Map<IEnumerable<PersonPortfolioReadedProfilDTO>>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [HttpGet("getallpersonportfoliosite")]
    public IActionResult GetAllPersonPortfolioSite(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolio> PersonPortfoliosMap = _repository.AllPersonPortfolioSite(queryNum, pageNum, person_data_id);
        var PersonPortfolios = _mapper.Map<IEnumerable<PersonPortfolioReadedSiteDTO>>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [Authorize]
    [HttpGet("getbyidpersonportfoliosite/{id}")]
    public IActionResult GetByIdPersonPortfolioSite(int id)
    {
        PersonPortfolio PersonPortfoliosMap = _repository.GetByIdPersonPortfolioSite(id);
        var PersonPortfolios = _mapper.Map<PersonPortfolioReadedSiteDTO>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonportfolioadmin/{id}")]
    public IActionResult GetByIdPersonPortfolio(int id)
    {

        PersonPortfolio PersonPortfoliosMap = _repository.GetByIdPersonPortfolio(id, true);
        var PersonPortfolios = _mapper.Map<PersonPortfolioReadedDTO>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [Authorize]
    [HttpGet("getbyidpersonportfolio/{id}")]
    public IActionResult GetByIdPersonPortfolioProfil(int id)
    {
        PersonPortfolio PersonPortfoliosMap = _repository.GetByIdPersonPortfolio(id, false);
        var PersonPortfolios = _mapper.Map<PersonPortfolioReadedProfilDTO>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [Authorize]
    [HttpDelete("deletepersonportfolio/{id}")]
    public IActionResult DeletePersonPortfolio(int id)
    {
        bool check = _repository.DeletePersonPortfolio(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [Authorize]
    [HttpPut("updatepersonportfolio/{id}")]
    public IActionResult UpdatePersonPortfolio(PersonPortfolioUpdatedDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolio>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolio(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonportfolioadmin/{id}")]
    public IActionResult UpdatePersonPortfolioAdmin(PersonPortfolioUpdatedAdminDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolio>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolio(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }



    // PersonPortfolioTranslation CRUD

    [Authorize]
    [HttpPost("createpersonportfoliotranslation")]
    public IActionResult CreatePersonPortfolioTranslation(PersonPortfolioTranslationCreatedDTO blog)
    {
        var blogMap = _mapper.Map<PersonPortfolioTranslation>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolioTranslation(blogMap);

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
    [HttpPost("createpersonportfoliotranslationadmin")]
    public IActionResult CreatePersonPortfolioTranslationAdmin(PersonPortfolioTranslationCreatedAdminDTO blog)
    {
        var blogMap = _mapper.Map<PersonPortfolioTranslation>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolioTranslation(blogMap);

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
    [HttpGet("getallpersonportfoliotranslationadmin")]
    public IActionResult GetAllPersonPortfolioTranslation(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolioTranslation> PersonPortfoliosMap = _repository.AllPersonPortfolioTranslation(queryNum, pageNum, person_data_uz_id, true, language_code);
        var PersonPortfolios = _mapper.Map<IEnumerable<PersonPortfolioTranslationReadedDTO>>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [Authorize]
    [HttpGet("getallpersonportfoliotranslationprofile")]
    public IActionResult GetAllPersonPortfolioTranslationProfile(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolioTranslation> PersonPortfoliosMap = _repository.AllPersonPortfolioTranslation(queryNum, pageNum, person_data_uz_id, false, language_code);
        var PersonPortfolios = _mapper.Map<IEnumerable<PersonPortfolioTranslationReadedProfileDTO>>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [HttpGet("getallpersonportfoliotranslationsite")]
    public IActionResult GetAllPersonPortfolioTranslationSite(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolioTranslation> PersonPortfoliosMap = _repository.AllPersonPortfolioTranslationSite(queryNum, pageNum, person_data_uz_id, language_code);
        var PersonPortfolios = _mapper.Map<IEnumerable<PersonPortfolioTranslationReadedSiteDTO>>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonportfoliotranslationadmin/{id}")]
    public IActionResult GetByIdPersonPortfolioTranslation(int id)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslation(id, true);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonportfoliotranslationadminuzid/{uz_id}")]
    public IActionResult GetByIdPersonPortfolioTranslation(int uz_id, string language_code)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslation(uz_id, language_code, true);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
    [HttpGet("getbyidpersonportfoliotranslation/{id}")]
    public IActionResult GetByIdPersonPortfolioTranslationProfil(int id)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslation(id, false);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedProfileDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonportfoliotranslationsite/{id}")]
    public IActionResult GetByIdPersonPortfolioTranslationSite(int id)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslationSite(id);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
    [HttpGet("getbyidpersonportfoliotranslationuzid/{uz_id}")]
    public IActionResult GetByIdPersonPortfolioTranslationProfil(int uz_id, string language_code)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslation(uz_id, language_code, false);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedProfileDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonportfoliotranslationuzidsite/{uz_id}")]
    public IActionResult GetByIdPersonPortfolioTranslationSite(int uz_id, string language_code)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslationSite(uz_id, language_code);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
    [HttpDelete("deletepersonportfoliotranslation/{id}")]
    public IActionResult DeletePersonPortfolioTranslation(int id)
    {
        bool check = _repository.DeletePersonPortfolioTranslation(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [Authorize]
    [HttpPut("updatepersonportfoliotranslation/{id}")]
    public IActionResult UpdatePersonPortfolioTranslation(PersonPortfolioTranslationUpdatedDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolioTranslation>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolioTranslation(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonportfoliotranslationadmin/{id}")]
    public IActionResult UpdatePersonPortfolioTranslationAdmin(PersonPortfolioTranslationUpdatedAdminDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolioTranslation>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolioTranslation(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }



    // Confirm Department head

    [Authorize(Roles = "HeadDepartment")]
    [HttpGet("getallpersondatadepartment")]
    public IActionResult GetAllPersonDataDepartment()
    {
        IEnumerable<PersonData> personsMap = _repository.AllPersonPortfolioCreated();
        var persons = _mapper.Map<IEnumerable<PersonDataSearchDTO>>(personsMap);
        return Ok(persons);
    }

    [Authorize(Roles = "HeadDepartment")]
    [HttpGet("getallpersonportfoliodep/{person_data_id}")]
    public IActionResult GetAllPersonPortfolioDep(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolio> PersonPortfoliosMap = _repository.AllPersonPortfolioDep(queryNum, pageNum, person_data_id);
        var PersonPortfolios = _mapper.Map<IEnumerable<PersonPortfolioReadedSiteDTO>>(PersonPortfoliosMap);
        return Ok(PersonPortfolios);
    }

    [Authorize(Roles = "HeadDepartment")]
    [HttpPost("confirmed/{person_portfolio_id}")]
    public IActionResult ConfirmAttribute(int person_portfolio_id, bool confirm)
    {
        var check = _repository.ConfirmDocumentTeacher110Set(person_portfolio_id, confirm);

        if (!check) return BadRequest();

        return Ok("Confirmed");
    }

}

