using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.PersonDataModel.PersonExperienceModel;
using Entities.DTO.PersonDataDTOS.PersonExperienceDTOS;
using Contracts.AllRepository.PersonsDataRepository.PersonExperienceRepository;

namespace TSTUWebAPI.Controllers.PersonDataControllers.PersonExperienceControllers;

[Authorize]
[Route("api/personexperience")]
[ApiController]
public class PersonExperienceController : ControllerBase
{
    private readonly IPersonExperienceRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public PersonExperienceController(IPersonExperienceRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }



    // PersonExperience CRUD

    [HttpPost("createpersonexperience")]
    public IActionResult CreatePersonExperience(PersonExperienceCreatedDTO Experience)
    {
        var ExperienceMap = _mapper.Map<PersonExperience>(Experience);
        ExperienceMap.status_id = _status.GetStatusId("Active");
        ExperienceMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperience(ExperienceMap);

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
    [HttpPost("createpersonexperienceadmin")]
    public IActionResult CreatePersonExperienceAdmin(PersonExperienceCreatedAdminDTO Experience)
    {
        var ExperienceMap = _mapper.Map<PersonExperience>(Experience);
        ExperienceMap.status_id = _status.GetStatusId("Active");
        ExperienceMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperience(ExperienceMap);

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
    [HttpGet("getallpersonexperienceadmin")]
    public IActionResult GetAllPersonExperience(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperience> personExperiencesMap = _repository.AllPersonExperience(queryNum, pageNum, person_data_id, true);
        var personExperiences = _mapper.Map<IEnumerable<PersonExperienceReadedDTO>>(personExperiencesMap);
        return Ok(personExperiences);
    }

    [HttpGet("getallpersonexperiencesite")]
    public IActionResult GetAllPersonExperienceSite(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperience> personExperiencesMap = _repository.AllPersonExperience(queryNum, pageNum, person_data_id, false);
        var personExperiences = _mapper.Map<IEnumerable<PersonExperienceReadedSiteDTO>>(personExperiencesMap);
        return Ok(personExperiences);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonexperienceadmin/{id}")]
    public IActionResult GetByIdPersonExperience(int id)
    {

        PersonExperience personExperiencesMap = _repository.GetByIdPersonExperience(id, true);
        var personExperiences = _mapper.Map<PersonExperienceReadedDTO>(personExperiencesMap);
        return Ok(personExperiences);
    }

    [HttpGet("getbyidpersonexperience/{id}")]
    public IActionResult GetByIdPersonExperienceSite(int id)
    {
        PersonExperience personExperiencesMap = _repository.GetByIdPersonExperience(id, false);
        var personExperiences = _mapper.Map<PersonExperienceReadedSiteDTO>(personExperiencesMap);
        return Ok(personExperiences);
    }

    [HttpDelete("deletepersonexperience/{id}")]
    public IActionResult DeletePersonExperience(int id)
    {
        bool check = _repository.DeletePersonExperience(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [HttpPut("updatepersonexperience/{id}")]
    public IActionResult UpdatePersonExperience(PersonExperienceUpdatedDTO ExperienceUpdatedDTO, int id)
    {
        if (ExperienceUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperience>(ExperienceUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperience(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonexperienceadmin/{id}")]
    public IActionResult UpdatePersonExperienceAdmin(PersonExperienceUpdatedAdminDTO ExperienceUpdatedDTO, int id)
    {
        if (ExperienceUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperience>(ExperienceUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperience(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }



    // PersonExperienceTranslation CRUD

    [HttpPost("createpersonexperiencetranslation")]
    public IActionResult CreatePersonExperienceTranslation(PersonExperienceTranslationCreatedDTO Experience)
    {
        var ExperienceMap = _mapper.Map<PersonExperienceTranslation>(Experience);
        ExperienceMap.status_id = _status.GetStatusId("Active");
        ExperienceMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperienceTranslation(ExperienceMap);

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
    [HttpPost("createpersonexperiencetranslationadmin")]
    public IActionResult CreatePersonExperienceTranslationAdmin(PersonExperienceTranslationCreatedAdminDTO Experience)
    {
        var ExperienceMap = _mapper.Map<PersonExperienceTranslation>(Experience);
        ExperienceMap.status_id = _status.GetStatusId("Active");
        ExperienceMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperienceTranslation(ExperienceMap);

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
    [HttpGet("getallpersonexperiencetranslationadmin")]
    public IActionResult GetAllPersonExperienceTranslation(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperienceTranslation> personExperiencesMap = _repository.AllPersonExperienceTranslation(queryNum, pageNum, person_data_id, true, language_code);
        var personExperiences = _mapper.Map<IEnumerable<PersonExperienceTranslationReadedDTO>>(personExperiencesMap);
        return Ok(personExperiences);
    }

    [HttpGet("getallpersonexperiencetranslationsite")]
    public IActionResult GetAllPersonExperienceTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperienceTranslation> personExperiencesMap = _repository.AllPersonExperienceTranslation(queryNum, pageNum, person_data_id, false, language_code);
        var personExperiences = _mapper.Map<IEnumerable<PersonExperienceTranslationReadedSiteDTO>>(personExperiencesMap);
        return Ok(personExperiences);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonexperiencetranslationadmin/{id}")]
    public IActionResult GetByIdPersonExperienceTranslation(int id)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslation(id, true);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonexperiencetranslationadminuzid/{uz_id}")]
    public IActionResult GetByIdPersonExperienceTranslation(int uz_id, string language_code)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslation(uz_id, language_code, true);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonexperiencetranslation/{id}")]
    public IActionResult GetByIdPersonExperienceTranslationSite(int id)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslation(id, false);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonexperiencetranslationuzid/{uz_id}")]
    public IActionResult GetByIdPersonExperienceTranslationSite(int uz_id, string language_code)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslation(uz_id, language_code, false);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpDelete("deletepersonexperiencetranslation/{id}")]
    public IActionResult DeletePersonExperienceTranslation(int id)
    {
        bool check = _repository.DeletePersonExperienceTranslation(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [HttpPut("updatepersonexperiencetranslation/{id}")]
    public IActionResult UpdatePersonExperienceTranslation(PersonExperienceTranslationUpdatedDTO ExperienceUpdatedDTO, int id)
    {
        if (ExperienceUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperienceTranslation>(ExperienceUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperienceTranslation(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonexperiencetranslationadmin/{id}")]
    public IActionResult UpdatePersonExperienceTranslationAdmin(PersonExperienceTranslationUpdatedAdminDTO ExperienceUpdatedDTO, int id)
    {
        if (ExperienceUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperienceTranslation>(ExperienceUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperienceTranslation(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

}

