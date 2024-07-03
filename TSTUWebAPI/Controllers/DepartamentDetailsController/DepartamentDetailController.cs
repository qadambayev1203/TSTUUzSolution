using AutoMapper;
using Contracts.AllRepository.DepartamentDetailsRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.DepartamentDetailsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.DepartamentDetailsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DepartamentDetailDetailsController
{
    [Route("api/departamentdetail")]
    [ApiController]
    public class DepartamentDetailController : ControllerBase
    {
        private readonly IDepartamentDetailRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public DepartamentDetailController(IDepartamentDetailRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // DepartamentDetail CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createdepartamentdetail")]
        public IActionResult CreateDepartamentDetail(DepartamentDetailCreatedDTO departamentDetail1)
        {
            if (departamentDetail1 == null)
            {
                return StatusCode(422);
            }
            var departamentDetail = _mapper.Map<DepartamentDetail>(departamentDetail1);
            departamentDetail.status_id = _status.GetStatusId("Active");
            int check = _repository.CreateDepartamentDetail(departamentDetail);

            if (check == 0)
            {
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalldepartamentdetail")]
        public IActionResult GetAllDepartamentDetail(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentDetail> departamentDetails1 = _repository.AllDepartamentDetail(queryNum, pageNum);
            var departamentDetails = _mapper.Map<IEnumerable<DepartamentDetailReadedDTO>>(departamentDetails1);
            if (departamentDetails == null)
            {

            }
            return Ok(departamentDetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiddepartamentdetail/{id}")]
        public IActionResult GetByIdDepartamentDetail(int id)
        {

            DepartamentDetail departamentDetail1 = _repository.GetDepartamentDetailById(id);
            if (departamentDetail1 == null)
            {

            }
            var departamentDetail = _mapper.Map<DepartamentDetailReadedDTO>(departamentDetail1);
            if (departamentDetail == null) { }

            return Ok(departamentDetail);
        }

        [HttpGet("sitegetalldepartamentdetail")]
        public IActionResult GetAllDepartamentDetailsite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentDetail> departamentDetails1 = _repository.AllDepartamentDetailSite(queryNum, pageNum);
            var departamentDetails = _mapper.Map<IEnumerable<DepartamentDetailReadedSiteDTO>>(departamentDetails1);
            if (departamentDetails == null)
            {

            }
            return Ok(departamentDetails);
        }

        [HttpGet("sitegetbyiddepartamentdetail/{id}")]
        public IActionResult GetByIdDepartamentDetailsite(int id)
        {

            DepartamentDetail departamentDetail1 = _repository.GetDepartamentDetailByIdSite(id);
            if (departamentDetail1 == null)
            {

            }
            var departamentDetail = _mapper.Map<DepartamentDetailReadedSiteDTO>(departamentDetail1);
            if (departamentDetail == null) { }

            return Ok(departamentDetail);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletedepartamentdetail/{id}")]
        public IActionResult DeleteDepartamentDetail(int id)
        {

            bool check = _repository.DeleteDepartamentDetail(id);
            if (!check)
            {
                return StatusCode(404);
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(404);
            }
            return Ok("Deleted");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatedepartamentdetail/{id}")]
        public IActionResult UpdateDepartamentDetail(DepartamentDetailUpdatedDTO departamentDetail1, int id)
        {

            try
            {
                if (departamentDetail1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<DepartamentDetail>(departamentDetail1);

                bool updatedcheck = _repository.UpdateDepartamentDetail(id, dbupdated);
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







        //DepartamentDetailTranslation CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createdepartamentdetailtranslation")]
        public IActionResult CreateDepartamentDetailTranslation(DepartamentDetailTranslationCreatedDTO departamentDetailtranslation1)
        {
            if (departamentDetailtranslation1 == null)
            {
                return StatusCode(422);
            }
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslation>(departamentDetailtranslation1);
            departamentDetailtranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)departamentDetailtranslation.language_id);
            int check = _repository.CreateDepartamentDetailTranslation(departamentDetailtranslation);

            if (check == 0)
            {
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalldepartamentdetailtranslation")]
        public IActionResult GetAllDepartamentDetailTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentDetailTranslation> departamentDetailtranslations1 = _repository.AllDepartamentDetailTranslation(queryNum, pageNum, language_code);
            var departamentDetailtranslations = _mapper.Map<IEnumerable<DepartamentDetailTranslationReadedDTO>>(departamentDetailtranslations1);
            if (departamentDetailtranslations == null)
            {

            }
            return Ok(departamentDetailtranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuziddepartamentdetailtranslation/{uz_id}")]
        public IActionResult GetByIdDepartamentDetailTranslation(int uz_id, string language_code)
        {

            DepartamentDetailTranslation departamentDetailtranslation1 = _repository.GetDepartamentDetailTranslationById(uz_id, language_code);
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslationReadedDTO>(departamentDetailtranslation1);
            if (departamentDetailtranslation == null) { }
            return Ok(departamentDetailtranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiddepartamentdetailtranslation/{id}")]
        public IActionResult GetByIdDepartamentDetailTranslation(int id)
        {

            DepartamentDetailTranslation departamentDetailtranslation1 = _repository.GetDepartamentDetailTranslationById(id);
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslationReadedDTO>(departamentDetailtranslation1);
            if (departamentDetailtranslation == null) { }
            return Ok(departamentDetailtranslation);
        }

        [HttpGet("sitegetalldepartamentdetailtranslation")]
        public IActionResult GetAllDepartamentDetailTranslationsite(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentDetailTranslation> departamentDetailtranslations1 = _repository.AllDepartamentDetailTranslationSite(queryNum, pageNum, language_code);
            var departamentDetailtranslations = _mapper.Map<IEnumerable<DepartamentDetailTranslationReadedSiteDTO>>(departamentDetailtranslations1);
            if (departamentDetailtranslations == null)
            {

            }
            return Ok(departamentDetailtranslations);
        }

        [HttpGet("sitegetbyuziddepartamentDetailtranslation/{uz_id}")]
        public IActionResult GetByIdDepartamentDetailTranslationsite(int uz_id, string language_code)
        {

            DepartamentDetailTranslation departamentDetailtranslation1 = _repository.GetDepartamentDetailTranslationByIdSite(uz_id, language_code);
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslationReadedSiteDTO>(departamentDetailtranslation1);
            if (departamentDetailtranslation == null) { }
            return Ok(departamentDetailtranslation);
        }

        [HttpGet("sitegetbyiddepartamentdetailtranslation/{id}")]
        public IActionResult GetByIdDepartamentDetailTranslationsite(int id)
        {

            DepartamentDetailTranslation departamentDetailtranslation1 = _repository.GetDepartamentDetailTranslationByIdSite(id);
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslationReadedSiteDTO>(departamentDetailtranslation1);
            if (departamentDetailtranslation == null) { }
            return Ok(departamentDetailtranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletedepartamentdetailtranslation/{id}")]
        public IActionResult DeleteDepartamentDetailTranslation(int id)
        {
            bool check = _repository.DeleteDepartamentDetailTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(400);
            }
            return StatusCode(200);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatedepartamentdetailtranslation/{id}")]
        public IActionResult UpdateDepartamentDetailTranslation(DepartamentDetailTranslationUpdatedDTO departamentDetailtranslation1, int id)
        {

            try
            {
                if (departamentDetailtranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<DepartamentDetailTranslation>(departamentDetailtranslation1);

                bool updatedcheck = _repository.UpdateDepartamentDetailTranslation(id, dbupdated);
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
