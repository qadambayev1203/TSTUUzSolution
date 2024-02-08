using AutoMapper;
using Contracts.AllRepository.PersonsRepository;
using Entities.Model.PersonModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.PersonControllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        public PersonController(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // person CRUD

        [HttpPost("createperson")]
        public IActionResult Createperson(Person person)
        {

            bool check = _repository.CreatePerson(person);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", person);
        }

        [HttpGet("getallperson")]
        public IActionResult GetAllperson()
        {

            IEnumerable<Person> persones = _repository.AllPerson();

            return Ok(persones);
        }

        [HttpGet("getbyidperson/{id}")]
        public IActionResult GetByIdperson(int id)
        {

            Person person = _repository.GetPersonById(id);

            return Ok(person);
        }


        [HttpDelete("deleteperson/{id}")]
        public IActionResult Deleteperson(int id)
        {
            bool check = _repository.DeletePerson(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updateperson/{id}")]
        public IActionResult Updateperson(Person person, int id)
        {
            bool check = _repository.UpdatePerson(id, person);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }







        //personTranslation CRUD
        [HttpPost("createpersontranslation")]
        public IActionResult CreatepersonTranslation(PersonTranslation persontranslation)
        {

            bool check = _repository.CreatePersonTranslation(persontranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", persontranslation);
        }

        [HttpGet("getallpersontranslation")]
        public IActionResult GetAllpersonTranslation()
        {

            IEnumerable<PersonTranslation> persontranslationes = _repository.AllPersonTranslation();

            return Ok(persontranslationes);
        }

        [HttpGet("getbyidpersontranslation/{id}")]
        public IActionResult GetByIdpersonTranslation(int id)
        {

            PersonTranslation persontranslation = _repository.GetPersonTranslationById(id);

            return Ok(persontranslation);
        }


        [HttpDelete("deletepersontranslation/{id}")]
        public IActionResult DeletepersonTranslation(int id)
        {
            bool check = _repository.DeletePersonTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatepersontranslation/{id}")]
        public IActionResult UpdatepersonTranslation(PersonTranslation persontranslation, int id)
        {
            bool check = _repository.UpdatePersonTranslation(id, persontranslation);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }
    }
}
