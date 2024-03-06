using AutoMapper;
using Contracts.AllRepository.SitesRepository;
using Entities.DTO.SiteDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.SitesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.SitesControllers
{
    [Route("api/site")]
    [Authorize]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _repository;
        private readonly IMapper _mapper;
        public SiteController(ISiteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Site CRUD

       [Authorize(Roles="Admin")]       [HttpPost("createsite")]
        public IActionResult CreateSite(SiteCreatedDTO site1)
        {
            var site = _mapper.Map<Site>(site1);
            int check = _repository.CreateSite(site);

            if (check == 0)
            {
                return BadRequest();
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

       [Authorize(Roles="Admin")]       [HttpGet("getallsite")]
        public IActionResult GetAllSite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Site> sitees1 = _repository.AllSite(queryNum, pageNum);
            var sitees = _mapper.Map<IEnumerable<SiteReadedDTO>>(sitees1);
            if (sitees == null || sitees.Count() == 0) { return NotFound(); }
            return Ok(sitees);
        }

       [Authorize(Roles="Admin")]       [HttpGet("getbyidsite/{id}")]
        public IActionResult GetByIdSite(int id)
        {

            Site site1 = _repository.GetSiteById(id);
            if (site1 == null)
            {
                return NotFound();
            }
            var site = _mapper.Map<SiteReadedDTO>(site1);
            if (site == null) { return NotFound(); }
            return Ok(site);
        }


       [Authorize(Roles="Admin")]       [HttpDelete("deletesite/{id}")]
        public IActionResult DeleteSite(int id)
        {
            bool check = _repository.DeleteSite(id);
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



       [Authorize(Roles="Admin")]       [HttpPut("updatesite/{id}")]
        public IActionResult UpdateSite(SiteUpdatedDTO site1, int id)
        {

            try
            {
                Site site = _repository.GetSiteById(id);
                if (site == null || site1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(site1, site);
                var a = _repository.SaveChanges();
                if (a)
                {
                    return BadRequest(a);
                }
                return Ok("Updated");
            }
            catch
            {
                return BadRequest();
            }

        }







        //SiteTranslation CRUD
       [Authorize(Roles="Admin")]       [HttpPost("createsitetranslation")]
        public IActionResult CreateSiteTranslation(SiteTranslationCreatedDTO sitetranslation1)
        {
            var sitetranslation = _mapper.Map<SiteTranslation>(sitetranslation1);
            int check = _repository.CreateSiteTranslation(sitetranslation);

            if (check == 0)
            {
                return BadRequest();
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

       [Authorize(Roles="Admin")]       [HttpGet("getallsitetranslation")]
        public IActionResult GetAllSiteTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteTranslation> sitetranslationes1 = _repository.AllSiteTranslation(queryNum, pageNum, language_code);
            var sitetranslationes = _mapper.Map<IEnumerable<SiteTranslationReadedDTO>>(sitetranslationes1);
            if (sitetranslationes == null || sitetranslationes.Count() == 0) { return NotFound(); }
            return Ok(sitetranslationes);
        }

       [Authorize(Roles="Admin")]       [HttpGet("getbyidsitetranslation/{id}")]
        public IActionResult GetByIdSiteTranslation(int id)
        {

            SiteTranslation sitetranslation1 = _repository.GetSiteTranslationById(id);
            if (sitetranslation1 == null)
            {
                return NotFound();
            }
            var sitetranslation = _mapper.Map<SiteTranslationReadedDTO>(sitetranslation1);
            if (sitetranslation == null) { return NotFound(); }
            return Ok(sitetranslation);
        }


       [Authorize(Roles="Admin")]       [HttpDelete("deletesitetranslation/{id}")]
        public IActionResult DeleteSiteTranslation(int id)
        {
            bool check = _repository.DeleteSiteTranslation(id);
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



       [Authorize(Roles="Admin")]       [HttpPut("updatesitetranslation/{id}")]
        public IActionResult UpdateSiteTranslation(SiteTranslationUpdatedDTO sitetranslation1, int id)
        {
            try
            {
                var site = _repository.GetSiteTranslationById(id);
                if (site == null || sitetranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(sitetranslation1, site);
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
