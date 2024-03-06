using AutoMapper;
using Contracts.AllRepository.LanguagesRepository;
using Entities.DTO.LanguageDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.LanguagesControllers
{
    [Route("api/language")]
    [Authorize]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _repository;
        private readonly IMapper _mapper;
        public LanguageController(ILanguageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // language CRUD

        [Authorize(Roles="Admin")]       [HttpPost("createlanguage")]
        public IActionResult Createlanguage(LanguageCreatedDTO language1)
        {
            var language = _mapper.Map<Language>(language1);
            int check = _repository.CreateLanguage(language);

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

        [Authorize(Roles="Admin")]       [HttpGet("getalllanguage")]
        public IActionResult GetAlllanguage(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Language> languages1 = _repository.AllLanguage(queryNum, pageNum);
            var languages = _mapper.Map<IEnumerable<LanguageReadedDTO>>(languages1);
            if (languages == null || languages.Count() == 0) { return NotFound(); }

            return Ok(languages);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidlanguage/{id}")]
        public IActionResult GetByIdlanguage(int id)
        {

            Language language1 = _repository.GetLanguageById(id);
            var language = _mapper.Map<LanguageReadedDTO>(language1);
            if (language == null) { return NotFound(); }

            return Ok(language);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deletelanguage/{id}")]
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



        [Authorize(Roles="Admin")]       [HttpPut("updatelanguage/{id}")]
        public IActionResult Updatelanguage(LanguageUpdatedDTO language1, int id)
        {
            try
            {
                var language = _repository.GetLanguageById(id);
                if (language == null || language1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(language1, language);
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
