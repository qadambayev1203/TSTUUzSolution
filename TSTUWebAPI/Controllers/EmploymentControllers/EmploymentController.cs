using AutoMapper;
using Contracts.AllRepository.EmploymentsRepsitory;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.EmploymentsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.EmploymentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.EmploymentControllers
{
    [Route("api/employment")]
    [ApiController]
    public class EmploymentController : ControllerBase
    {
        private readonly IEmploymentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public EmploymentController(IEmploymentRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // Employment CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createemployment")]
        public IActionResult CreateEmployment(EmploymentCreatedDTO Employment1)
        {
            var Employment = _mapper.Map<Employment>(Employment1);
            Employment.status_id = _status.GetStatusId("Active");
            int id = _repository.CreateEmployment(Employment);

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
        [HttpGet("getallemployment")]
        public IActionResult GetAllEmployment(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Employment> Employments1 = _repository.AllEmployment(queryNum, pageNum);
            var Employments = _mapper.Map<IEnumerable<EmploymentReadedDTO>>(Employments1);
            if (Employments == null) { }

            return Ok(Employments);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidemployment/{id}")]
        public IActionResult GetByIdEmployment(int id)
        {

            Employment Employment1 = _repository.GetEmploymentById(id);
            if (Employment1 == null)
            {

            }
            var Employment = _mapper.Map<EmploymentReadedDTO>(Employment1);
            if (Employment == null) { }
            return Ok(Employment);
        }

        [HttpGet("sitegetallemployment")]
        public IActionResult GetAllEmploymentsite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Employment> Employments1 = _repository.AllEmploymentSite(queryNum, pageNum);
            var Employments = _mapper.Map<IEnumerable<EmploymentReadedSiteDTO>>(Employments1);
            if (Employments == null) { }

            return Ok(Employments);
        }

        [HttpGet("sitegetbyidemployment/{id}")]
        public IActionResult GetByIdEmploymentsite(int id)
        {

            Employment Employment1 = _repository.GetEmploymentByIdSite(id);
            if (Employment1 == null)
            {

            }
            var Employment = _mapper.Map<EmploymentReadedSiteDTO>(Employment1);
            if (Employment == null) { }
            return Ok(Employment);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteemployment/{id}")]
        public IActionResult DeleteEmployment(int id)
        {
            bool check = _repository.DeleteEmployment(id);
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
        [HttpPut("updateemployment/{id}")]
        public IActionResult UpdateEmployment(EmploymentUpdatedDTO Employment1, int id)
        {
            try
            {
                if (Employment1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<Employment>(Employment1);

                bool updatedcheck = _repository.UpdateEmployment(id, dbupdated);
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







        //EmploymentTranslation CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createemploymenttranslation")]
        public IActionResult CreateEmploymentTranslation(EmploymentTranslationCreatedDTO Employmenttranslation1)
        {
            var Employmenttranslation = _mapper.Map<EmploymentTranslation>(Employmenttranslation1);
            Employmenttranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)Employmenttranslation.language_id);
            int id = _repository.CreateEmploymentTranslation(Employmenttranslation);
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
        [HttpGet("getallemploymenttranslation")]
        public IActionResult GetAllEmploymentTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<EmploymentTranslation> Employmenttranslations1 = _repository.AllEmploymentTranslation(queryNum, pageNum, language_code);
            var Employmenttranslations = _mapper.Map<IEnumerable<EmploymentTranslationReadedDTO>>(Employmenttranslations1);
            if (Employmenttranslations == null) { }

            return Ok(Employmenttranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidemploymenttranslation/{uz_id}")]
        public IActionResult GetByIdEmploymentTranslation(int uz_id, string language_code)
        {

            EmploymentTranslation Employmenttranslation1 = _repository.GetEmploymentTranslationById(uz_id, language_code);
            var Employmenttranslation = _mapper.Map<EmploymentTranslationReadedDTO>(Employmenttranslation1);
            if (Employmenttranslation == null) { }

            return Ok(Employmenttranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidemploymenttranslation/{id}")]
        public IActionResult GetByIdEmploymentTranslation(int id)
        {

            EmploymentTranslation Employmenttranslation1 = _repository.GetEmploymentTranslationById(id);
            var Employmenttranslation = _mapper.Map<EmploymentTranslationReadedDTO>(Employmenttranslation1);
            if (Employmenttranslation == null) { }

            return Ok(Employmenttranslation);
        }

        [HttpGet("sitegetallemploymenttranslation")]
        public IActionResult GetAllEmploymentTranslationsite(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<EmploymentTranslation> Employmenttranslations1 = _repository.AllEmploymentTranslationSite(queryNum, pageNum, language_code);
            var Employmenttranslations = _mapper.Map<IEnumerable<EmploymentTranslationReadedSiteDTO>>(Employmenttranslations1);
            if (Employmenttranslations == null) { }

            return Ok(Employmenttranslations);
        }

        [HttpGet("sitegetbyuzidemploymenttranslation/{uz_id}")]
        public IActionResult GetByIdEmploymentTranslationsite(int uz_id, string language_code)
        {

            EmploymentTranslation Employmenttranslation1 = _repository.GetEmploymentTranslationByIdSite(uz_id, language_code);
            var Employmenttranslation = _mapper.Map<EmploymentTranslationReadedSiteDTO>(Employmenttranslation1);
            if (Employmenttranslation == null) { }

            return Ok(Employmenttranslation);
        }

        [HttpGet("sitegetbyidemploymenttranslation/{id}")]
        public IActionResult GetByIdEmploymentTranslationsite(int id)
        {

            EmploymentTranslation Employmenttranslation1 = _repository.GetEmploymentTranslationByIdSite(id);
            var Employmenttranslation = _mapper.Map<EmploymentTranslationReadedSiteDTO>(Employmenttranslation1);
            if (Employmenttranslation == null) { }

            return Ok(Employmenttranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteemploymenttranslation/{id}")]
        public IActionResult DeleteEmploymentTranslation(int id)
        {
            bool check = _repository.DeleteEmploymentTranslation(id);
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
        [HttpPut("updateemploymenttranslation/{id}")]
        public IActionResult UpdateEmploymentTranslation(EmploymentTranslationUpdatedDTO Employmenttranslation1, int id)
        {
            try
            {
                if (Employmenttranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<EmploymentTranslation>(Employmenttranslation1);

                bool updatedcheck = _repository.UpdateEmploymentTranslation(id, dbupdated);
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
