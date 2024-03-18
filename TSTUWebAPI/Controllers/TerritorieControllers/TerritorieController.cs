using AutoMapper;
using Contracts.AllRepository.TerritoriesRepository;
using Entities.DTO.TerritoriesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.TerritoriesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.TerritorieControllers
{
    [Route("api/territorie")]
    [ApiController]
    public class TerritorieController : ControllerBase
    {
        private readonly ITerritorieRepository _repository;
        private readonly IMapper _mapper;
        public TerritorieController(ITerritorieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Territorie CRUD

        [Authorize(Roles="Admin")]       [HttpPost("createterritorie")]
        public IActionResult CreateTerritorie(TerritorieCreatedDTO Territorie1)
        {
            var Territorie = _mapper.Map<Territorie>(Territorie1);
            int id = _repository.CreateTerritorie(Territorie);

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

        [HttpGet("getallterritorie")]
        public IActionResult GetAllTerritorie(int country_id)
        {
            IEnumerable<Territorie> Territories1 = _repository.AllTerritorie(country_id);
            var Territories = _mapper.Map<IEnumerable<TerritorieReadedDTO>>(Territories1);
            if (Territories == null || Territories.Count() == 0) { return NotFound(); }

            return Ok(Territories);
        }

        [HttpGet("getbyidterritorie/{id}")]
        public IActionResult GetByIdTerritorie(int id)
        {

            Territorie Territorie1 = _repository.GetTerritorieById(id);
            if (Territorie1 == null)
            {
                return NotFound();
            }
            var Territorie = _mapper.Map<TerritorieReadedDTO>(Territorie1);
            if (Territorie == null) { return NotFound(); }
            return Ok(Territorie);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteTerritorie/{id}")]
        public IActionResult DeleteTerritorie(int id)
        {
            bool check = _repository.DeleteTerritorie(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updateterritorie/{id}")]
        public IActionResult UpdateTerritorie(TerritorieUpdatedDTO Territorie1, int id)
        {
            try
            {
                var Territoriecheck = _repository.GetTerritorieById(id);
                if (Territoriecheck == null || Territorie1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Territorie1, Territoriecheck);
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







        //TerritorieTranslation CRUD
        [Authorize(Roles="Admin")]       [HttpPost("createterritorietranslation")]
        public IActionResult CreateTerritorieTranslation(TerritorieTranslationCreatedDTO Territorietranslation1)
        {
            var Territorietranslation = _mapper.Map<TerritorieTranslation>(Territorietranslation1);
            int id = _repository.CreateTerritorieTranslation(Territorietranslation);
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

        [HttpGet("getallterritorietranslation")]
        public IActionResult GetAllTerritorieTranslation(int country_translation_id, string? language_code)
        {
            IEnumerable<TerritorieTranslation> Territorietranslations1 = _repository.AllTerritorieTranslation(country_translation_id, language_code);
            var Territorietranslations = _mapper.Map<IEnumerable<TerritorieTranslationReadedDTO>>(Territorietranslations1);
            if (Territorietranslations == null || Territorietranslations.Count() == 0) { return NotFound(); }

            return Ok(Territorietranslations);
        }

        [HttpGet("getbyidterritorietranslation/{id}")]
        public IActionResult GetByIdTerritorieTranslation(int id)
        {

            TerritorieTranslation Territorietranslation1 = _repository.GetTerritorieTranslationById(id);
            var Territorietranslation = _mapper.Map<TerritorieTranslationReadedDTO>(Territorietranslation1);
            if (Territorietranslation == null) { return NotFound(); }

            return Ok(Territorietranslation);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteTerritorietranslation/{id}")]
        public IActionResult DeleteTerritorieTranslation(int id)
        {
            bool check = _repository.DeleteTerritorieTranslation(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updateterritorietranslation/{id}")]
        public IActionResult UpdateTerritorieTranslation(TerritorieTranslationUpdatedDTO Territorietranslation1, int id)
        {
            try
            {
                var Territorietranslationch = _repository.GetTerritorieTranslationById(id);
                if (Territorietranslationch == null || Territorietranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Territorietranslation1, Territorietranslationch);
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
