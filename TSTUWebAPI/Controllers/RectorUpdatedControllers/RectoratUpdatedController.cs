using AutoMapper;
using Contracts.AllRepository.RectorGivensUpdatedRepository;
using Entities.DTO.RectorGivenDTOS;
using Entities.Model.FileModel;
using Entities.Model.PersonDataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.RectorUpdatedControllers;

[Authorize(Roles = "Admin,ModeratorContent")]
[Route("api/rectoratupdated")]
[ApiController]
public class RectoratUpdatedController : ControllerBase
{
    private readonly IRectorGivenUpdatedRepository _repository;
    private readonly IMapper _mapper;

    public RectoratUpdatedController(IRectorGivenUpdatedRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // PersonData


    [HttpGet("getbyrectoratdata")]
    public IActionResult GetByRectoratData()
    {
        List<PersonData> personData1 = _repository.GetRectoratData();
        var personData = _mapper.Map<List<RectorDataGetAllDTO>>(personData1);
        return Ok(personData);
    }

    [HttpGet("getbyidrectoratdata/{id}")]
    public IActionResult GetByIdRectoratData(int id)
    {
        PersonData personData1 = _repository.GetByIdRectoratData(id);
        var personData = _mapper.Map<RectorDataGetDTO>(personData1);
        return Ok(personData);
    }

    [HttpPut("updaterectoratdata/{id}")]
    public IActionResult UpdateRectoratData(RectorDataUpdateDTO rectorDataUpdate, int id)
    {
        try
        {
            RectorDataUpdateDTO personData1 = rectorDataUpdate;

            if (personData1 == null)
            {
                return BadRequest();
            }
            var dbupdated = _mapper.Map<PersonData>(personData1);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(personData1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                dbupdated.persons_.img_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }

            bool updatedcheck = _repository.UpdateRectorData(dbupdated, id);
            if (!updatedcheck)
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





    //[HttpGet("getbyrectoratdatatranslation/{language_code}")]
    //public IActionResult GetByIdRectoratDataTranslation(string language_code)
    //{
    //    List<PersonDataTranslation> personDatatranslation1 = _repository.GetRectoratDataTranslation(language_code);
    //    var personDatatranslation = _mapper.Map<List<RectorDataTranslationReadedDTO>>(personDatatranslation1);
    //    return Ok(personDatatranslation);
    //}

    [HttpGet("getbyidrectoratdatatranslation/{uz_id}")]
    public IActionResult GetByIdRectoratDataTranslation(int uz_id, string language_code)
    {
        PersonDataTranslation personDatatranslation1 = _repository.GetByIdRectoratDataTranslation(uz_id, language_code);
        var personDatatranslation = _mapper.Map<RectorDataTranslationReadedDTO>(personDatatranslation1);
        return Ok(personDatatranslation);
    }


    [HttpPut("updatepersondatatranslation/{id}")]
    public IActionResult UpdatepersonDataTranslation(RectorDataTranslationUpdatedDTO rectorDataTranslation, int id)
    {
        try
        {
            RectorDataTranslationUpdatedDTO personDatatranslation1 = rectorDataTranslation;

            if (personDatatranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<PersonDataTranslation>(personDatatranslation1);
            bool updatedcheck = _repository.UpdateRectoratDataTranslation(dbupdated, id);
            if (!updatedcheck)
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
