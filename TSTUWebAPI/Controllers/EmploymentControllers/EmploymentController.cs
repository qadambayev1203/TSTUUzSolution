using AutoMapper;
using Contracts.AllRepository.EmploymentsRepsitory;
using Entities.DTO.EmploymentsDTOS;
using Entities.Model.AnyClasses;
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
        public EmploymentController(IEmploymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Employment CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createemployment")]
        public IActionResult CreateEmployment(EmploymentCreatedDTO Employment1)
        {
            var Employment = _mapper.Map<Employment>(Employment1);
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

        [HttpGet("getallemployment")]
        public IActionResult GetAllEmployment(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Employment> Employments1 = _repository.AllEmployment(queryNum, pageNum);
            var Employments = _mapper.Map<IEnumerable<EmploymentReadedDTO>>(Employments1);
            if (Employments == null || Employments.Count() == 0) { return NotFound(); }

            return Ok(Employments);
        }

        [HttpGet("getbyidemployment/{id}")]
        public IActionResult GetByIdEmployment(int id)
        {

            Employment Employment1 = _repository.GetEmploymentById(id);
            if (Employment1 == null)
            {
                return NotFound();
            }
            var Employment = _mapper.Map<EmploymentReadedDTO>(Employment1);
            if (Employment == null) { return NotFound(); }
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
                var Employmentcheck = _repository.GetEmploymentById(id);
                if (Employmentcheck == null || Employment1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Employment1, Employmentcheck);
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

        [HttpGet("getallemploymenttranslation")]
        public IActionResult GetAllEmploymentTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<EmploymentTranslation> Employmenttranslations1 = _repository.AllEmploymentTranslation(queryNum, pageNum, language_code);
            var Employmenttranslations = _mapper.Map<IEnumerable<EmploymentTranslationReadedDTO>>(Employmenttranslations1);
            if (Employmenttranslations == null || Employmenttranslations.Count() == 0) { return NotFound(); }

            return Ok(Employmenttranslations);
        }

        [HttpGet("getbyidemploymenttranslation/{id}")]
        public IActionResult GetByIdEmploymentTranslation(int id)
        {

            EmploymentTranslation Employmenttranslation1 = _repository.GetEmploymentTranslationById(id);
            var Employmenttranslation = _mapper.Map<EmploymentTranslationReadedDTO>(Employmenttranslation1);
            if (Employmenttranslation == null) { return NotFound(); }

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
                var Employmenttranslationch = _repository.GetEmploymentTranslationById(id);
                if (Employmenttranslationch == null || Employmenttranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Employmenttranslation1, Employmenttranslationch);
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
