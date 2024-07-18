using AutoMapper;
using Contracts.AllRepository.AppealToEmployeesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.AppealsToEmployeeDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealToEmployeeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Attributes;
using TSTUWebAPI.Captcha;

namespace TSTUWebAPI.Controllers.AppealToEmployeesController
{
    [Route("api/appealtoemployee")]
    [ApiController]
    public class AppealToEmployeeController : ControllerBase
    {
        private readonly IAppealToEmployeeRepository _repository;
        private readonly IStatusRepositoryStatic _status;
        private readonly IMapper _mapper;
        private readonly CaptchaCheck captcheck;
        public AppealToEmployeeController(IAppealToEmployeeRepository repository, IMapper mapper, CaptchaCheck _captcha, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            captcheck = _captcha;
            _status = _status1;
        }


        // AppealToEmployee CRUD

        [StaticAuth]
        [HttpPost("createappealtoemployee/{person_id}")]
        public IActionResult CreateAppealToEmployee(int person_id, AppealToEmployeeCreatedDTO appealToEmployeeDTO)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            if (token != SessionClass.tokenCheck && token != SessionClass.token)
            {
                return Unauthorized();
            }

            if (appealToEmployeeDTO == null)
            {
                return BadRequest();
            }

            if (!captcheck.CheckCaptcha(appealToEmployeeDTO.captcha_numbers_sum))
            {
                return BadRequest("Captcha failed!");
            }

            var appealToEmployee = _mapper.Map<AppealToEmployee>(appealToEmployeeDTO);

            appealToEmployee.created_at = DateTime.UtcNow;
            appealToEmployee.status_id = _status.GetStatusId("Active");

            int id = _repository.CreateAppealToEmployee(appealToEmployee, person_id);

            if (id == 0)
            {
                return BadRequest();
            }

