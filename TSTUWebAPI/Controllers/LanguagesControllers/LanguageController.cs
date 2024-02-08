using AutoMapper;
using Contracts.AllRepository.LanguagesRepository;
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
        public IActionResult Createlanguage(Language language)
        {

            bool check = _repository.CreateLanguage(language);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", language);
        }

        [HttpGet("getalllanguage")]
        public IActionResult GetAlllanguage()
        {

            IEnumerable<Language> languagees = _repository.AllLanguage();

            return Ok(languagees);
        }

        [HttpGet("getbyidlanguage/{id}")]
        public IActionResult GetByIdlanguage(int id)
        {

            Language language = _repository.GetLanguageById(id);

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
        public IActionResult Updatelanguage(Language language, int id)
        {
            bool check = _repository.UpdateLanguage(id, language);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }






    }
}
