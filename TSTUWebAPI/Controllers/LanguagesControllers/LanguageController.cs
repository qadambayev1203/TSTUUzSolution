using AutoMapper;
using Contracts.AllRepository.LanguagesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.LanguageDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.LanguagesControllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;


        public LanguageController(ILanguageRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // language CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createlanguage")]
        public IActionResult Createlanguage(LanguageCreatedDTO language1)
        {
            var language = _mapper.Map<Language>(language1);

            language.status_id = _status.GetStatusId("Active");

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(language1.img_upload);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                language.img_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }

            int check = _repository.CreateLanguage(language);

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
        [HttpGet("getalllanguage")]
        public IActionResult GetAlllanguage(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Language> languages1 = _repository.AllLanguage(queryNum, pageNum);
            var languages = _mapper.Map<IEnumerable<LanguageReadedDTO>>(languages1);
            if (languages == null) { }

            return Ok(languages);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidlanguage/{id}")]
        public IActionResult GetByIdlanguage(int id)
        {

            Language language1 = _repository.GetLanguageById(id);
            var language = _mapper.Map<LanguageReadedDTO>(language1);
            if (language == null) { }

            return Ok(language);
        }

        [HttpGet("sitegetalllanguage")]
        public IActionResult GetAlllanguagesite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Language> languages1 = _repository.AllLanguageSite(queryNum, pageNum);
            var languages = _mapper.Map<IEnumerable<LanguageReadedSiteDTO>>(languages1);
            if (languages == null) { }

            return Ok(languages);
        }

        [HttpGet("sitegetbyidlanguage/{id}")]
        public IActionResult GetByIdlanguagesite(int id)
        {

            Language language1 = _repository.GetLanguageByIdSite(id);
            var language = _mapper.Map<LanguageReadedSiteDTO>(language1);
            if (language == null) { }

            return Ok(language);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletelanguage/{id}")]
        public IActionResult Deletelanguage(int id)
        {
            bool check = _repository.DeleteLanguage(id);
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
        [HttpPut("updatelanguage/{id}")]
        public IActionResult Updatelanguage(LanguageUpdatedDTO language1, int id)
        {
            try
            {
                if (language1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<Language>(language1);

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(language1.img_upload);
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

                bool updatedcheck = _repository.UpdateLanguage(id, dbupdated);
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
}
