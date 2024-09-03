using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.PersonDataModel.PersonPortfolioModel;
using Entities.DTO.PersonDataDTOS.PersonPortfolioDTOS;
using Contracts.AllRepository.PersonsDataRepository.PersonPortfolioRepository;

namespace TSTUWebAPI.Controllers.PersonDataControllers.PersonPortfolioControllers;

[Authorize]
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

    [HttpPost("createpersonportfolio")]
    public IActionResult CreatePersonPortfolio(PersonPortfolioCreatedDTO Portfolio)
    {
        var PortfolioMap = _mapper.Map<PersonPortfolio>(Portfolio);
        PortfolioMap.status_id = _status.GetStatusId("Active");
        PortfolioMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolio(PortfolioMap);

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
    public IActionResult CreatePersonPortfolioAdmin(PersonPortfolioCreatedAdminDTO Portfolio)
    {
        var PortfolioMap = _mapper.Map<PersonPortfolio>(Portfolio);
        PortfolioMap.status_id = _status.GetStatusId("Active");
        PortfolioMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolio(PortfolioMap);

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
        IEnumerable<PersonPortfolio> personPortfoliosMap = _repository.AllPersonPortfolio(queryNum, pageNum, person_data_id, true);
        var personPortfolios = _mapper.Map<IEnumerable<PersonPortfolioReadedDTO>>(personPortfoliosMap);
        return Ok(personPortfolios);
    }

    [HttpGet("getallpersonportfoliosite")]
    public IActionResult GetAllPersonPortfolioSite(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolio> personPortfoliosMap = _repository.AllPersonPortfolio(queryNum, pageNum, person_data_id, false);
        var personPortfolios = _mapper.Map<IEnumerable<PersonPortfolioReadedSiteDTO>>(personPortfoliosMap);
        return Ok(personPortfolios);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonportfolioadmin/{id}")]
    public IActionResult GetByIdPersonPortfolio(int id)
    {

        PersonPortfolio personPortfoliosMap = _repository.GetByIdPersonPortfolio(id, true);
        var personPortfolios = _mapper.Map<PersonPortfolioReadedDTO>(personPortfoliosMap);
        return Ok(personPortfolios);
    }

    [HttpGet("getbyidpersonportfolio/{id}")]
    public IActionResult GetByIdPersonPortfolioSite(int id)
    {
        PersonPortfolio personPortfoliosMap = _repository.GetByIdPersonPortfolio(id, false);
        var personPortfolios = _mapper.Map<PersonPortfolioReadedSiteDTO>(personPortfoliosMap);
        return Ok(personPortfolios);
    }

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

    [HttpPut("updatepersonportfolio/{id}")]
    public IActionResult UpdatePersonPortfolio(PersonPortfolioUpdatedDTO PortfolioUpdatedDTO, int id)
    {
        if (PortfolioUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolio>(PortfolioUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolio(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonportfolioadmin/{id}")]
    public IActionResult UpdatePersonPortfolioAdmin(PersonPortfolioUpdatedAdminDTO PortfolioUpdatedDTO, int id)
    {
        if (PortfolioUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolio>(PortfolioUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolio(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }



    // PersonPortfolioTranslation CRUD

    [HttpPost("createpersonportfoliotranslation")]
    public IActionResult CreatePersonPortfolioTranslation(PersonPortfolioTranslationCreatedDTO Portfolio)
    {
        var PortfolioMap = _mapper.Map<PersonPortfolioTranslation>(Portfolio);
        PortfolioMap.status_id = _status.GetStatusId("Active");
        PortfolioMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolioTranslation(PortfolioMap);

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
    public IActionResult CreatePersonPortfolioTranslationAdmin(PersonPortfolioTranslationCreatedAdminDTO Portfolio)
    {
        var PortfolioMap = _mapper.Map<PersonPortfolioTranslation>(Portfolio);
        PortfolioMap.status_id = _status.GetStatusId("Active");
        PortfolioMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonPortfolioTranslation(PortfolioMap);

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
    public IActionResult GetAllPersonPortfolioTranslation(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolioTranslation> personPortfoliosMap = _repository.AllPersonPortfolioTranslation(queryNum, pageNum, person_data_id, true, language_code);
        var personPortfolios = _mapper.Map<IEnumerable<PersonPortfolioTranslationReadedDTO>>(personPortfoliosMap);
        return Ok(personPortfolios);
    }

    [HttpGet("getallpersonportfoliotranslationsite")]
    public IActionResult GetAllPersonPortfolioTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonPortfolioTranslation> personPortfoliosMap = _repository.AllPersonPortfolioTranslation(queryNum, pageNum, person_data_id, false, language_code);
        var personPortfolios = _mapper.Map<IEnumerable<PersonPortfolioTranslationReadedSiteDTO>>(personPortfoliosMap);
        return Ok(personPortfolios);
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

    [HttpGet("getbyidpersonportfoliotranslation/{id}")]
    public IActionResult GetByIdPersonPortfolioTranslationSite(int id)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslation(id, false);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonportfoliotranslationuzid/{uz_id}")]
    public IActionResult GetByIdPersonPortfolioTranslationSite(int uz_id, string language_code)
    {
        PersonPortfolioTranslation personScientificMap = _repository.GetByIdPersonPortfolioTranslation(uz_id, language_code, false);
        var personScientific = _mapper.Map<PersonPortfolioTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

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

    [HttpPut("updatepersonportfoliotranslation/{id}")]
    public IActionResult UpdatePersonPortfolioTranslation(PersonPortfolioTranslationUpdatedDTO PortfolioUpdatedDTO, int id)
    {
        if (PortfolioUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolioTranslation>(PortfolioUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolioTranslation(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonportfoliotranslationadmin/{id}")]
    public IActionResult UpdatePersonPortfolioTranslationAdmin(PersonPortfolioTranslationUpdatedAdminDTO PortfolioUpdatedDTO, int id)
    {
        if (PortfolioUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonPortfolioTranslation>(PortfolioUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonPortfolioTranslation(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

}

