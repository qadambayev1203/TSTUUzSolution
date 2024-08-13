using AutoMapper;
using Contracts.AllRepository.PersonsRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.PersonDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Entities.Model.PersonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.PersonControllers;

[Route("api/person")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public PersonController(IPersonRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // person CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createperson")]
    public IActionResult Createperson(PersonCreatedDTO person1)
    {
        var person = _mapper.Map<Person>(person1);
        person.status_id = _status.GetStatusId("Active");

        FileUploadRepository fileUpload = new FileUploadRepository();

        var Url = fileUpload.SaveFileAsync(person1.img_up);
        if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
        {
            return BadRequest("File created error!");
        }
        if (Url != null && Url.Length > 0)
        {
            person.img_ = new Files
            {
                title = Guid.NewGuid().ToString(),
                url = Url
            };
        }


        int check = _repository.CreatePerson(person);

        if (check == 0)
        {
            fileUpload.DeleteFileAsync(Url);
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
    [HttpGet("getallperson")]
    public IActionResult GetAllperson(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<Person> persons1 = _repository.AllPerson(queryNum, pageNum);
        var persons = _mapper.Map<IEnumerable<PersonReadedDTO>>(persons1);
        if (persons == null) { }

        return Ok(persons);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidperson/{id}")]
    public IActionResult GetByIdperson(int id)
    {

        Person person1 = _repository.GetPersonById(id);
        var person = _mapper.Map<PersonReadedDTO>(person1);
        if (person == null) { }
        return Ok(person);
    }

    [HttpGet("sitegetallperson")]
    public IActionResult GetAllpersonsite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<Person> persons1 = _repository.AllPersonSite(queryNum, pageNum);
        var persons = _mapper.Map<IEnumerable<PersonReadedSiteDTO>>(persons1);
        if (persons == null) { }

        return Ok(persons);
    }

    [HttpGet("sitegetbyidperson/{id}")]
    public IActionResult GetByIdpersonsite(int id)
    {

        Person person1 = _repository.GetPersonByIdSite(id);
        var person = _mapper.Map<PersonReadedSiteDTO>(person1);
        if (person == null) { }
        return Ok(person);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteperson/{id}")]
    public IActionResult Deleteperson(int id)
    {
        bool check = _repository.DeletePerson(id);
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
    [HttpPut("updateperson/{id}")]
    public IActionResult Updateperson(PersonUpdatedDTO person1, int id)
    {
        try
        {
            if (person1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<Person>(person1);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(person1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                dbupdated.img_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }

            dbupdated.updated_at = DateTime.UtcNow;

            bool updatedcheck = _repository.UpdatePerson(id, dbupdated);
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





    //personTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createpersontranslation")]
    public IActionResult CreatepersonTranslation(PersonTranslationCreatedDTO persontranslation1)
    {
        var persontranslation = _mapper.Map<PersonTranslation>(persontranslation1);
        persontranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)persontranslation.language_id);
        int check = _repository.CreatePersonTranslation(persontranslation);

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
    [HttpGet("getallpersontranslation")]
    public IActionResult GetAllpersonTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonTranslation> persontranslationes1 = _repository.AllPersonTranslation(queryNum, pageNum, language_code);
        var persontranslationes = _mapper.Map<IEnumerable<PersonTranslationReadedDTO>>(persontranslationes1);
        if (persontranslationes == null) { }

        return Ok(persontranslationes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidpersontranslation/{uz_id}")]
    public IActionResult GetByIdpersonTranslation(int uz_id, string language_code)
    {
        PersonTranslation persontranslation1 = _repository.GetPersonTranslationById(uz_id, language_code);
        var persontranslation = _mapper.Map<PersonTranslationReadedDTO>(persontranslation1);
        if (persontranslation == null) { }
        return Ok(persontranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersontranslation/{id}")]
    public IActionResult GetByIdpersonTranslation(int id)
    {
        PersonTranslation persontranslation1 = _repository.GetPersonTranslationById(id);
        var persontranslation = _mapper.Map<PersonTranslationReadedDTO>(persontranslation1);
        if (persontranslation == null) { }
        return Ok(persontranslation);
    }

    [HttpGet("sitegetallpersontranslation")]
    public IActionResult GetAllpersonTranslationsite(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonTranslation> persontranslationes1 = _repository.AllPersonTranslationSite(queryNum, pageNum, language_code);
        var persontranslationes = _mapper.Map<IEnumerable<PersonTranslationReadedSiteDTO>>(persontranslationes1);
        if (persontranslationes == null) { }

        return Ok(persontranslationes);
    }

    [HttpGet("sitegetbyuzidpersontranslation/{uz_id}")]
    public IActionResult GetByIdpersonTranslationsite(int uz_id, string language_code)
    {
        PersonTranslation persontranslation1 = _repository.GetPersonTranslationByIdSite(uz_id, language_code);
        var persontranslation = _mapper.Map<PersonTranslationReadedSiteDTO>(persontranslation1);
        if (persontranslation == null) { }
        return Ok(persontranslation);
    }

    [HttpGet("sitegetbyidpersontranslation/{id}")]
    public IActionResult GetByIdpersonTranslationsite(int id)
    {
        PersonTranslation persontranslation1 = _repository.GetPersonTranslationByIdSite(id);
        var persontranslation = _mapper.Map<PersonTranslationReadedSiteDTO>(persontranslation1);
        if (persontranslation == null) { }
        return Ok(persontranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletepersontranslation/{id}")]
    public IActionResult DeletepersonTranslation(int id)
    {
        bool check = _repository.DeletePersonTranslation(id);
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
    [HttpPut("updatepersontranslation/{id}")]
    public IActionResult UpdatepersonTranslation(PersonTranslationUpdatedDTO persontranslation1, int id)
    {
        try
        {
            if (persontranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<PersonTranslation>(persontranslation1);



            bool updatedcheck = _repository.UpdatePersonTranslation(id, dbupdated);
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
