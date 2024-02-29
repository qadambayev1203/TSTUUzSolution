using AutoMapper;
using Contracts.AllRepository.SiteDetailsRepository;
using Entities.DTO.SiteDetailDTOS;
using Entities.Model.SiteDetailsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.SiteDetailDetailsControllers
{
    [Route("api/sitedetail")]
    [ApiController]
    public class SiteDetailController : ControllerBase
    {
        private readonly ISiteDetailRepository _repository;
        private readonly IMapper _mapper;
        public SiteDetailController(ISiteDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // SiteDetail CRUD

        [HttpPost("createsitedetail")]
        public IActionResult CreateSiteDetail(SiteDetailCreatedDTO siteDetail1)
        {
            var siteDetail = _mapper.Map<SiteDetail>(siteDetail1);
            bool check = _repository.CreateSiteDetail(siteDetail);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallsitedetail")]
        public IActionResult GetAllSiteDetail(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetail> siteDetailes1 = _repository.AllSiteDetail(queryNum, pageNum);
            var siteDetailes = _mapper.Map<IEnumerable<SiteDetailReadedDTO>>(siteDetailes1);
            if (siteDetailes == null||siteDetailes.Count() == 0) { return NotFound(); }
            return Ok(siteDetailes);
        }

        [HttpGet("getbyidsitedetail/{id}")]
        public IActionResult GetByIdSiteDetail(int id)
        {

            SiteDetail siteDetail1 = _repository.GetSiteDetailById(id);
            if (siteDetail1 == null)
            {
                return NotFound();
            }
            var siteDetail = _mapper.Map<SiteDetailReadedDTO>(siteDetail1);
            if (siteDetail == null) { return NotFound(); }
            return Ok(siteDetail);
        }


        [HttpDelete("deletesitedetail/{id}")]
        public IActionResult DeleteSiteDetail(int id)
        {
            bool check = _repository.DeleteSiteDetail(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatesitedetail/{id}")]
        public IActionResult UpdateSiteDetail(SiteDetailUpdatedDTO siteDetail1, int id)
        {

            try
            {
                SiteDetail siteDetail = _repository.GetSiteDetailById(id);
                if (siteDetail == null)
                {
                    return NotFound();
                }
                var siteDetailModel = _mapper.Map<SiteDetail>(siteDetail1);
                var a = _repository.UpdateSiteDetail(siteDetailModel, id);
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







        //SiteDetailTranslation CRUD
        [HttpPost("createsitedetailtranslation")]
        public IActionResult CreateSiteDetailTranslation(SiteDetailTranslationCreatedDTO siteDetailtranslation1)
        {
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslation>(siteDetailtranslation1);
            bool check = _repository.CreateSiteDetailTranslation(siteDetailtranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallsitedetailtranslation")]
        public IActionResult GetAllSiteDetailTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetailTranslation> siteDetailtranslationes1 = _repository.AllSiteDetailTranslation(queryNum, pageNum, language_code);
            var siteDetailtranslationes = _mapper.Map<IEnumerable<SiteDetailTranslationReadedDTO>>(siteDetailtranslationes1);
            if (siteDetailtranslationes == null||siteDetailtranslationes.Count() == 0) { return NotFound(); }
            return Ok(siteDetailtranslationes);
        }

        [HttpGet("getbyidsitedetailtranslation/{id}")]
        public IActionResult GetByIdSiteDetailTranslation(int id)
        {

            SiteDetailTranslation siteDetailtranslation1 = _repository.GetSiteDetailTranslationById(id);
            if (siteDetailtranslation1 == null)
            {
                return NotFound();
            }
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslationReadedDTO>(siteDetailtranslation1);
            if (siteDetailtranslation == null) { return NotFound(); }
            return Ok(siteDetailtranslation);
        }


        [HttpDelete("deletesitedetailtranslation/{id}")]
        public IActionResult DeleteSiteDetailTranslation(int id)
        {
            bool check = _repository.DeleteSiteDetailTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatesitedetailtranslation/{id}")]
        public IActionResult UpdateSiteDetailTranslation(SiteDetailTranslationUpdatedDTO siteDetailtranslation1, int id)
        {
            try
            {
                var siteDetail = _repository.GetSiteDetailTranslationById(id);
                if (siteDetail == null)
                {
                    return NotFound();
                }
                var siteDetailTranslationModel = _mapper.Map<SiteDetailTranslation>(siteDetailtranslation1);
                bool check = _repository.UpdateSiteDetailTranslation(siteDetailTranslationModel, id);
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
