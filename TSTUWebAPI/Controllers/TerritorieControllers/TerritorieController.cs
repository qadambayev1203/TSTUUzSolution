using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Contracts.AllRepository.TerritoriesRepository;
using Entities.DTO.TerritoriesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
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
        private readonly IStatusRepositoryStatic _status;

        public TerritorieController(ITerritorieRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // Territorie CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createterritorie")]
        public IActionResult CreateTerritorie(TerritorieCreatedDTO Territorie1)
        {
            var Territorie = _mapper.Map<Territorie>(Territorie1);
            Territorie.status_id = _status.GetStatusId("Active");
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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallterritorie")]
        public IActionResult GetAllTerritorie(int? country_id)
        {
            IEnumerable<Territorie> Territories1 = _repository.AllTerritorie(country_id);
            var Territories = _mapper.Map<IEnumerable<TerritorieReadedDTO>>(Territories1);

            return Ok(Territories);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidterritorie/{id}")]
        public IActionResult GetByIdTerritorie(int id)
        {

            Territorie Territorie1 = _repository.GetTerritorieById(id);
            if (Territorie1 == null)
            {
                return NotFound();
            }
            var Territorie = _mapper.Map<TerritorieReadedIdDTO>(Territorie1);
            return Ok(Territorie);
        }

        [HttpGet("sitegetallterritorie")]
        public IActionResult GetAllTerritoriesite(int country_id)
        {
            IEnumerable<Territorie> Territories1 = _repository.AllTerritorieSite(country_id);
            var Territories = _mapper.Map<IEnumerable<TerritorieReadedSiteDTO>>(Territories1);

            return Ok(Territories);
        }

        [HttpGet("sitegetbyidterritorie/{id}")]
        public IActionResult GetByIdTerritoriesite(int id)
        {

            Territorie Territorie1 = _repository.GetTerritorieByIdSite(id);
            if (Territorie1 == null)
            {
                return NotFound();
            }
            var Territorie = _mapper.Map<TerritorieReadedSiteDTO>(Territorie1);
            return Ok(Territorie);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteTerritorie/{id}")]
        public IActionResult DeleteTerritorie(int id)
        {
            bool check = _repository.DeleteTerritorie(id);
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
        [HttpPut("updateterritorie/{id}")]
        public IActionResult UpdateTerritorie(TerritorieUpdatedDTO Territorie1, int id)
        {
            try
            {
                if (Territorie1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<Territorie>(Territorie1);

                bool updatedcheck = _repository.UpdateTerritorie(id, dbupdated);
                if (!updatedcheck)
                {
                    return BadRequest();
                }
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

        [Authorize(Roles = "Admin")]
        [HttpPost("createterritorietranslation")]
        public IActionResult CreateTerritorieTranslation(TerritorieTranslationCreatedDTO Territorietranslation1)
        {
            var Territorietranslation = _mapper.Map<TerritorieTranslation>(Territorietranslation1);
            Territorietranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)Territorietranslation.language_id);
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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallterritorietranslation")]
        public IActionResult GetAllTerritorieTranslation(int? country_translation_id, string? language_code)
        {
            IEnumerable<TerritorieTranslation> Territorietranslations1 = _repository.AllTerritorieTranslation(country_translation_id, language_code);
            var Territorietranslations = _mapper.Map<IEnumerable<TerritorieTranslationReadedDTO>>(Territorietranslations1);

            return Ok(Territorietranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidterritorietranslation/{uz_id}")]
        public IActionResult GetByIdTerritorieTranslation(int uz_id, string language_code)
        {

            TerritorieTranslation Territorietranslation1 = _repository.GetTerritorieTranslationById(uz_id, language_code);
            var Territorietranslation = _mapper.Map<TerritorieTranslationReadedIdDTO>(Territorietranslation1);

            return Ok(Territorietranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidterritorietranslation/{id}")]
        public IActionResult GetByIdTerritorieTranslation(int id)
        {

            TerritorieTranslation Territorietranslation1 = _repository.GetTerritorieTranslationById(id);
            var Territorietranslation = _mapper.Map<TerritorieTranslationReadedIdDTO>(Territorietranslation1);

            return Ok(Territorietranslation);
        }

        [HttpGet("sitegetallterritorietranslation")]
        public IActionResult GetAllTerritorieTranslationsite(int country_translation_id, string? language_code)
        {
            IEnumerable<TerritorieTranslation> Territorietranslations1 = _repository.AllTerritorieTranslationSite(country_translation_id, language_code);
            var Territorietranslations = _mapper.Map<IEnumerable<TerritorieTranslationReadedSiteDTO>>(Territorietranslations1);

            return Ok(Territorietranslations);
        }

        [HttpGet("sitegetbyuzidterritorietranslation/{id}")]
        public IActionResult GetByIdTerritorieTranslationsite(int uz_id, string language_code)
        {

            TerritorieTranslation Territorietranslation1 = _repository.GetTerritorieTranslationByIdSite(uz_id, language_code);
            var Territorietranslation = _mapper.Map<TerritorieTranslationReadedSiteDTO>(Territorietranslation1);

            return Ok(Territorietranslation);
        }

        [HttpGet("sitegetbyidterritorietranslation/{id}")]
        public IActionResult GetByIdTerritorieTranslationsite(int id)
        {

            TerritorieTranslation Territorietranslation1 = _repository.GetTerritorieTranslationByIdSite(id);
            var Territorietranslation = _mapper.Map<TerritorieTranslationReadedSiteDTO>(Territorietranslation1);

            return Ok(Territorietranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteTerritorietranslation/{id}")]
        public IActionResult DeleteTerritorieTranslation(int id)
        {
            bool check = _repository.DeleteTerritorieTranslation(id);
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
        [HttpPut("updateterritorietranslation/{id}")]
        public IActionResult UpdateTerritorieTranslation(TerritorieTranslationUpdatedDTO Territorietranslation1, int id)
        {
            try
            {
                if (Territorietranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<TerritorieTranslation>(Territorietranslation1);

                bool updatedcheck = _repository.UpdateTerritorieTranslation(id, dbupdated);
                if (!updatedcheck)
                {
                    return BadRequest();
                }
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
