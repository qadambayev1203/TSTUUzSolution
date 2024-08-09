using AutoMapper;
using Contracts.AllRepository.AppealsToRectorRepository;
using Entities.DTO.AppealsToRectorDTOS;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.AppealsToTheRectorsModel;
using Microsoft.AspNetCore.Authorization;
using TSTUWebAPI.Controllers.FileControllers;
using Entities.Model.FileModel;
using System;
using System.IO;
using TSTUWebAPI.Attributes;
using Microsoft.EntityFrameworkCore;
using TSTUWebAPI.Captcha;
using Entities.Model.StatusModel;
using Contracts.AllRepository.StatusesRepository;

namespace TSTUWebAPI.Controllers.AppealToRectorControllers
{
    [Route("api/appealtorector")]
    [ApiController]
    public class AppealToRectorController : ControllerBase
    {
        private readonly IAppealToRectorRepository _repository;
        private readonly IMapper _mapper;
        private readonly CaptchaCheck captcheck;
        public AppealToRectorController(IAppealToRectorRepository repository, IMapper mapper, CaptchaCheck _captcha)
        {
            _repository = repository;
            _mapper = mapper;
            captcheck = _captcha;
        }


        // AppealToRector CRUD

        [StaticAuth]
        [HttpPost("createappealtorector")]
        public IActionResult CreateAppealToRector(AppealToRectorCreatedDTO AppealToRector1)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token == SessionClass.tokenCheck || token == SessionClass.token)
            {
                if (AppealToRector1 == null)
                {
                    return BadRequest();
                }

                var capt = captcheck.CheckCaptcha(AppealToRector1.captcha_numbers_sum);
                if (!capt)
                {
                    return BadRequest("Captcha failed!");
                }

                var AppealToRector = _mapper.Map<AppealToRector>(AppealToRector1);
                FileUploadRepository fileUpload = new FileUploadRepository();
                var Url = fileUpload.SaveFileAsync(AppealToRector1.file_upload_);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }

                if (Url != null)
                {
                    AppealToRector.file_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }


                AppealToRector.confirm = false;

                int id = _repository.CreateAppealToRector(AppealToRector);

                if (id == 0)
                {
                    fileUpload.DeleteFileAsync(Url);
                    return BadRequest();
                }

                CreatedItemId createdItemId = new CreatedItemId()
                {
                    id = id,
                    StatusCode = 200
                };

