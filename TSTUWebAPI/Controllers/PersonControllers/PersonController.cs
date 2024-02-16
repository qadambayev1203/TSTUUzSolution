using AutoMapper;
using Contracts.AllRepository.PersonsRepository;
using Entities.DTO.PersonDTOS;
using Entities.Model.PagesModel;
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
        public IActionResult GetAllperson(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Person> persons1 = _repository.AllPerson(queryNum, pageNum);
            var persons = _mapper.Map<IEnumerable<PersonReadedDTO>>(persons1);
            if (persons == null) { return NotFound(); }

            return Ok(persons);
        }

        [HttpGet("getbyidperson/{id}")]
        public IActionResult GetByIdperson(int id)
        {

            Person person1 = _repository.GetPersonById(id);
            var person = _mapper.Map<PersonReadedDTO>(person1);
            if (person == null) { return NotFound(); }
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
                person.updated_at = DateTime.UtcNow;
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
        public IActionResult GetAllpersonTranslation(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PersonTranslation> persontranslationes1 = _repository.AllPersonTranslation(queryNum, pageNum);
            var persontranslationes = _mapper.Map<IEnumerable<PersonTranslationReadedDTO>>(persontranslationes1);
            if (persontranslationes == null) { return NotFound(); }

            return Ok(persontranslationes);
        }

        [HttpGet("getbyidpersontranslation/{id}")]
        public IActionResult GetByIdpersonTranslation(int id)
        {
            PersonTranslation persontranslation1 = _repository.GetPersonTranslationById(id);
            var persontranslation = _mapper.Map<PersonTranslationReadedDTO>(persontranslation1);
            if (persontranslation == null) { return NotFound(); }
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
