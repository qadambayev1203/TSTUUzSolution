using AutoMapper;
using Contracts.AllRepository.StatisticalNumbersRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.StatisticalNumbersDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Entities.Model.StatisticalNumbersModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.StatisticalNumbersControllers;

[Route("api/statisticalnumbers")]
[ApiController]
public class StatisticalNumbersController : ControllerBase
{
    private readonly IStatisticalNumbersRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public StatisticalNumbersController(IStatisticalNumbersRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // StatisticalNumbers CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createstatisticalnumbers")]
    public IActionResult CreateStatisticalNumbers(StatisticalNumbersCreatedDTO StatisticalNumbers1)
    {
        var StatisticalNumbers = _mapper.Map<StatisticalNumbers>(StatisticalNumbers1);
        StatisticalNumbers.status_id = _status.GetStatusId("Active");


        FileUploadRepository fileUpload = new FileUploadRepository();

        var Url1 = fileUpload.SaveFileAsync(StatisticalNumbers1.icon_up);
        if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
        {
            return BadRequest("File created error!");
        }
        if (Url1 != null && Url1.Length > 0)
        {
            StatisticalNumbers.icon_ = new Files
            {
                title = Guid.NewGuid().ToString(),
                url = Url1
            };
        }

        int id = _repository.CreateStatisticalNumbers(StatisticalNumbers);

        if (id == 0)
        {
            fileUpload.DeleteFileAsync(Url1);
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
    [HttpGet("getallstatisticalnumbers")]
    public IActionResult GetAllStatisticalNumbers(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<StatisticalNumbers> StatisticalNumberss1 = _repository.AllStatisticalNumbers(queryNum, pageNum);
        var StatisticalNumberss = _mapper.Map<IEnumerable<StatisticalNumbersReadedDTO>>(StatisticalNumberss1);
        if (StatisticalNumberss == null) { }

        return Ok(StatisticalNumberss);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidstatisticalnumbers/{id}")]
    public IActionResult GetByIdStatisticalNumbers(int id)
    {

        StatisticalNumbers StatisticalNumbers1 = _repository.GetStatisticalNumbersById(id);
        if (StatisticalNumbers1 == null)
        {

        }
        var StatisticalNumbers = _mapper.Map<StatisticalNumbersReadedDTO>(StatisticalNumbers1);
        if (StatisticalNumbers == null) { }
        return Ok(StatisticalNumbers);
    }

    [HttpGet("sitegetallstatisticalnumbers")]
    public IActionResult GetAllStatisticalNumberssite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<StatisticalNumbers> StatisticalNumberss1 = _repository.AllStatisticalNumbersSite(queryNum, pageNum);
        var StatisticalNumberss = _mapper.Map<IEnumerable<StatisticalNumbersReadedSiteDTO>>(StatisticalNumberss1);
        if (StatisticalNumberss == null) { }

        return Ok(StatisticalNumberss);
    }

    [HttpGet("sitegetbyidstatisticalnumbers/{id}")]
    public IActionResult GetByIdStatisticalNumberssite(int id)
    {

        StatisticalNumbers StatisticalNumbers1 = _repository.GetStatisticalNumbersByIdSite(id);
        if (StatisticalNumbers1 == null)
        {

        }
        var StatisticalNumbers = _mapper.Map<StatisticalNumbersReadedSiteDTO>(StatisticalNumbers1);
        if (StatisticalNumbers == null) { }
        return Ok(StatisticalNumbers);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletestatisticalnumbers/{id}")]
    public IActionResult DeleteStatisticalNumbers(int id)
    {
        bool check = _repository.DeleteStatisticalNumbers(id);
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
    [HttpPut("updatestatisticalnumbers/{id}")]
    public IActionResult UpdateStatisticalNumbers(StatisticalNumbersUpdatedDTO StatisticalNumbers1, int id)
    {
        try
        {
            if (StatisticalNumbers1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<StatisticalNumbers>(StatisticalNumbers1);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url1 = fileUpload.SaveFileAsync(StatisticalNumbers1.icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                dbupdated.icon_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            bool updatedcheck = _repository.UpdateStatisticalNumbers(id, dbupdated);
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







    //StatisticalNumbersTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createstatisticalnumberstranslation")]
    public IActionResult CreateStatisticalNumbersTranslation(StatisticalNumbersTranslationCreatedDTO StatisticalNumberstranslation1)
    {
        var StatisticalNumberstranslation = _mapper.Map<StatisticalNumbersTranslation>(StatisticalNumberstranslation1);
        StatisticalNumberstranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)StatisticalNumberstranslation.language_id);


        FileUploadRepository fileUpload = new FileUploadRepository();

        var Url1 = fileUpload.SaveFileAsync(StatisticalNumberstranslation1.icon_up);
        if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
        {
            return BadRequest("File created error!");
        }
        if (Url1 != null && Url1.Length > 0)
        {
            StatisticalNumberstranslation.icon_ = new FilesTranslation
            {
                title = Guid.NewGuid().ToString(),
                url = Url1
            };
        }

        int id = _repository.CreateStatisticalNumbersTranslation(StatisticalNumberstranslation);
        if (id == 0)
        {
            fileUpload.DeleteFileAsync(Url1);
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
    [HttpGet("getallstatisticalnumberstranslation")]
    public IActionResult GetAllStatisticalNumbersTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<StatisticalNumbersTranslation> StatisticalNumberstranslations1 = _repository.AllStatisticalNumbersTranslation(queryNum, pageNum, language_code);
        var StatisticalNumberstranslations = _mapper.Map<IEnumerable<StatisticalNumbersTranslationReadedDTO>>(StatisticalNumberstranslations1);
        if (StatisticalNumberstranslations == null) { }

        return Ok(StatisticalNumberstranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidstatisticalnumberstranslation/{uz_id}")]
    public IActionResult GetByIdStatisticalNumbersTranslation(int uz_id, string language_code)
    {

        StatisticalNumbersTranslation StatisticalNumberstranslation1 = _repository.GetStatisticalNumbersTranslationById(uz_id, language_code);
        var StatisticalNumberstranslation = _mapper.Map<StatisticalNumbersTranslationReadedDTO>(StatisticalNumberstranslation1);
        if (StatisticalNumberstranslation == null) { }

        return Ok(StatisticalNumberstranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidstatisticalnumberstranslation/{id}")]
    public IActionResult GetByIdStatisticalNumbersTranslation(int id)
    {

        StatisticalNumbersTranslation StatisticalNumberstranslation1 = _repository.GetStatisticalNumbersTranslationById(id);
        var StatisticalNumberstranslation = _mapper.Map<StatisticalNumbersTranslationReadedDTO>(StatisticalNumberstranslation1);
        if (StatisticalNumberstranslation == null) { }

        return Ok(StatisticalNumberstranslation);
    }

    [HttpGet("sitegetallstatisticalnumberstranslation")]
    public IActionResult GetAllStatisticalNumbersTranslationsite(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<StatisticalNumbersTranslation> StatisticalNumberstranslations1 = _repository.AllStatisticalNumbersTranslationSite(queryNum, pageNum, language_code);
        var StatisticalNumberstranslations = _mapper.Map<IEnumerable<StatisticalNumbersTranslationReadedSiteDTO>>(StatisticalNumberstranslations1);
        if (StatisticalNumberstranslations == null) { }

        return Ok(StatisticalNumberstranslations);
    }

    [HttpGet("sitegetbyuzidstatisticalnumberstranslation/{uz_id}")]
    public IActionResult GetByIdStatisticalNumbersTranslationsite(int uz_id, string language_code)
    {

        StatisticalNumbersTranslation StatisticalNumberstranslation1 = _repository.GetStatisticalNumbersTranslationByIdSite(uz_id, language_code);
        var StatisticalNumberstranslation = _mapper.Map<StatisticalNumbersTranslationReadedSiteDTO>(StatisticalNumberstranslation1);
        if (StatisticalNumberstranslation == null) { }

        return Ok(StatisticalNumberstranslation);
    }

    [HttpGet("sitegetbyidstatisticalnumberstranslation/{id}")]
    public IActionResult GetByIdStatisticalNumbersTranslationsite(int id)
    {

        StatisticalNumbersTranslation StatisticalNumberstranslation1 = _repository.GetStatisticalNumbersTranslationByIdSite(id);
        var StatisticalNumberstranslation = _mapper.Map<StatisticalNumbersTranslationReadedSiteDTO>(StatisticalNumberstranslation1);
        if (StatisticalNumberstranslation == null) { }

        return Ok(StatisticalNumberstranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletestatisticalnumberstranslation/{id}")]
    public IActionResult DeleteStatisticalNumbersTranslation(int id)
    {
        bool check = _repository.DeleteStatisticalNumbersTranslation(id);
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
    [HttpPut("updatestatisticalnumberstranslation/{id}")]
    public IActionResult UpdateStatisticalNumbersTranslation(StatisticalNumbersTranslationUpdatedDTO StatisticalNumberstranslation1, int id)
    {
        try
        {
            if (StatisticalNumberstranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<StatisticalNumbersTranslation>(StatisticalNumberstranslation1);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url1 = fileUpload.SaveFileAsync(StatisticalNumberstranslation1.icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                dbupdated.icon_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            bool updatedcheck = _repository.UpdateStatisticalNumbersTranslation(id, dbupdated);
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