                return Ok(createdItemId);
            }
            return Unauthorized();

        }

        [Authorize(Roles = "Admin,VirtualReception")]
        [HttpGet("getallappealtorector")]
        public IActionResult GetAllAppealToRector(int queryNum, int pageNum, DateTime? start_time, DateTime? end_time)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<AppealToRector> AppealToRectors1 = _repository.AllAppealToRector(queryNum, pageNum, start_time, end_time);
            var AppealToRectors = _mapper.Map<IEnumerable<AppealToRectorReadedDTO>>(AppealToRectors1);
            if (AppealToRectors == null) { }

            return Ok(AppealToRectors);
        }

        [Authorize(Roles = "Admin,VirtualReception")]
        [HttpGet("getbyidappealtorector/{id}")]
        public IActionResult GetByIdAppealToRector(int id)
        {

            AppealToRector AppealToRector1 = _repository.GetAppealToRectorById(id);
            if (AppealToRector1 == null)
            {

            }
            var AppealToRector = _mapper.Map<AppealToRectorReadedDTO>(AppealToRector1);
            if (AppealToRector == null) { }
            return Ok(AppealToRector);
        }

        [Authorize(Roles = "Admin,VirtualReception")]
        [HttpPut("updateappealtorector/{id}")]
        public IActionResult UpdateAppealToRector(bool confirm, int id)
        {
            try
            {
                var AppealToRectorcheck = _repository.GetAppealToRectorById(id);
                AppealToRectorUpdatedDTO AppealToRector1 = new AppealToRectorUpdatedDTO()
                {
                    confirm = confirm
                };
                if (AppealToRectorcheck == null || AppealToRector1 == null)
                {
                    return BadRequest();
                }
                var appeal = _mapper.Map<AppealToRector>(AppealToRector1);

                bool updatedcheck = _repository.UpdateAppealToRector(id, appeal);
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

        [StaticAuth]
        [HttpGet("getallappealtorectoremailstatus/{email}")]
        public IActionResult GetAllAppealToRectorEmailStatus(string email)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token == SessionClass.tokenCheck || token == SessionClass.token)
            {
                IEnumerable<AppealToRector> AppealToRectors1 = _repository.GetByAppealStatus(email);
                var AppealToRectors = _mapper.Map<IEnumerable<AppealEmailCheckStatusDTO>>(AppealToRectors1);
                if (AppealToRectors == null) { }

                return Ok(AppealToRectors);
            }
            return Unauthorized();

        }





        //AppealToRectorTranslation CRUD

        [StaticAuth]
        [HttpPost("createappealtorectortranslation")]
        public IActionResult CreateAppealToRectorTranslation(AppealToRectorTranslationCreatedDTO AppealToRectortranslation1)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token == SessionClass.tokenCheck || token == SessionClass.token)
            {
                if (AppealToRectortranslation1 == null)
                {
                    return BadRequest();
                }
                var capt = captcheck.CheckCaptcha(AppealToRectortranslation1.captcha_numbers_sum);
                if (!capt)
                {
                    return BadRequest("Captcha failed!");
                }


                var AppealToRectortranslation = _mapper.Map<AppealToRectorTranslation>(AppealToRectortranslation1);

                FileUploadRepository fileUpload = new FileUploadRepository();
                var Url = fileUpload.SaveFileAsync(AppealToRectortranslation1.file_upload_);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }

                if (Url != null)
                {
                    AppealToRectortranslation.file_translation_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }


                AppealToRectortranslation.confirm = false;




                int id = _repository.CreateAppealToRectorTranslation(AppealToRectortranslation);
                if (id == 0)
                {
                    return BadRequest();
                }

                if (id == 0)
                {
                    fileUpload.DeleteFileAsync(Url);
                    return BadRequest();
                }
                CreatedItemId createdItemId = new CreatedItemId()
                {
                    id = id,
                    StatusCode = 200
                };

                return Ok(createdItemId);
            }
            return Unauthorized();
        }

        [Authorize(Roles = "Admin,VirtualReception")]
        [HttpGet("getallappealtorectortranslation")]
        public IActionResult GetAllAppealToRectorTranslation(int queryNum, int pageNum, string? language_code, DateTime? start_time, DateTime? end_time)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<AppealToRectorTranslation> AppealToRectortranslations1 = _repository.AllAppealToRectorTranslation(queryNum, pageNum, language_code, start_time, end_time);
            var AppealToRectortranslations = _mapper.Map<IEnumerable<AppealToRectorTranslationReadedDTO>>(AppealToRectortranslations1);
            if (AppealToRectortranslations == null) { }

            return Ok(AppealToRectortranslations);
        }

        [Authorize(Roles = "Admin,VirtualReception")]
        [HttpGet("getbyidappealtorectortranslation/{id}")]
        public IActionResult GetByIdAppealToRectorTranslation(int id)
        {

            AppealToRectorTranslation AppealToRectortranslation1 = _repository.GetAppealToRectorTranslationById(id);
            var AppealToRectortranslation = _mapper.Map<AppealToRectorTranslationReadedDTO>(AppealToRectortranslation1);
            if (AppealToRectortranslation == null) { }

            return Ok(AppealToRectortranslation);
        }

        [Authorize(Roles = "Admin,VirtualReception")]
        [HttpPut("updateappealtorectortranslation/{id}")]
        public IActionResult UpdateAppealToRectorTranslation(bool confirm, int id)
        {
            try
            {
                var AppealToRectortranslationch = _repository.GetAppealToRectorTranslationById(id);
                AppealToRectorTranslationUpdatedDTO AppealToRectortranslation1 = new AppealToRectorTranslationUpdatedDTO()
                {
                    confirm = confirm,
                };
                if (AppealToRectortranslationch == null || AppealToRectortranslation1 == null)
                {
                    return BadRequest();
                }
                var appeal = _mapper.Map<AppealToRectorTranslation>(AppealToRectortranslation1);
                bool upcheck = _repository.UpdateAppealToRectorTranslation(id, appeal);
                if (!upcheck)
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

        [StaticAuth]
        [HttpGet("getallappealtorectortranslationemailstatus/{email}")]
        public IActionResult GetAllAppealToRectorTranslationEmailStatus(string email, string language_code)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            if (token == SessionClass.tokenCheck || token == SessionClass.token)
            {

                IEnumerable<AppealToRectorTranslation> AppealToRectors1 = _repository.GetByAppealStatusTranslation(email, language_code);
                var AppealToRectorsTranslation = _mapper.Map<IEnumerable<AppealTranslationEmailCheckStatusDTO>>(AppealToRectors1);
                if (AppealToRectorsTranslation == null) { }

                return Ok(AppealToRectorsTranslation);
            }
            return Unauthorized();

        }



    }
}
