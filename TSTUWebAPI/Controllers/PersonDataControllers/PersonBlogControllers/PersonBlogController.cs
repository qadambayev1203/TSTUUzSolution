using Contracts.AllRepository.StatusesRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.PersonDataModel.PersonBlogModel;
using Entities.DTO.PersonDataDTOS.PersonBlogDTOS;
using Contracts.AllRepository.PersonsDataRepository.PersonBlogRepository;
using AutoMapper;
using Entities.Model.PersonDataModel;
using Entities.DTO.PersonDataDTOS;

namespace TSTUWebAPI.Controllers.PersonDataControllers.PersonBlogControllers;

[Route("api/personblog")]
[ApiController]
public class PersonBlogController : ControllerBase
{
    private readonly IPersonBlogRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public PersonBlogController(IPersonBlogRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }



    // PersonBlog CRUD

    [Authorize]
    [HttpPost("createpersonblog")]
    public IActionResult CreatePersonBlog(PersonBlogCreatedDTO blog)
    {
        var blogMap = _mapper.Map<PersonBlog>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonBlog(blogMap);

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
    [HttpPost("createpersonblogadmin")]
    public IActionResult CreatePersonBlogAdmin(PersonBlogCreatedAdminDTO blog)
    {
        var blogMap = _mapper.Map<PersonBlog>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonBlog(blogMap);

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
    [HttpGet("getallpersonblogadmin")]
    public IActionResult GetAllPersonBlog(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonBlog> personBlogsMap = _repository.AllPersonBlog(queryNum, pageNum, person_data_id, true);
        var personBlogs = _mapper.Map<IEnumerable<PersonBlogReadedDTO>>(personBlogsMap);
        return Ok(personBlogs);
    }

    [Authorize]
    [HttpGet("getallpersonblogprofil")]
    public IActionResult GetAllPersonBlogProfil(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonBlog> personBlogsMap = _repository.AllPersonBlog(queryNum, pageNum, 0, false);
        var personBlogs = _mapper.Map<IEnumerable<PersonBlogReadedProfilDTO>>(personBlogsMap);
        return Ok(personBlogs);
    }

    [HttpGet("getallpersonblogsite")]
    public IActionResult GetAllPersonBlogSite(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonBlog> personBlogsMap = _repository.AllPersonBlogSite(queryNum, pageNum, person_data_id);
        var personBlogs = _mapper.Map<IEnumerable<PersonBlogReadedSiteDTO>>(personBlogsMap);
        return Ok(personBlogs);
    }

    [Authorize]
    [HttpGet("getbyidpersonblogsite/{id}")]
    public IActionResult GetByIdPersonBlogSite(int id)
    {
        PersonBlog personBlogsMap = _repository.GetByIdPersonBlogSite(id);
        var personBlogs = _mapper.Map<PersonBlogReadedSiteDTO>(personBlogsMap);
        return Ok(personBlogs);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonblogadmin/{id}")]
    public IActionResult GetByIdPersonBlog(int id)
    {

        PersonBlog personBlogsMap = _repository.GetByIdPersonBlog(id, true);
        var personBlogs = _mapper.Map<PersonBlogReadedDTO>(personBlogsMap);
        return Ok(personBlogs);
    }

    [Authorize]
    [HttpGet("getbyidpersonblog/{id}")]
    public IActionResult GetByIdPersonBlogProfil(int id)
    {
        PersonBlog personBlogsMap = _repository.GetByIdPersonBlog(id, false);
        var personBlogs = _mapper.Map<PersonBlogReadedProfilDTO>(personBlogsMap);
        return Ok(personBlogs);
    }

    [Authorize]
    [HttpDelete("deletepersonblog/{id}")]
    public IActionResult DeletePersonBlog(int id)
    {
        bool check = _repository.DeletePersonBlog(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [Authorize]
    [HttpPut("updatepersonblog/{id}")]
    public IActionResult UpdatePersonBlog(PersonBlogUpdatedDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonBlog>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonBlog(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonblogadmin/{id}")]
    public IActionResult UpdatePersonBlogAdmin(PersonBlogUpdatedAdminDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonBlog>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonBlog(id, dbupdated, true);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }



    // PersonBlogTranslation CRUD

    [Authorize]
    [HttpPost("createpersonblogtranslation")]
    public IActionResult CreatePersonBlogTranslation(PersonBlogTranslationCreatedDTO blog)
    {
        var blogMap = _mapper.Map<PersonBlogTranslation>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonBlogTranslation(blogMap);

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
    [HttpPost("createpersonblogtranslationadmin")]
    public IActionResult CreatePersonBlogTranslationAdmin(PersonBlogTranslationCreatedAdminDTO blog)
    {
        var blogMap = _mapper.Map<PersonBlogTranslation>(blog);
        blogMap.status_id = _status.GetStatusId("Active");
        blogMap.crated_at = DateTime.UtcNow;

        int check = _repository.CreatePersonBlogTranslation(blogMap);

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
    [HttpGet("getallpersonblogtranslationadmin")]
    public IActionResult GetAllPersonBlogTranslation(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonBlogTranslation> personBlogsMap = _repository.AllPersonBlogTranslation(queryNum, pageNum, person_data_uz_id, true, language_code);
        var personBlogs = _mapper.Map<IEnumerable<PersonBlogTranslationReadedDTO>>(personBlogsMap);
        return Ok(personBlogs);
    }

    [Authorize]
    [HttpGet("getallpersonblogtranslationprofile")]
    public IActionResult GetAllPersonBlogTranslationProfile(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonBlogTranslation> personBlogsMap = _repository.AllPersonBlogTranslation(queryNum, pageNum, person_data_uz_id, false, language_code);
        var personBlogs = _mapper.Map<IEnumerable<PersonBlogTranslationReadedProfileDTO>>(personBlogsMap);
        return Ok(personBlogs);
    }

    [HttpGet("getallpersonblogtranslationsite")]
    public IActionResult GetAllPersonBlogTranslationSite(int queryNum, int pageNum, int person_data_uz_id, string language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonBlogTranslation> personBlogsMap = _repository.AllPersonBlogTranslationSite(queryNum, pageNum, person_data_uz_id, language_code);
        var personBlogs = _mapper.Map<IEnumerable<PersonBlogTranslationReadedSiteDTO>>(personBlogsMap);
        return Ok(personBlogs);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonblogtranslationadmin/{id}")]
    public IActionResult GetByIdPersonBlogTranslation(int id)
    {
        PersonBlogTranslation personScientificMap = _repository.GetByIdPersonBlogTranslation(id, true);
        var personScientific = _mapper.Map<PersonBlogTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidpersonblogtranslationadminuzid/{uz_id}")]
    public IActionResult GetByIdPersonBlogTranslation(int uz_id, string language_code)
    {
        PersonBlogTranslation personScientificMap = _repository.GetByIdPersonBlogTranslation(uz_id, language_code, true);
        var personScientific = _mapper.Map<PersonBlogTranslationReadedDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
    [HttpGet("getbyidpersonblogtranslation/{id}")]
    public IActionResult GetByIdPersonBlogTranslationProfil(int id)
    {
        PersonBlogTranslation personScientificMap = _repository.GetByIdPersonBlogTranslation(id, false);
        var personScientific = _mapper.Map<PersonBlogTranslationReadedProfileDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonblogtranslationsite/{id}")]
    public IActionResult GetByIdPersonBlogTranslationSite(int id)
    {
        PersonBlogTranslation personScientificMap = _repository.GetByIdPersonBlogTranslationSite(id);
        var personScientific = _mapper.Map<PersonBlogTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
    [HttpGet("getbyidpersonblogtranslationuzid/{uz_id}")]
    public IActionResult GetByIdPersonBlogTranslationProfil(int uz_id, string language_code)
    {
        PersonBlogTranslation personScientificMap = _repository.GetByIdPersonBlogTranslation(uz_id, language_code, false);
        var personScientific = _mapper.Map<PersonBlogTranslationReadedProfileDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [HttpGet("getbyidpersonblogtranslationuzidsite/{uz_id}")]
    public IActionResult GetByIdPersonBlogTranslationSite(int uz_id, string language_code)
    {
        PersonBlogTranslation personScientificMap = _repository.GetByIdPersonBlogTranslationSite(uz_id, language_code);
        var personScientific = _mapper.Map<PersonBlogTranslationReadedSiteDTO>(personScientificMap);
        return Ok(personScientific);
    }

    [Authorize]
    [HttpDelete("deletepersonblogtranslation/{id}")]
    public IActionResult DeletePersonBlogTranslation(int id)
    {
        bool check = _repository.DeletePersonBlogTranslation(id);

        if (!check)
        {
            return BadRequest();
        }

        return Ok("Deleted");
    }

    [Authorize]
    [HttpPut("updatepersonblogtranslation/{id}")]
    public IActionResult UpdatePersonBlogTranslation(PersonBlogTranslationUpdatedDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonBlogTranslation>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonBlogTranslation(id, dbupdated, false);

        if (!updatedcheck)
        {
            return BadRequest();
        }

        return Ok("Updated");


    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatepersonblogtranslationadmin/{id}")]
    public IActionResult UpdatePersonBlogTranslationAdmin(PersonBlogTranslationUpdatedAdminDTO blogUpdatedDTO, int id)
    {
        if (blogUpdatedDTO == null)
        {
            return BadRequest();
        }

        var dbupdated = _mapper.Map<PersonBlogTranslation>(blogUpdatedDTO);
        bool updatedcheck = _repository.UpdatePersonBlogTranslation(id, dbupdated, true);

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
        IEnumerable<PersonData> personsMap = _repository.AllPersonBlogCreated();
        var persons = _mapper.Map<IEnumerable<PersonDataSearchDTO>>(personsMap);
        return Ok(persons);
    }

    [Authorize(Roles = "HeadDepartment")]
    [HttpGet("getallpersonblogdep/{person_data_id}")]
    public IActionResult GetAllPersonBlogDep(int queryNum, int pageNum, int person_data_id)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<PersonBlog> personBlogsMap = _repository.AllPersonBlogDep(queryNum, pageNum, person_data_id);
        var personBlogs = _mapper.Map<IEnumerable<PersonBlogReadedSiteDTO>>(personBlogsMap);
        return Ok(personBlogs);
    }

    [Authorize(Roles = "HeadDepartment")]
    [HttpPost("confirmed/{person_blog_id}")]
    public IActionResult ConfirmAttribute(int person_blog_id, bool confirm)
    {
        var check = _repository.ConfirmDocumentTeacher110Set(person_blog_id, confirm);

        if (!check) return BadRequest();

        return Ok("Confirmed");
    }

}

