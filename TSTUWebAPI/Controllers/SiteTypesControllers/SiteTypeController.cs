using AutoMapper;
using Contracts.AllRepository.SiteTypesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.SiteTypeDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.SiteTypesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.SiteTypeTypesControllers
{
    [Route("api/sitetype")]
    [ApiController]
    public class SiteTypeController : ControllerBase
    {
        private readonly ISiteTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public SiteTypeController(ISiteTypeRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // SiteType CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createsitetype")]
        public IActionResult CreateSiteType(SiteTypeCreatedDTO siteType1)
        {
            var siteType = _mapper.Map<SiteType>(siteType1);
            siteType.status_id = _status.GetStatusId("Active");
            int check = _repository.CreateSiteType(siteType);

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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallsitetype")]
        public IActionResult GetAllSiteType(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteType> siteTypees1 = _repository.AllSiteType(queryNum, pageNum);
            var siteTypees = _mapper.Map<IEnumerable<SiteTypeReadedDTO>>(siteTypees1);
            return Ok(siteTypees);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidsitetype/{id}")]
        public IActionResult GetByIdSiteType(int id)
        {

            SiteType siteType1 = _repository.GetSiteTypeById(id);
            if (siteType1 == null)
            {

            }
            var siteType = _mapper.Map<SiteTypeReadedDTO>(siteType1);
            return Ok(siteType);
        }

        [HttpGet("sitegetallsitetype")]
        public IActionResult GetAllSiteTypesite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteType> siteTypees1 = _repository.AllSiteTypeSite(queryNum, pageNum);
            var siteTypees = _mapper.Map<IEnumerable<SiteTypeReadedSiteDTO>>(siteTypees1);
            return Ok(siteTypees);
        }

        [HttpGet("sitegetbyidsitetype/{id}")]
        public IActionResult GetByIdSiteTypesite(int id)
        {

            SiteType siteType1 = _repository.GetSiteTypeByIdSite(id);
            if (siteType1 == null)
            {

            }
            var siteType = _mapper.Map<SiteTypeReadedSiteDTO>(siteType1);
            return Ok(siteType);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletesitetype/{id}")]
        public IActionResult DeleteSiteType(int id)
        {
            bool check = _repository.DeleteSiteType(id);
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
        [HttpPut("updatesitetype/{id}")]
        public IActionResult UpdateSiteType(SiteTypeUpdatedDTO siteType1, int id)
        {

            try
            {
                if (siteType1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<SiteType>(siteType1);

                bool updatedcheck = _repository.UpdateSiteType(id, dbupdated);
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







        //SiteTypeTranslation CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createsitetypetranslation")]
        public IActionResult CreateSiteTypeTranslation(SiteTypeTranslationCreatedDTO siteTypetranslation1)
        {
            var siteTypetranslation = _mapper.Map<SiteTypeTranslation>(siteTypetranslation1);
            siteTypetranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)siteTypetranslation.language_id);
            int check = _repository.CreateSiteTypeTranslation(siteTypetranslation);

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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallsitetypetranslation")]
        public IActionResult GetAllSiteTypeTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteTypeTranslation> siteTypetranslationes1 = _repository.AllSiteTypeTranslation(queryNum, pageNum, language_code);
            var siteTypetranslationes = _mapper.Map<IEnumerable<SiteTypeTranslationReadedDTO>>(siteTypetranslationes1);
            return Ok(siteTypetranslationes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidsitetypetranslation/{uz_id}")]
        public IActionResult GetByIdSiteTypeTranslation(int uz_id, string language_code)
        {

            SiteTypeTranslation siteTypetranslation1 = _repository.GetSiteTypeTranslationById(uz_id, language_code);
            if (siteTypetranslation1 == null)
            {

            }
            var siteTypetranslation = _mapper.Map<SiteTypeTranslationReadedDTO>(siteTypetranslation1);
            return Ok(siteTypetranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidsitetypetranslation/{id}")]
        public IActionResult GetByIdSiteTypeTranslation(int id)
        {

            SiteTypeTranslation siteTypetranslation1 = _repository.GetSiteTypeTranslationById(id);
            if (siteTypetranslation1 == null)
            {

            }
            var siteTypetranslation = _mapper.Map<SiteTypeTranslationReadedDTO>(siteTypetranslation1);
            return Ok(siteTypetranslation);
        }

        [HttpGet("sitegetallsitetypetranslation")]
        public IActionResult GetAllSiteTypeTranslationsite(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteTypeTranslation> siteTypetranslationes1 = _repository.AllSiteTypeTranslationSite(queryNum, pageNum, language_code);
            var siteTypetranslationes = _mapper.Map<IEnumerable<SiteTypeTranslationReadedSiteDTO>>(siteTypetranslationes1);
            return Ok(siteTypetranslationes);
        }

        [HttpGet("sitegetbyuzidsitetypetranslation/{uz_id}")]
        public IActionResult GetByIdSiteTypeTranslationsite(int uz_id, string language_code)
        {

            SiteTypeTranslation siteTypetranslation1 = _repository.GetSiteTypeTranslationByIdSite(uz_id, language_code);
            if (siteTypetranslation1 == null)
            {

            }
            var siteTypetranslation = _mapper.Map<SiteTypeTranslationReadedSiteDTO>(siteTypetranslation1);
            return Ok(siteTypetranslation);
        }

        [HttpGet("sitegetbyidsitetypetranslation/{id}")]
        public IActionResult GetByIdSiteTypeTranslationsite(int id)
        {

            SiteTypeTranslation siteTypetranslation1 = _repository.GetSiteTypeTranslationByIdSite(id);
            if (siteTypetranslation1 == null)
            {

            }
            var siteTypetranslation = _mapper.Map<SiteTypeTranslationReadedSiteDTO>(siteTypetranslation1);
            return Ok(siteTypetranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletesitetypetranslation/{id}")]
        public IActionResult DeleteSiteTypeTranslation(int id)
        {
            bool check = _repository.DeleteSiteTypeTranslation(id);
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
        [HttpPut("updatesitetypetranslation/{id}")]
        public IActionResult UpdateSiteTypeTranslation(SiteTypeTranslationUpdatedDTO siteTypetranslation1, int id)
        {
            try
            {
                if (siteTypetranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<SiteTypeTranslation>(siteTypetranslation1);

                bool updatedcheck = _repository.UpdateSiteTypeTranslation(id, dbupdated);
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