            var createdItemId = new CreatedItemId
            {
                id = id,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize]
        [HttpGet("getallappealtoemployee")]
        public IActionResult GetAllAppealToEmployee(int queryNum, int pageNum)
        {
            queryNum = Math.Max(0, queryNum);
            pageNum = Math.Max(0, pageNum);

            IEnumerable<AppealToEmployee> appealToEmployees = _repository.AllAppealToEmployee(queryNum, pageNum);

            var appealToEmployeesDTO = _mapper.Map<IEnumerable<AppealToEmployeeReadedDTO>>(appealToEmployees);

            return Ok(appealToEmployeesDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallappealtoemployeeadmin")]
        public IActionResult GetAllAppealToEmployeeAdmin(int queryNum, int pageNum)
        {
            queryNum = Math.Max(0, queryNum);
            pageNum = Math.Max(0, pageNum);

            IEnumerable<AppealToEmployee> appealToEmployees = _repository.AllAppealToEmployeeAdmin(queryNum, pageNum);

            var appealToEmployeesDTO = _mapper.Map<IEnumerable<AppealToEmployeeReadedAdminDTO>>(appealToEmployees);

            return Ok(appealToEmployeesDTO);
        }

        [Authorize]
        [HttpGet("getbyidappealtoemployee/{id}")]
        public IActionResult GetByIdAppealToEmployee(int id)
        {
            AppealToEmployee appealToEmployee = _repository.GetAppealToEmployeeById(id);

            var appealToEmployeeDTO = _mapper.Map<AppealToEmployeeReadedDTO>(appealToEmployee);

            return Ok(appealToEmployeeDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidappealtoemployeeadmin/{id}")]
        public IActionResult GetByIdAppealToEmployeeAdmin(int id)
        {
            AppealToEmployee appealToEmployee = _repository.GetAppealToEmployeeByIdAdmin(id);

            var appealToEmployeeDTO = _mapper.Map<AppealToEmployeeReadedAdminDTO>(appealToEmployee);

            return Ok(appealToEmployeeDTO);
        }

        [Authorize]
        [HttpDelete("deleteappealtoemployee/{id}")]
        public IActionResult DeleteAppealToEmployee(int id)
        {
            bool check = _repository.DeleteAppealToEmployee(id);
            if (!check)
            {
                return BadRequest();
            }

            return Ok("Deleted");
        }

        [Authorize]
        [HttpPut("updateappealtoemployee/{id}")]
        public IActionResult UpdateAppealToEmployee(int status_id, int id)
        {
            if (status_id <= 0)
            {
                return BadRequest("Invalid status_id provided.");
            }

            var appealToEmployee = new AppealToEmployee
            {
                status_id = status_id
            };

            bool updatedCheck = _repository.UpdateAppealToEmployee(id, appealToEmployee);
            if (!updatedCheck)
            {
                return NotFound("AppealToEmployee not found or update failed.");
            }

            return Ok("Updated successfully.");

        }







        //AppealToEmployeeTranslation CRUD

        [StaticAuth]
        [HttpPost("createappealtoemployeetranslation/{person_uz_id}")]
        public IActionResult CreateAppealToEmployeeTranslation(int person_uz_id, AppealToEmployeeTranslationCreatedDTO appealToEmployeeTranslationDTO)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            if (token != SessionClass.tokenCheck && token != SessionClass.token)
            {
                return Unauthorized();
            }

            if (appealToEmployeeTranslationDTO == null)
            {
                return BadRequest();
            }

            if (!captcheck.CheckCaptcha(appealToEmployeeTranslationDTO.captcha_numbers_sum))
            {
                return BadRequest("Captcha failed!");
            }

            var appealToEmployeeTranslation = _mapper.Map<AppealToEmployeeTranslation>(appealToEmployeeTranslationDTO);

            appealToEmployeeTranslation.status_id = _status.GetStatusTranslationId("Active", (int)appealToEmployeeTranslation.language_id);

            appealToEmployeeTranslation.created_at = DateTime.UtcNow;

            int id = _repository.CreateAppealToEmployeeTranslation(appealToEmployeeTranslation, person_uz_id);

            if (id == 0)
            {
                return BadRequest("Failed to create appeal to employee translation.");
            }

            var createdItemId = new CreatedItemId
            {
                id = id,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize]
        [HttpGet("getallappealtoemployeetranslation")]
        public IActionResult GetAllAppealToEmployeeTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Max(0, queryNum);
            pageNum = Math.Max(0, pageNum);

            IEnumerable<AppealToEmployeeTranslation> appealToEmployeeTranslations = _repository.AllAppealToEmployeeTranslation(queryNum, pageNum, language_code);

            var appealToEmployeeTranslationsDTO = _mapper.Map<IEnumerable<AppealToEmployeeTranslationReadedDTO>>(appealToEmployeeTranslations);

            return Ok(appealToEmployeeTranslationsDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallappealtoemployeetranslationadmin")]
        public IActionResult GetAllAppealToEmployeeTranslationAdmin(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Max(0, queryNum);
            pageNum = Math.Max(0, pageNum);

            IEnumerable<AppealToEmployeeTranslation> appealToEmployeeTranslations = _repository.AllAppealToEmployeeTranslationAdmin(queryNum, pageNum, language_code);

            var appealToEmployeeTranslationsDTO = _mapper.Map<IEnumerable<AppealToEmployeeTranslationReadedAdminDTO>>(appealToEmployeeTranslations);

            return Ok(appealToEmployeeTranslationsDTO);
        }

        [Authorize]
        [HttpGet("getbyidappealtoemployeetranslation/{id}")]
        public IActionResult GetByIdAppealToEmployeeTranslation(int id)
        {
            AppealToEmployeeTranslation appealToEmployeeTranslation = _repository.GetAppealToEmployeeTranslationById(id);

            var appealToEmployeeTranslationDTO = _mapper.Map<AppealToEmployeeTranslationReadedDTO>(appealToEmployeeTranslation);

            return Ok(appealToEmployeeTranslationDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidappealtoemployeetranslationadmin/{id}")]
        public IActionResult GetByIdAppealToEmployeeTranslationAdmin(int id)
        {
            AppealToEmployeeTranslation appealToEmployeeTranslation = _repository.GetAppealToEmployeeTranslationByIdAdmin(id);

            var appealToEmployeeTranslationDTO = _mapper.Map<AppealToEmployeeTranslationReadedAdminDTO>(appealToEmployeeTranslation);

            return Ok(appealToEmployeeTranslationDTO);
        }

        [Authorize]
        [HttpDelete("deleteappealtoemployeetranslation/{id}")]
        public IActionResult DeleteAppealToEmployeeTranslation(int id)
        {
            bool check = _repository.DeleteAppealToEmployeeTranslation(id);
            if (!check)
            {
                return BadRequest();
            }

            return Ok("Deleted");
        }

        [Authorize]
        [HttpPut("updateappealtoemployeetranslation/{id}")]
        public IActionResult UpdateAppealToEmployeeTranslation(int status_translation_id, int id)
        {

            var appealToEmployeeTranslation = new AppealToEmployeeTranslation
            {
                status_id = status_translation_id
            };

            bool updateCheck = _repository.UpdateAppealToEmployeeTranslation(id, appealToEmployeeTranslation);

            if (!updateCheck)
            {
                return BadRequest("Failed to update appeal to employee translation.");
            }

            return Ok("Updated successfully.");

        }




    }
}
