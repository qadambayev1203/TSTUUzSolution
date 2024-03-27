using AutoMapper;
using Contracts.AllRepository.SiteDetailsRepository;
using Entities.DTO.SiteDetailDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.SiteDetailsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.SiteDetailDetailsControllers
{
    [Route("api/sitedetail")]
    [Authorize]
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

       [Authorize(Roles="Admin")]       [HttpPost("createsitedetail")]
        public IActionResult CreateSiteDetail(SiteDetailCreatedDTO siteDetail1)
        {
            var siteDetail = _mapper.Map<SiteDetail>(siteDetail1);
            siteDetail.status_id = 1;
            int check = _repository.CreateSiteDetail(siteDetail);

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

       [Authorize(Roles="Admin")]       [HttpGet("getallsitedetail")]
        public IActionResult GetAllSiteDetail(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetail> siteDetailes1 = _repository.AllSiteDetail(queryNum, pageNum);
            var siteDetailes = _mapper.Map<IEnumerable<SiteDetailReadedDTO>>(siteDetailes1);
            if (siteDetailes == null || siteDetailes.Count() == 0) { return NotFound(); }
            return Ok(siteDetailes);
        }

       [Authorize(Roles="Admin")]       [HttpGet("getbyidsitedetail/{id}")]
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


       [Authorize(Roles="Admin")]       [HttpDelete("deletesitedetail/{id}")]
        public IActionResult DeleteSiteDetail(int id)
        {
            bool check = _repository.DeleteSiteDetail(id);
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



       [Authorize(Roles="Admin")]       [HttpPut("updatesitedetail/{id}")]
        public IActionResult UpdateSiteDetail(SiteDetailUpdatedDTO siteDetail1, int id)
        {

            try
            {
                SiteDetail siteDetail = _repository.GetSiteDetailById(id);
                if (siteDetail == null || siteDetail1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(siteDetail1, siteDetail);
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







        //SiteDetailTranslation CRUD
       [Authorize(Roles="Admin")]       [HttpPost("createsitedetailtranslation")]
        public IActionResult CreateSiteDetailTranslation(SiteDetailTranslationCreatedDTO siteDetailtranslation1)
        {
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslation>(siteDetailtranslation1);
            siteDetailtranslation.status_translation_id = 1;
            int check = _repository.CreateSiteDetailTranslation(siteDetailtranslation);

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

       [Authorize(Roles="Admin")]       [HttpGet("getallsitedetailtranslation")]
        public IActionResult GetAllSiteDetailTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetailTranslation> siteDetailtranslationes1 = _repository.AllSiteDetailTranslation(queryNum, pageNum, language_code);
            var siteDetailtranslationes = _mapper.Map<IEnumerable<SiteDetailTranslationReadedDTO>>(siteDetailtranslationes1);
            if (siteDetailtranslationes == null || siteDetailtranslationes.Count() == 0) { return NotFound(); }
            return Ok(siteDetailtranslationes);
        }

       [Authorize(Roles="Admin")]       [HttpGet("getbyidsitedetailtranslation/{id}")]
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


       [Authorize(Roles="Admin")]       [HttpDelete("deletesitedetailtranslation/{id}")]
        public IActionResult DeleteSiteDetailTranslation(int id)
        {
            bool check = _repository.DeleteSiteDetailTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            bool check1 = _repository.DeleteSiteDetailTranslation(id);
            if (!check1)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



       [Authorize(Roles="Admin")]       [HttpPut("updatesitedetailtranslation/{id}")]
        public IActionResult UpdateSiteDetailTranslation(SiteDetailTranslationUpdatedDTO siteDetailtranslation1, int id)
        {
            try
            {
                var siteDetail = _repository.GetSiteDetailTranslationById(id);
                if (siteDetail == null || siteDetailtranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(siteDetailtranslation1, siteDetail);
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
