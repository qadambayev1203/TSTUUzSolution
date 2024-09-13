using AutoMapper;
using Contracts.AllRepository.RectorGivensUpdatedRepository;
using Entities.DTO.DepartamentDTOS;
using Entities.DTO.PersonDataDTOS;
using Entities.DTO.RectorGivenDTOS;
using Entities.DTO.UserCrudDTOS;
using Entities.Model.AnyClasses;
using Entities.Model;
using Entities.Model.DepartamentsModel;
using Entities.Model.FileModel;
using Entities.Model.PersonDataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.RectorUpdatedControllers;

[Authorize(Roles = "Admin,ModeratorContent")]
[Route("api/[controller]")]
[ApiController]
public class RectorGivenUpdatedController : ControllerBase
{
    private readonly IRectorGivenUpdatedRepository _repository;
    private readonly IMapper _mapper;

    public RectorGivenUpdatedController(IRectorGivenUpdatedRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // Departament
  
    [HttpGet("getrectorgiven")]
    public IActionResult GetByIdRectorGiven()
    {
        Departament departament1 = _repository.GetRectorGiven();
        var departament = _mapper.Map<RectorGivenGetDTO>(departament1);
        return Ok(departament);
    }

  
    [HttpPut("updaterectorgiven")]
    public IActionResult UpdateRectorGiven(RectorGivenUpdateDTO rectorGivenUpdate)
    {

        try
        {
            RectorGivenUpdateDTO departament1 = rectorGivenUpdate;
            if (departament1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<Departament>(departament1);


            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(departament1.img_up);
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

            var Url1 = fileUpload.SaveFileAsync(departament1.img_icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                dbupdated.img_icon_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            bool updatedcheck = _repository.UpdateRectorGiven(dbupdated);

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


  
    [HttpGet("getrectorgiventranslation/{language_code}")]
    public IActionResult GetByIdRectorGivenTranslation(string language_code)
    {
        DepartamentTranslation departament1 = _repository.GetRectorGivenTranslation(language_code);
        var departament = _mapper.Map<RectorGivenTranslationGetDTO>(departament1);
        return Ok(departament);
    }

  
    [HttpPut("updaterectorgiventranslation/{language_code}")]
    public IActionResult UpdateRectorGivenTranslation(RectorGivenTranslationUpdateDTO rectorGivenUpdateDTO, string language_code)
    {

        try
        {
            RectorGivenTranslationUpdateDTO departamenttranslation1 = rectorGivenUpdateDTO;

            if (departamenttranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<DepartamentTranslation>(departamenttranslation1);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(departamenttranslation1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                dbupdated.img_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }

            var Url1 = fileUpload.SaveFileAsync(departamenttranslation1.img_icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                dbupdated.img_icon_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            bool updatedcheck = _repository.UpdateRectorGivenTranslation(dbupdated, language_code);
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

    // PersonData

  
    [HttpGet("getbyrectordata")]
    public IActionResult GetByRectorData()
    {
        PersonData personData1 = _repository.GetRectorData();
        var personData = _mapper.Map<RectorDataGetDTO>(personData1);
        return Ok(personData);
    }

  
    [HttpPut("updaterectordata/{id}")]
    public IActionResult UpdateRectorData(RectorDataUpdateDTO rectorDataUpdate)
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

            bool updatedcheck = _repository.UpdateRectorData(dbupdated);
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

  
    [HttpGet("getbyrectordatatranslation/{language_code}")]
    public IActionResult GetByIdpersonDataTranslation(string language_code)
    {
        PersonDataTranslation personDatatranslation1 = _repository.GetRectorDataTranslation(language_code);
        var personDatatranslation = _mapper.Map<RectorDataTranslationReadedDTO>(personDatatranslation1);
        return Ok(personDatatranslation);
    }

  
    [HttpPut("updatepersondatatranslation/{language_code}")]
    public IActionResult UpdatepersonDataTranslation(RectorDataTranslationUpdatedDTO rectorDataTranslation, string language_code)
    {
        try
        {
            RectorDataTranslationUpdatedDTO personDatatranslation1 = rectorDataTranslation;

            if (personDatatranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<PersonDataTranslation>(personDatatranslation1);
            bool updatedcheck = _repository.UpdateRectorDataTranslation(dbupdated, language_code);
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
