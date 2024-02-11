using AutoMapper;
using Contracts.AllRepository.PersonsRepository;
using Entities.DTO.GenderDTOS;
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
        public IActionResult Createperson(PersonCreatedDTO person1)
        {
            var person = _mapper.Map<Person>(person1);
            bool check = _repository.CreatePerson(person);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallperson")]
        public IActionResult GetAllperson()
        {

            IEnumerable<Person> persons1 = _repository.AllPerson();
            var persons = _mapper.Map<IEnumerable<PersonReadedDTO>>(persons1);
            return Ok(persons);
        }

        [HttpGet("getbyidperson/{id}")]
        public IActionResult GetByIdperson(int id)
        {

            Person person1 = _repository.GetPersonById(id);
            var person = _mapper.Map<PersonReadedDTO>(person1);
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
        public IActionResult Updateperson(PersonUpdatedDTO person1, int id)
        {
            try
            {
                var person = _repository.GetPersonById(id);
                if (person == null)
                {
                    return NotFound();
                }
                _mapper.Map(person1, person);
                bool check = _repository.UpdatePerson();
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







        //personTranslation CRUD
        [HttpPost("createpersontranslation")]
        public IActionResult CreatepersonTranslation(PersonTranslationCreatedDTO persontranslation1)
        {
            var persontranslation = _mapper.Map<PersonTranslation>(persontranslation1);
            bool check = _repository.CreatePersonTranslation(persontranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallpersontranslation")]
        public IActionResult GetAllpersonTranslation()
        {

            IEnumerable<PersonTranslation> persontranslationes1 = _repository.AllPersonTranslation();
            var persontranslationes = _mapper.Map<IEnumerable<PersonTranslationReadedDTO>>(persontranslationes1);
            return Ok(persontranslationes);
        }

        [HttpGet("getbyidpersontranslation/{id}")]
        public IActionResult GetByIdpersonTranslation(int id)
        {
            PersonTranslation persontranslation1 = _repository.GetPersonTranslationById(id);
            var persontranslation = _mapper.Map<PersonTranslationReadedDTO>(persontranslation1);
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
        public IActionResult UpdatepersonTranslation(PersonTranslation persontranslation1, int id)
        {
            try
            {
                var persontranslation = _repository.GetPersonTranslationById(id);
                if (persontranslation == null)
                {
                    return NotFound();
                }
                _mapper.Map(persontranslation1, persontranslation);
                bool check = _repository.UpdatePersonTranslation();
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
