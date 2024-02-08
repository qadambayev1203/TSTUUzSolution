using AutoMapper;
using Contracts.AllRepository.GendersRepository;
using Entities.Model.GenderModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.GenderControllers
{
    [Route("api/gender")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository _repository;
        private readonly IMapper _mapper;
        public GenderController(IGenderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // gender CRUD

        [HttpPost("creategender")]
        public IActionResult Creategender(Gender gender)
        {

            bool check = _repository.CreateGender(gender);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", gender);
        }

        [HttpGet("getallgender")]
        public IActionResult GetAllgender()
        {

            IEnumerable<Gender> genderes = _repository.AllGender();

            return Ok(genderes);
        }

        [HttpGet("getbyidgender/{id}")]
        public IActionResult GetByIdgender(int id)
        {

            Gender gender = _repository.GetGenderById(id);

            return Ok(gender);
        }


        [HttpDelete("deletegender/{id}")]
        public IActionResult Deletegender(int id)
        {
            bool check = _repository.DeleteGender(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updategender/{id}")]
        public IActionResult Updategender(Gender gender, int id)
        {
            bool check = _repository.UpdateGender(id, gender);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }







        //genderTranslation CRUD
        [HttpPost("creategendertranslation")]
        public IActionResult CreategenderTranslation(GenderTranslation gendertranslation)
        {

            bool check = _repository.CreateGenderTranslation(gendertranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", gendertranslation);
        }

        [HttpGet("getallgendertranslation")]
        public IActionResult GetAllgenderTranslation()
        {

            IEnumerable<GenderTranslation> gendertranslationes = _repository.AllGenderTranslation();

            return Ok(gendertranslationes);
        }

        [HttpGet("getbyidgendertranslation/{id}")]
        public IActionResult GetByIdgenderTranslation(int id)
        {

            GenderTranslation gendertranslation = _repository.GetGenderTranslationById(id);

            return Ok(gendertranslation);
        }


        [HttpDelete("deletegendertranslation/{id}")]
        public IActionResult DeletegenderTranslation(int id)
        {
            bool check = _repository.DeleteGenderTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updategendertranslation/{id}")]
        public IActionResult UpdategenderTranslation(GenderTranslation gendertranslation, int id)
        {
            bool check = _repository.UpdateGenderTranslation(id, gendertranslation);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }
    }
}
