using AutoMapper;
using Contracts.AllRepository.NeighborhoodsRepository;
using Entities.DTO.NeighborhoodsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.NeighborhoodsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.NeighborhoodControllers
{
    [Route("api/neighborhood")]
    [ApiController]
    public class NeighborhoodController : ControllerBase
    {
        private readonly INeighborhoodRepository _repository;
        private readonly IMapper _mapper;
        public NeighborhoodController(INeighborhoodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Neighborhood CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createneighborhood")]
        public IActionResult CreateNeighborhood(NeighborhoodCreatedDTO Neighborhood1)
        {
            var Neighborhood = _mapper.Map<Neighborhood>(Neighborhood1);
            int id = _repository.CreateNeighborhood(Neighborhood);

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

        [HttpGet("getallneighborhood")]
        public IActionResult GetAllNeighborhood(int district_id)
        {
            IEnumerable<Neighborhood> Neighborhoods1 = _repository.AllNeighborhood(district_id);
            var Neighborhoods = _mapper.Map<IEnumerable<NeighborhoodReadedDTO>>(Neighborhoods1);
            if (Neighborhoods == null || Neighborhoods.Count() == 0) { return NotFound(); }

            return Ok(Neighborhoods);
        }

        [HttpGet("getbyidneighborhood/{id}")]
        public IActionResult GetByIdNeighborhood(int id)
        {

            Neighborhood Neighborhood1 = _repository.GetNeighborhoodById(id);
            if (Neighborhood1 == null)
            {
                return NotFound();
            }
            var Neighborhood = _mapper.Map<NeighborhoodReadedDTO>(Neighborhood1);
            if (Neighborhood == null) { return NotFound(); }
            return Ok(Neighborhood);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteNeighborhood/{id}")]
        public IActionResult DeleteNeighborhood(int id)
        {
            bool check = _repository.DeleteNeighborhood(id);
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
        [HttpPut("updateneighborhood/{id}")]
        public IActionResult UpdateNeighborhood(NeighborhoodUpdatedDTO Neighborhood1, int id)
        {
            try
            {
                var Neighborhoodcheck = _repository.GetNeighborhoodById(id);
                if (Neighborhoodcheck == null || Neighborhood1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Neighborhood1, Neighborhoodcheck);
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







        //NeighborhoodTranslation CRUD
        [Authorize(Roles = "Admin")]
        [HttpPost("createneighborhoodtranslation")]
        public IActionResult CreateNeighborhoodTranslation(NeighborhoodTranslationCreatedDTO Neighborhoodtranslation1)
        {
            var Neighborhoodtranslation = _mapper.Map<NeighborhoodTranslation>(Neighborhoodtranslation1);
            int id = _repository.CreateNeighborhoodTranslation(Neighborhoodtranslation);
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

        [HttpGet("getallneighborhoodtranslation")]
        public IActionResult GetAllNeighborhoodTranslation(int country_translation_id, string? language_code)
        {
            IEnumerable<NeighborhoodTranslation> Neighborhoodtranslations1 = _repository.AllNeighborhoodTranslation(country_translation_id, language_code);
            var Neighborhoodtranslations = _mapper.Map<IEnumerable<NeighborhoodTranslationReadedDTO>>(Neighborhoodtranslations1);
            if (Neighborhoodtranslations == null || Neighborhoodtranslations.Count() == 0) { return NotFound(); }

            return Ok(Neighborhoodtranslations);
        }

        [HttpGet("getbyidneighborhoodtranslation/{id}")]
        public IActionResult GetByIdNeighborhoodTranslation(int id)
        {

            NeighborhoodTranslation Neighborhoodtranslation1 = _repository.GetNeighborhoodTranslationById(id);
            var Neighborhoodtranslation = _mapper.Map<NeighborhoodTranslationReadedDTO>(Neighborhoodtranslation1);
            if (Neighborhoodtranslation == null) { return NotFound(); }

            return Ok(Neighborhoodtranslation);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteNeighborhoodtranslation/{id}")]
        public IActionResult DeleteNeighborhoodTranslation(int id)
        {
            bool check = _repository.DeleteNeighborhoodTranslation(id);
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
        [HttpPut("updateneighborhoodtranslation/{id}")]
        public IActionResult UpdateNeighborhoodTranslation(NeighborhoodTranslationUpdatedDTO Neighborhoodtranslation1, int id)
        {
            try
            {
                var Neighborhoodtranslationch = _repository.GetNeighborhoodTranslationById(id);
                if (Neighborhoodtranslationch == null || Neighborhoodtranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Neighborhoodtranslation1, Neighborhoodtranslationch);
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
