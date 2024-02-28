using AutoMapper;
using Contracts.AllRepository.SiteTypesRepository;
using Entities.DTO.SiteTypeDTOS;
using Entities.Model.SiteTypesModel;
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
        public SiteTypeController(ISiteTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // SiteType CRUD

        [HttpPost("createsitetype")]
        public IActionResult CreateSiteType(SiteTypeCreatedDTO siteType1)
        {
            var siteType = _mapper.Map<SiteType>(siteType1);
            bool check = _repository.CreateSiteType(siteType);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallsitetype")]
        public IActionResult GetAllSiteType(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteType> siteTypees1 = _repository.AllSiteType(queryNum, pageNum);
            var siteTypees = _mapper.Map<IEnumerable<SiteTypeReadedDTO>>(siteTypees1);
            if (siteTypees == null) { return NotFound(); }
            return Ok(siteTypees);
        }

        [HttpGet("getbyidsitetype/{id}")]
        public IActionResult GetByIdSiteType(int id)
        {

            SiteType siteType1 = _repository.GetSiteTypeById(id);
            if (siteType1 == null)
            {
                return NotFound();
            }
            var siteType = _mapper.Map<SiteTypeReadedDTO>(siteType1);
            if (siteType == null) { return NotFound(); }
            return Ok(siteType);
        }


        [HttpDelete("deletesitetype/{id}")]
        public IActionResult DeleteSiteType(int id)
        {
            bool check = _repository.DeleteSiteType(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatesitetype/{id}")]
        public IActionResult UpdateSiteType(SiteTypeUpdatedDTO siteType1, int id)
        {

            try
            {
                SiteType siteType = _repository.GetSiteTypeById(id);
                if (siteType == null)
                {
                    return NotFound();
                }
                var siteTypeModel = _mapper.Map<SiteType>(siteType1);
                var a = _repository.UpdateSiteType(siteTypeModel, id);
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







        //SiteTypeTranslation CRUD
        [HttpPost("createsitetypetranslation")]
        public IActionResult CreateSiteTypeTranslation(SiteTypeTranslationCreatedDTO siteTypetranslation1)
        {
            var siteTypetranslation = _mapper.Map<SiteTypeTranslation>(siteTypetranslation1);
            bool check = _repository.CreateSiteTypeTranslation(siteTypetranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallsitetypetranslation")]
        public IActionResult GetAllSiteTypeTranslation(int queryNum, int pageNum, string language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteTypeTranslation> siteTypetranslationes1 = _repository.AllSiteTypeTranslation(queryNum, pageNum, language_code);
            var siteTypetranslationes = _mapper.Map<IEnumerable<SiteTypeTranslationReadedDTO>>(siteTypetranslationes1);
            if (siteTypetranslationes == null) { return NotFound(); }
            return Ok(siteTypetranslationes);
        }

        [HttpGet("getbyidsitetypetranslation/{id}")]
        public IActionResult GetByIdSiteTypeTranslation(int id)
        {

            SiteTypeTranslation siteTypetranslation1 = _repository.GetSiteTypeTranslationById(id);
            if (siteTypetranslation1 == null)
            {
                return NotFound();
            }
            var siteTypetranslation = _mapper.Map<SiteTypeTranslationReadedDTO>(siteTypetranslation1);
            if (siteTypetranslation == null) { return NotFound(); }
            return Ok(siteTypetranslation);
        }


        [HttpDelete("deletesitetypetranslation/{id}")]
        public IActionResult DeleteSiteTypeTranslation(int id)
        {
            bool check = _repository.DeleteSiteTypeTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }


        [HttpPut("updatesitetypetranslation/{id}")]
        public IActionResult UpdateSiteTypeTranslation(SiteTypeTranslationUpdatedDTO siteTypetranslation1, int id)
        {
            try
            {
                var siteType = _repository.GetSiteTypeTranslationById(id);
                if (siteType == null)
                {
                    return NotFound();
                }
                var siteTypeTranslationModel = _mapper.Map<SiteTypeTranslation>(siteTypetranslation1);
                bool check = _repository.UpdateSiteTypeTranslation(siteTypeTranslationModel, id);
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
