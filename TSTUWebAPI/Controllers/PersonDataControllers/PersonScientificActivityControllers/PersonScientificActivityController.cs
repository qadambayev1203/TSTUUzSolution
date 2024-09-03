using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.PersonDataModel.PersonScientificActivityModel;
using Entities.DTO.PersonDataDTOS.PersonScientificActivityDTOS;
using Contracts.AllRepository.PersonsDataRepository.PersonScientificActivityRepository;

namespace TSTUWebAPI.Controllers.PersonDataControllers.PersonScientificActivityControllers;

[Authorize]
[Route("api/personscientificactivity")]
[ApiController]
public class PersonScientificActivityController : ControllerBase
{
    private readonly IPersonScientificActivityRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public PersonScientificActivityController(IPersonScientificActivityRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }



    // PersonScientificActivity CRUD

    [HttpPost("createpersonscientificactivity")]
    public IActionResult CreatePersonScientificActivity(PersonScientificActivityCreatedDTO scientificActivity)
    {
        var scientificActivityMap = _mapper.Map<PersonScientificActivity>(scientificActivity);
        scientificActivityMap.status_id = _status.GetStatusId("Active");

        int check = _repository.CreatePersonScientificActivity(scientificActivityMap);

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
    [HttpPost("createpersonscientificactivityadmin")]
    public IActionResult CreatePersonScientificActivityAdmin(PersonScientificActivityCreatedAdminDTO scientificActivity)
    {
        var scientificActivityMap = _mapper.Map<PersonScientificActivity>(scientificActivity);
        scientificActivityMap.status_id = _status.GetStatusId("Active");

        int check = _repository.CreatePersonScientificActivity(scientificActivityMap);

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
    [HttpGet("getallpersonscientificactivityadmin")]
    public IActionResult GetAllPersonScientificActivity(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonScientificActivity> personScientificsMap = _repository.AllPersonScientificActivity(queryNum, pageNum, person_data_id, true);
        var personScientifics = _mapper.Map<IEnumerable<PersonScientificActivityReadedDTO>>(personScientificsMap);
        return Ok(personScientifics);
    }

    [HttpGet("getallpersonscientificactivitysite")]
    public IActionResult GetAllPersonScientificActivitySite(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonScientificActivity> personScientificsMap = _repository.AllPersonScientificActivity(queryNum, pageNum, person_data_id, false);
        var personScientifics = _mapper.Map<IEnumerable<PersonScientificActivityReadedSiteDTO>>(personScientificsMap);
        return Ok(personScientifics);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonscientificactivityadmin/{id}")]
    public IActionResult GetByIdPersonScientificActivity(int id)
    {

        PersonScientificActivity personScientificMap = _repository.GetByIdPersonScientificActivity(id, true);
        var personScientific = _mapper.Map<PersonScientificActivityReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonscientificactivity/{id}")]
    public IActionResult GetByIdPersonScientificActivitySite(int id)
    {
        PersonScientificActivity personScientificMap = _repository.GetByIdPersonScientificActivity(id, false);
        var personScientific = _mapper.Map<PersonScientificActivityReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpDelete("deletepersonscientificactivity/{id}")]
    public IActionResult DeletePersonScientificActivity(int id)
    {
        bool check = _repository.DeletePersonScientificActivity(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [HttpPut("updatepersonscientificactivity/{id}")]
    public IActionResult UpdatePersonScientificActivity(PersonScientificActivityUpdatedDTO scientificActivityUpdatedDTO, int id)
    {
        if (scientificActivityUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonScientificActivity>(scientificActivityUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonScientificActivity(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonscientificactivityadmin/{id}")]
    public IActionResult UpdatePersonScientificActivityAdmin(PersonScientificActivityUpdatedAdminDTO scientificActivityUpdatedDTO, int id)
    {
        if (scientificActivityUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonScientificActivity>(scientificActivityUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonScientificActivity(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }



    // PersonScientificActivityTranslation CRUD

    [HttpPost("createpersonscientificactivitytranslation")]
    public IActionResult CreatePersonScientificActivityTranslation(PersonScientificActivityTranslationCreatedDTO scientificActivity)
    {
        var scientificActivityMap = _mapper.Map<PersonScientificActivityTranslation>(scientificActivity);
        scientificActivityMap.status_translation_id = _status.GetStatusId("Active");

        int check = _repository.CreatePersonScientificActivityTranslation(scientificActivityMap);

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
    [HttpPost("createpersonscientificactivitytranslationadmin")]
    public IActionResult CreatePersonScientificActivityTranslationAdmin(PersonScientificActivityTranslationCreatedAdminDTO scientificActivity)
    {
        var scientificActivityMap = _mapper.Map<PersonScientificActivityTranslation>(scientificActivity);
        scientificActivityMap.status_translation_id = _status.GetStatusId("Active");

        int check = _repository.CreatePersonScientificActivityTranslation(scientificActivityMap);

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
    [HttpGet("getallpersonscientificactivitytranslationadmin")]
    public IActionResult GetAllPersonScientificActivityTranslation(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonScientificActivityTranslation> personScientificsMap = _repository.AllPersonScientificActivityTranslation(queryNum, pageNum, person_data_id, true, language_code);
        var personScientifics = _mapper.Map<IEnumerable<PersonScientificActivityTranslationReadedDTO>>(personScientificsMap);
        return Ok(personScientifics);
    }

    [HttpGet("getallpersonscientificactivitytranslationsite")]
    public IActionResult GetAllPersonScientificActivityTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonScientificActivityTranslation> personScientificsMap = _repository.AllPersonScientificActivityTranslation(queryNum, pageNum, person_data_id, false, language_code);
        var personScientifics = _mapper.Map<IEnumerable<PersonScientificActivityTranslationReadedSiteDTO>>(personScientificsMap);
        return Ok(personScientifics);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonscientificactivitytranslationadmin/{id}")]
    public IActionResult GetByIdPersonScientificActivityTranslation(int id)
    {
        PersonScientificActivityTranslation personScientificMap = _repository.GetByIdPersonScientificActivityTranslation(id, true);
        var personScientific = _mapper.Map<PersonScientificActivityTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonscientificactivitytranslationadminuzid/{uz_id}")]
    public IActionResult GetByIdPersonScientificActivityTranslation(int uz_id, string language_code)
    {
        PersonScientificActivityTranslation personScientificMap = _repository.GetByIdPersonScientificActivityTranslation(uz_id, language_code, true);
        var personScientific = _mapper.Map<PersonScientificActivityTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonscientificactivitytranslation/{id}")]
    public IActionResult GetByIdPersonScientificActivityTranslationSite(int id)
    {
        PersonScientificActivityTranslation personScientificMap = _repository.GetByIdPersonScientificActivityTranslation(id, false);
        var personScientific = _mapper.Map<PersonScientificActivityTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonscientificactivitytranslationuzid/{uz_id}")]
    public IActionResult GetByIdPersonScientificActivityTranslationSite(int uz_id, string language_code)
    {
        PersonScientificActivityTranslation personScientificMap = _repository.GetByIdPersonScientificActivityTranslation(uz_id, language_code, false);
        var personScientific = _mapper.Map<PersonScientificActivityTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpDelete("deletepersonscientificactivitytranslation/{id}")]
    public IActionResult DeletePersonScientificActivityTranslation(int id)
    {
        bool check = _repository.DeletePersonScientificActivityTranslation(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [HttpPut("updatepersonscientificactivitytranslation/{id}")]
    public IActionResult UpdatePersonScientificActivityTranslation(PersonScientificActivityTranslationUpdatedDTO scientificActivityUpdatedDTO, int id)
    {
        if (scientificActivityUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonScientificActivityTranslation>(scientificActivityUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonScientificActivityTranslation(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonscientificactivitytranslationadmin/{id}")]
    public IActionResult UpdatePersonScientificActivityTranslationAdmin(PersonScientificActivityTranslationUpdatedAdminDTO scientificActivityUpdatedDTO, int id)
    {
        if (scientificActivityUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonScientificActivityTranslation>(scientificActivityUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonScientificActivityTranslation(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

}

