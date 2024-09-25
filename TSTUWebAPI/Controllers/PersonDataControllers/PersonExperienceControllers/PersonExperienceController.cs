using Contracts.AllRepository.StatusesRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.PersonDataModel.PersonExperienceModel;
using Entities.DTO.PersonDataDTOS.PersonExperienceDTOS;
using Contracts.AllRepository.PersonsDataRepository.PersonExperienceRepository;
using AutoMapper;
using Entities.Model.PersonDataModel;
using Entities.DTO.PersonDataDTOS;

namespace TSTUWebAPI.Controllers.PersonDataControllers.PersonExperienceControllers;

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

    [Authorize]
    [HttpPost("createpersonexperience")]
    public IActionResult CreatePersonExperience(PersonExperienceCreatedDTO blog)
    {
        var blogMap = _mapper.Map<PersonExperience>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperience(blogMap);

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
    public IActionResult CreatePersonExperienceAdmin(PersonExperienceCreatedAdminDTO blog)
    {
        var blogMap = _mapper.Map<PersonExperience>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperience(blogMap);

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
        IEnumerable<PersonExperience> PersonExperiencesMap = _repository.AllPersonExperience(queryNum, pageNum, person_data_id, true);
        var PersonExperiences = _mapper.Map<IEnumerable<PersonExperienceReadedDTO>>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [Authorize]
    [HttpGet("getallpersonexperienceprofil")]
    public IActionResult GetAllPersonExperienceProfil(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperience> PersonExperiencesMap = _repository.AllPersonExperience(queryNum, pageNum, 0, false);
        var PersonExperiences = _mapper.Map<IEnumerable<PersonExperienceReadedProfilDTO>>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [HttpGet("getallpersonexperiencesite")]
    public IActionResult GetAllPersonExperienceSite(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperience> PersonExperiencesMap = _repository.AllPersonExperienceSite(queryNum, pageNum, person_data_id);
        var PersonExperiences = _mapper.Map<IEnumerable<PersonExperienceReadedSiteDTO>>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [Authorize]
    [HttpGet("getbyidpersonexperiencesite/{id}")]
    public IActionResult GetByIdPersonExperienceSite(int id)
    {
        PersonExperience PersonExperiencesMap = _repository.GetByIdPersonExperienceSite(id);
        var PersonExperiences = _mapper.Map<PersonExperienceReadedSiteDTO>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonexperienceadmin/{id}")]
    public IActionResult GetByIdPersonExperience(int id)
    {

        PersonExperience PersonExperiencesMap = _repository.GetByIdPersonExperience(id, true);
        var PersonExperiences = _mapper.Map<PersonExperienceReadedDTO>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [Authorize]
    [HttpGet("getbyidpersonexperience/{id}")]
    public IActionResult GetByIdPersonExperienceProfil(int id)
    {
        PersonExperience PersonExperiencesMap = _repository.GetByIdPersonExperience(id, false);
        var PersonExperiences = _mapper.Map<PersonExperienceReadedProfilDTO>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [Authorize]
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

    [Authorize]
    [HttpPut("updatepersonexperience/{id}")]
    public IActionResult UpdatePersonExperience(PersonExperienceUpdatedDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperience>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperience(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonexperienceadmin/{id}")]
    public IActionResult UpdatePersonExperienceAdmin(PersonExperienceUpdatedAdminDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperience>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperience(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }



    // PersonExperienceTranslation CRUD

    [Authorize]
    [HttpPost("createpersonexperiencetranslation")]
    public IActionResult CreatePersonExperienceTranslation(PersonExperienceTranslationCreatedDTO blog)
    {
        var blogMap = _mapper.Map<PersonExperienceTranslation>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperienceTranslation(blogMap);

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
    public IActionResult CreatePersonExperienceTranslationAdmin(PersonExperienceTranslationCreatedAdminDTO blog)
    {
        var blogMap = _mapper.Map<PersonExperienceTranslation>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonExperienceTranslation(blogMap);

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
    public IActionResult GetAllPersonExperienceTranslation(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperienceTranslation> PersonExperiencesMap = _repository.AllPersonExperienceTranslation(queryNum, pageNum, person_data_uz_id, true, language_code);
        var PersonExperiences = _mapper.Map<IEnumerable<PersonExperienceTranslationReadedDTO>>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [Authorize]
    [HttpGet("getallpersonexperiencetranslationprofile")]
    public IActionResult GetAllPersonExperienceTranslationProfile(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperienceTranslation> PersonExperiencesMap = _repository.AllPersonExperienceTranslation(queryNum, pageNum, person_data_uz_id, false, language_code);
        var PersonExperiences = _mapper.Map<IEnumerable<PersonExperienceTranslationReadedProfileDTO>>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [HttpGet("getallpersonexperiencetranslationsite")]
    public IActionResult GetAllPersonExperienceTranslationSite(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperienceTranslation> PersonExperiencesMap = _repository.AllPersonExperienceTranslationSite(queryNum, pageNum, person_data_uz_id, language_code);
        var PersonExperiences = _mapper.Map<IEnumerable<PersonExperienceTranslationReadedSiteDTO>>(PersonExperiencesMap);
        return Ok(PersonExperiences);
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

    [Authorize]
    [HttpGet("getbyidpersonexperiencetranslation/{id}")]
    public IActionResult GetByIdPersonExperienceTranslationProfil(int id)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslation(id, false);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedProfileDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonexperiencetranslationsite/{id}")]
    public IActionResult GetByIdPersonExperienceTranslationSite(int id)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslationSite(id);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
    [HttpGet("getbyidpersonexperiencetranslationuzid/{uz_id}")]
    public IActionResult GetByIdPersonExperienceTranslationProfil(int uz_id, string language_code)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslation(uz_id, language_code, false);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedProfileDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonexperiencetranslationuzidsite/{uz_id}")]
    public IActionResult GetByIdPersonExperienceTranslationSite(int uz_id, string language_code)
    {
        PersonExperienceTranslation personScientificMap = _repository.GetByIdPersonExperienceTranslationSite(uz_id, language_code);
        var personScientific = _mapper.Map<PersonExperienceTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
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

    [Authorize]
    [HttpPut("updatepersonexperiencetranslation/{id}")]
    public IActionResult UpdatePersonExperienceTranslation(PersonExperienceTranslationUpdatedDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperienceTranslation>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperienceTranslation(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonexperiencetranslationadmin/{id}")]
    public IActionResult UpdatePersonExperienceTranslationAdmin(PersonExperienceTranslationUpdatedAdminDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonExperienceTranslation>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonExperienceTranslation(id, dbupdated, true);

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
        IEnumerable<PersonData> personsMap = _repository.AllPersonExperienceCreated();
        var persons = _mapper.Map<IEnumerable<PersonDataSearchDTO>>(personsMap);
        return Ok(persons);
    }

    [Authorize(Roles = "HeadDepartment")]
    [HttpGet("getallpersonexperiencedep/{person_data_id}")]
    public IActionResult GetAllPersonExperienceDep(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonExperience> PersonExperiencesMap = _repository.AllPersonExperienceDep(queryNum, pageNum, person_data_id);
        var PersonExperiences = _mapper.Map<IEnumerable<PersonExperienceReadedSiteDTO>>(PersonExperiencesMap);
        return Ok(PersonExperiences);
    }

    [Authorize(Roles = "HeadDepartment")]
    [HttpPost("confirmed/{person_experience_id}")]
    public IActionResult ConfirmAttribute(int person_experience_id, bool confirm)
    {
        var check = _repository.ConfirmDocumentTeacher110Set(person_experience_id, confirm);

        if (!check) return BadRequest();

        return Ok("Confirmed");
    }

}

