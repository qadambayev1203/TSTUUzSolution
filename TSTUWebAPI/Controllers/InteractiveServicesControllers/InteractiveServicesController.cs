using AutoMapper;
using Contracts.AllRepository.InteractiveServicesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.InteractiveServicesDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.InteractiveServicesModel;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Entities.Model.SiteDetailsModel;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.InteractiveServicesControllers
{
    [Route("api/interactiveservices")]
    [ApiController]
    public class InteractiveServicesController : ControllerBase
    {
        private readonly IInteractiveServicesRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public InteractiveServicesController(IInteractiveServicesRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // InteractiveServices CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createinteractiveservices")]
        public IActionResult CreateInteractiveServices(InteractiveServicesCreatedDTO InteractiveServices1)
        {
            var InteractiveServices = _mapper.Map<InteractiveServices>(InteractiveServices1);
            InteractiveServices.status_id = _status.GetStatusId("Active");


            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(InteractiveServices1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }

            if (Url != null && Url.Length > 0)
            {
                InteractiveServices.img_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }
            var Url1 = fileUpload.SaveFileAsync(InteractiveServices1.icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                InteractiveServices.icon_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            int id = _repository.CreateInteractiveServices(InteractiveServices);

            if (id == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                fileUpload.DeleteFileAsync(Url1);
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
        [HttpGet("getallinteractiveservices")]
        public IActionResult GetAllInteractiveServices(int queryNum, int pageNum, bool? favorite)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<InteractiveServices> InteractiveServicess1 = _repository.AllInteractiveServices(queryNum, pageNum, favorite);
            var InteractiveServicess = _mapper.Map<IEnumerable<InteractiveServicesReadedDTO>>(InteractiveServicess1);
            if (InteractiveServicess == null) { }

            return Ok(InteractiveServicess);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidinteractiveservices/{id}")]
        public IActionResult GetByIdInteractiveServices(int id)
        {

            InteractiveServices InteractiveServices1 = _repository.GetInteractiveServicesById(id);
            if (InteractiveServices1 == null)
            {

            }
            var InteractiveServices = _mapper.Map<InteractiveServicesReadedDTO>(InteractiveServices1);
            if (InteractiveServices == null) { }
            return Ok(InteractiveServices);
        }

        [HttpGet("sitegetallinteractiveservices")]
        public IActionResult GetAllInteractiveServicessite(int queryNum, int pageNum, bool? favorite)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<InteractiveServices> InteractiveServicess1 = _repository.AllInteractiveServicesSite(queryNum, pageNum, favorite);
            var InteractiveServicess = _mapper.Map<IEnumerable<InteractiveServicesReadedSiteDTO>>(InteractiveServicess1);
            if (InteractiveServicess == null) { }

            return Ok(InteractiveServicess);
        }

        [HttpGet("sitegetbyidinteractiveservices/{id}")]
        public IActionResult GetByIdInteractiveServicessite(int id)
        {

            InteractiveServices InteractiveServices1 = _repository.GetInteractiveServicesByIdSite(id);
            if (InteractiveServices1 == null)
            {

            }
            var InteractiveServices = _mapper.Map<InteractiveServicesReadedSiteDTO>(InteractiveServices1);
            if (InteractiveServices == null) { }
            return Ok(InteractiveServices);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteinteractiveservices/{id}")]
        public IActionResult DeleteInteractiveServices(int id)
        {
            bool check = _repository.DeleteInteractiveServices(id);
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
        [HttpPut("updateinteractiveservices/{id}")]
        public IActionResult UpdateInteractiveServices(InteractiveServicesUpdatedDTO InteractiveServices1, int id)
        {
            try
            {
                if (InteractiveServices1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<InteractiveServices>(InteractiveServices1);

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(InteractiveServices1.img_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }

                if (Url != null && Url.Length > 0)
                {
                    dbupdated.img_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }
                var Url1 = fileUpload.SaveFileAsync(InteractiveServices1.icon_up);
                if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url1 != null && Url1.Length > 0)
                {
                    dbupdated.icon_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url1
                    };
                }

                bool updatedcheck = _repository.UpdateInteractiveServices(id, dbupdated);
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







        //InteractiveServicesTranslation CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createinteractiveservicestranslation")]
        public IActionResult CreateInteractiveServicesTranslation(InteractiveServicesTranslationCreatedDTO InteractiveServicestranslation1)
        {
            var InteractiveServicestranslation = _mapper.Map<InteractiveServicesTranslation>(InteractiveServicestranslation1);
            InteractiveServicestranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)InteractiveServicestranslation.language_id);


            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(InteractiveServicestranslation1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }

            if (Url != null && Url.Length > 0)
            {
                InteractiveServicestranslation.img_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }
            var Url1 = fileUpload.SaveFileAsync(InteractiveServicestranslation1.icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                InteractiveServicestranslation.icon_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            int id = _repository.CreateInteractiveServicesTranslation(InteractiveServicestranslation);
            if (id == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                fileUpload.DeleteFileAsync(Url1);
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
        [HttpGet("getallinteractiveservicestranslation")]
        public IActionResult GetAllInteractiveServicesTranslation(int queryNum, int pageNum, string? language_code, bool? favorite)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<InteractiveServicesTranslation> InteractiveServicestranslations1 = _repository.AllInteractiveServicesTranslation(queryNum, pageNum, language_code, favorite);
            var InteractiveServicestranslations = _mapper.Map<IEnumerable<InteractiveServicesTranslationReadedDTO>>(InteractiveServicestranslations1);
            if (InteractiveServicestranslations == null) { }

            return Ok(InteractiveServicestranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidinteractiveservicestranslation/{uz_id}")]
        public IActionResult GetByIdInteractiveServicesTranslation(int uz_id, string language_code)
        {

            InteractiveServicesTranslation InteractiveServicestranslation1 = _repository.GetInteractiveServicesTranslationById(uz_id, language_code);
            var InteractiveServicestranslation = _mapper.Map<InteractiveServicesTranslationReadedDTO>(InteractiveServicestranslation1);
            if (InteractiveServicestranslation == null) { }

            return Ok(InteractiveServicestranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidinteractiveservicestranslation/{id}")]
        public IActionResult GetByIdInteractiveServicesTranslation(int id)
        {

            InteractiveServicesTranslation InteractiveServicestranslation1 = _repository.GetInteractiveServicesTranslationById(id);
            var InteractiveServicestranslation = _mapper.Map<InteractiveServicesTranslationReadedDTO>(InteractiveServicestranslation1);
            if (InteractiveServicestranslation == null) { }

            return Ok(InteractiveServicestranslation);
        }

        [HttpGet("sitegetallinteractiveservicestranslation")]
        public IActionResult GetAllInteractiveServicesTranslationsite(int queryNum, int pageNum, string? language_code, bool? favorite)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<InteractiveServicesTranslation> InteractiveServicestranslations1 = _repository.AllInteractiveServicesTranslationSite(queryNum, pageNum, language_code, favorite);
            var InteractiveServicestranslations = _mapper.Map<IEnumerable<InteractiveServicesTranslationReadedSiteDTO>>(InteractiveServicestranslations1);
            if (InteractiveServicestranslations == null) { }

            return Ok(InteractiveServicestranslations);
        }

        [HttpGet("sitegetbyuzidinteractiveservicestranslation/{uz_id}")]
        public IActionResult GetByIdInteractiveServicesTranslationsite(int uz_id, string language_code)
        {

            InteractiveServicesTranslation InteractiveServicestranslation1 = _repository.GetInteractiveServicesTranslationByIdSite(uz_id, language_code);
            var InteractiveServicestranslation = _mapper.Map<InteractiveServicesTranslationReadedSiteDTO>(InteractiveServicestranslation1);
            if (InteractiveServicestranslation == null) { }

            return Ok(InteractiveServicestranslation);
        }

        [HttpGet("sitegetbyidinteractiveservicestranslation/{id}")]
        public IActionResult GetByIdInteractiveServicesTranslationsite(int id)
        {

            InteractiveServicesTranslation InteractiveServicestranslation1 = _repository.GetInteractiveServicesTranslationByIdSite(id);
            var InteractiveServicestranslation = _mapper.Map<InteractiveServicesTranslationReadedSiteDTO>(InteractiveServicestranslation1);
            if (InteractiveServicestranslation == null) { }

            return Ok(InteractiveServicestranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteinteractiveservicestranslation/{id}")]
        public IActionResult DeleteInteractiveServicesTranslation(int id)
        {
            bool check = _repository.DeleteInteractiveServicesTranslation(id);
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
        [HttpPut("updateinteractiveservicestranslation/{id}")]
        public IActionResult UpdateInteractiveServicesTranslation(InteractiveServicesTranslationUpdatedDTO InteractiveServicestranslation1, int id)
        {
            try
            {
                if (InteractiveServicestranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<InteractiveServicesTranslation>(InteractiveServicestranslation1);

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(InteractiveServicestranslation1.img_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }

                if (Url != null && Url.Length > 0)
                {
                    dbupdated.img_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }
                var Url1 = fileUpload.SaveFileAsync(InteractiveServicestranslation1.icon_up);
                if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url1 != null && Url1.Length > 0)
                {
                    dbupdated.icon_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url1
                    };
                }

                bool updatedcheck = _repository.UpdateInteractiveServicesTranslation(id, dbupdated);
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
