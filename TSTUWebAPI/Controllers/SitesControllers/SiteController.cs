using AutoMapper;
using Contracts.AllRepository.SitesRepository;
using Entities.DTO.SiteDTOS;
using Entities.Model.SitesModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.SitesControllers
{
    [Route("api/site")]
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

        [HttpPost("createsite")]
        public IActionResult CreateSite(SiteCreatedDTO site1)
        {
            var site = _mapper.Map<Site>(site1);
            bool check = _repository.CreateSite(site);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallsite")]
        public IActionResult GetAllSite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Site> sitees1 = _repository.AllSite(queryNum, pageNum);
            var sitees = _mapper.Map<IEnumerable<SiteReadedDTO>>(sitees1);
            if (sitees == null) { return NotFound(); }
            return Ok(sitees);
        }

        [HttpGet("getbyidsite/{id}")]
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


        [HttpDelete("deletesite/{id}")]
        public IActionResult DeleteSite(int id)
        {
            bool check = _repository.DeleteSite(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatesite/{id}")]
        public IActionResult UpdateSite(SiteUpdatedDTO site1, int id)
        {

            try
            {
                Site site = _repository.GetSiteById(id);
                if (site == null)
                {
                    return NotFound();
                }
                var siteModel = _mapper.Map<Site>(site1);
                var a = _repository.UpdateSite(siteModel,id);
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
        [HttpPost("createsitetranslation")]
        public IActionResult CreateSiteTranslation(SiteTranslationCreatedDTO sitetranslation1)
        {
            var sitetranslation = _mapper.Map<SiteTranslation>(sitetranslation1);
            bool check = _repository.CreateSiteTranslation(sitetranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallsitetranslation")]
        public IActionResult GetAllSiteTranslation(int queryNum, int pageNum, string language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteTranslation> sitetranslationes1 = _repository.AllSiteTranslation(queryNum, pageNum, language_code);
            var sitetranslationes = _mapper.Map<IEnumerable<SiteTranslationReadedDTO>>(sitetranslationes1);
            if (sitetranslationes == null) { return NotFound(); }
            return Ok(sitetranslationes);
        }

        [HttpGet("getbyidsitetranslation/{id}")]
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


        [HttpDelete("deletesitetranslation/{id}")]
        public IActionResult DeleteSiteTranslation(int id)
        {
            bool check = _repository.DeleteSiteTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatesitetranslation/{id}")]
        public IActionResult UpdateSiteTranslation(SiteTranslationUpdatedDTO sitetranslation1, int id)
        {
            try
            {
                var site = _repository.GetSiteTranslationById(id);
                if (site == null)
                {
                    return NotFound();
                }
                var siteTranslationModel = _mapper.Map<SiteTranslation>(sitetranslation1);
                bool check = _repository.UpdateSiteTranslation(siteTranslationModel,id);
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
