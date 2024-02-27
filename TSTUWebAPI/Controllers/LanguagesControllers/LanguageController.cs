using AutoMapper;
using Contracts.AllRepository.LanguagesRepository;
using Entities.DTO.LanguageDTOS;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.LanguagesControllers
{
    [Route("api/language")]
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

        [HttpPost("createlanguage")]
        public IActionResult Createlanguage(LanguageCreatedDTO language1)
        {
            var language = _mapper.Map<Language>(language1);
            bool check = _repository.CreateLanguage(language);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getalllanguage")]
        public IActionResult GetAlllanguage(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Language> languages1 = _repository.AllLanguage(queryNum, pageNum);
            var languages = _mapper.Map<IEnumerable<LanguageReadedDTO>>(languages1);
            if (languages == null) { return NotFound(); }

            return Ok(languages);
        }

        [HttpGet("getbyidlanguage/{id}")]
        public IActionResult GetByIdlanguage(int id)
        {

            Language language1= _repository.GetLanguageById(id);
            var language = _mapper.Map<LanguageReadedDTO>(language1);
            if (language == null) { return NotFound(); }

            return Ok(language);
        }


        [HttpDelete("deletelanguage/{id}")]
        public IActionResult Deletelanguage(int id)
        {
            bool check = _repository.DeleteLanguage(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatelanguage/{id}")]
        public IActionResult Updatelanguage(LanguageUpdatedDTO language1, int id)
        {
            try
            {
                var language = _repository.GetLanguageById(id);
                if (language == null)
                {
                    return NotFound();
                }
                _mapper.Map(language1, language);
                bool check = _repository.UpdateLanguage();
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
