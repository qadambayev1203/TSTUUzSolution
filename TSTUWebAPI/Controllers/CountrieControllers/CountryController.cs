using AutoMapper;
using Contracts.AllRepository.CountriesRepository;
using Entities.DTO.CountrysDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.CountrysModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.CountrieControllers
{
    [Route("api/country")]
    [Authorize]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Country CRUD

        [Authorize(Roles="Admin")]       [HttpPost("createcountry")]
        public IActionResult CreateCountry(CountryCreatedDTO Country1)
        {
            var Country = _mapper.Map<Country>(Country1);
            int id = _repository.CreateCountry(Country);

            if (id == 0)
            {
                return BadRequest();
            }

            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = id,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getallcountry")]
        public IActionResult GetAllCountry()
        {
            IEnumerable<Country> Countrys1 = _repository.AllCountry();
            var Countrys = _mapper.Map<IEnumerable<CountryReadedDTO>>(Countrys1);
            if (Countrys == null || Countrys.Count() == 0) { return NotFound(); }

            return Ok(Countrys);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidcountry/{id}")]
        public IActionResult GetByIdCountry(int id)
        {

            Country Country1 = _repository.GetCountryById(id);
            if (Country1 == null)
            {
                return NotFound();
            }
            var Country = _mapper.Map<CountryReadedDTO>(Country1);
            if (Country == null) { return NotFound(); }
            return Ok(Country);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteCountry/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            bool check = _repository.DeleteCountry(id);
            if (!check)
            {
                return BadRequest();
            }bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [Authorize(Roles="Admin")]       [HttpPut("updatecountry/{id}")]
        public IActionResult UpdateCountry(CountryUpdatedDTO Country1, int id)
        {
            try
            {
                var Countrycheck = _repository.GetCountryById(id);
                if (Countrycheck == null || Country1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Country1, Countrycheck);
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







        //CountryTranslation CRUD
        [Authorize(Roles="Admin")]       [HttpPost("createcountrytranslation")]
        public IActionResult CreateCountryTranslation(CountryTranslationCreatedDTO Countrytranslation1)
        {
            var Countrytranslation = _mapper.Map<CountryTranslation>(Countrytranslation1);
            int id = _repository.CreateCountryTranslation(Countrytranslation);
            if (id == 0)
            {
                return BadRequest();
            }

            if (id == 0)
            {
                return BadRequest();
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = id,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getallcountrytranslation")]
        public IActionResult GetAllCountryTranslation(string language_code)
        {
            IEnumerable<CountryTranslation> Countrytranslations1 = _repository.AllCountryTranslation(language_code);
            var Countrytranslations = _mapper.Map<IEnumerable<CountryTranslationReadedDTO>>(Countrytranslations1);
            if (Countrytranslations == null || Countrytranslations.Count() == 0) { return NotFound(); }

            return Ok(Countrytranslations);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidcountrytranslation/{id}")]
        public IActionResult GetByIdCountryTranslation(int id)
        {

            CountryTranslation Countrytranslation1 = _repository.GetCountryTranslationById(id);
            var Countrytranslation = _mapper.Map<CountryTranslationReadedDTO>(Countrytranslation1);
            if (Countrytranslation == null) { return NotFound(); }

            return Ok(Countrytranslation);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteCountrytranslation/{id}")]
        public IActionResult DeleteCountryTranslation(int id)
        {
            bool check = _repository.DeleteCountryTranslation(id);
            if (!check)
            {
                return BadRequest();
            } bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [Authorize(Roles="Admin")]       [HttpPut("updatecountrytranslation/{id}")]
        public IActionResult UpdateCountryTranslation(CountryTranslationUpdatedDTO Countrytranslation1, int id)
        {
            try
            {
                var Countrytranslationch = _repository.GetCountryTranslationById(id);
                if (Countrytranslationch == null || Countrytranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Countrytranslation1, Countrytranslationch);
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
