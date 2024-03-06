using AutoMapper;
using Contracts.AllRepository.DistrictsRepository;
using Entities.DTO.DistrictsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DistrictsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DistrictControllers
{
    [Route("api/district")]
    [Authorize]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepository _repository;
        private readonly IMapper _mapper;
        public DistrictController(IDistrictRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // District CRUD

      [Authorize(Roles="Admin")]       [HttpPost("createdistrict")]
        public IActionResult CreateDistrict(DistrictCreatedDTO District1)
        {
            var District = _mapper.Map<District>(District1);
            int id = _repository.CreateDistrict(District);

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

      [Authorize(Roles="Admin")]       [HttpGet("getalldistrict")]
        public IActionResult GetAllDistrict(int territorie_id)
        {
            IEnumerable<District> Districts1 = _repository.AllDistrict(territorie_id);
            var Districts = _mapper.Map<IEnumerable<DistrictReadedDTO>>(Districts1);
            if (Districts == null || Districts.Count() == 0) { return NotFound(); }

            return Ok(Districts);
        }

      [Authorize(Roles="Admin")]       [HttpGet("getbyiddistrict/{id}")]
        public IActionResult GetByIdDistrict(int id)
        {

            District District1 = _repository.GetDistrictById(id);
            if (District1 == null)
            {
                return NotFound();
            }
            var District = _mapper.Map<DistrictReadedDTO>(District1);
            if (District == null) { return NotFound(); }
            return Ok(District);
        }


      [Authorize(Roles="Admin")]       [HttpDelete("deleteDistrict/{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            bool check = _repository.DeleteDistrict(id);
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



      [Authorize(Roles="Admin")]       [HttpPut("updatedistrict/{id}")]
        public IActionResult UpdateDistrict(DistrictUpdatedDTO District1, int id)
        {
            try
            {
                var Districtcheck = _repository.GetDistrictById(id);
                if (Districtcheck == null || District1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(District1, Districtcheck);
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







        //DistrictTranslation CRUD
      [Authorize(Roles="Admin")]       [HttpPost("createdistricttranslation")]
        public IActionResult CreateDistrictTranslation(DistrictTranslationCreatedDTO Districttranslation1)
        {
            var Districttranslation = _mapper.Map<DistrictTranslation>(Districttranslation1);
            int id = _repository.CreateDistrictTranslation(Districttranslation);
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

      [Authorize(Roles="Admin")]       [HttpGet("getalldistricttranslation")]
        public IActionResult GetAllDistrictTranslation(int territorie_translation_id, string? language_code)
        {
            IEnumerable<DistrictTranslation> Districttranslations1 = _repository.AllDistrictTranslation(territorie_translation_id, language_code);
            var Districttranslations = _mapper.Map<IEnumerable<DistrictTranslationReadedDTO>>(Districttranslations1);
            if (Districttranslations == null || Districttranslations.Count() == 0) { return NotFound(); }

            return Ok(Districttranslations);
        }

      [Authorize(Roles="Admin")]       [HttpGet("getbyiddistricttranslation/{id}")]
        public IActionResult GetByIdDistrictTranslation(int id)
        {

            DistrictTranslation Districttranslation1 = _repository.GetDistrictTranslationById(id);
            var Districttranslation = _mapper.Map<DistrictTranslationReadedDTO>(Districttranslation1);
            if (Districttranslation == null) { return NotFound(); }

            return Ok(Districttranslation);
        }


      [Authorize(Roles="Admin")]       [HttpDelete("deleteDistricttranslation/{id}")]
        public IActionResult DeleteDistrictTranslation(int id)
        {
            bool check = _repository.DeleteDistrictTranslation(id);
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



      [Authorize(Roles="Admin")]       [HttpPut("updatedistricttranslation/{id}")]
        public IActionResult UpdateDistrictTranslation(DistrictTranslationUpdatedDTO Districttranslation1, int id)
        {
            try
            {
                var Districttranslationch = _repository.GetDistrictTranslationById(id);
                if (Districttranslationch == null || Districttranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Districttranslation1, Districttranslationch);
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
