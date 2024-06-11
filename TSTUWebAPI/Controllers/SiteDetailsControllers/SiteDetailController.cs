using AutoMapper;
using Contracts.AllRepository.SiteDetailsRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.SiteDetailDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.FileModel;
using Entities.Model.SiteDetailsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.SiteDetailDetailsControllers
{
    [Route("api/sitedetail")]
    [ApiController]
    public class SiteDetailController : ControllerBase
    {
        private readonly ISiteDetailRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public SiteDetailController(ISiteDetailRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // SiteDetail CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createsitedetail")]
        public IActionResult CreateSiteDetail(SiteDetailCreatedDTO siteDetail1)
        {
            var siteDetail = _mapper.Map<SiteDetail>(siteDetail1);
            siteDetail.status_id = _status.GetStatusId("Active");


            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(siteDetail1.logo_b_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }

            if (Url != null && Url.Length > 0)
            {
                siteDetail.logo_b_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }
            var Url1 = fileUpload.SaveFileAsync(siteDetail1.logo_w_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                siteDetail.logo_w_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            var Url2 = fileUpload.SaveFileAsync(siteDetail1.favicon_up);
            if (Url2 == "File not found or empty!" || Url2 == "Invalid file extension!" || Url2 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url2 != null && Url2.Length > 0)
            {
                siteDetail.favicon_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url2
                };
            }


            int check = _repository.CreateSiteDetail(siteDetail);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                fileUpload.DeleteFileAsync(Url1);
                fileUpload.DeleteFileAsync(Url2);
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
        [HttpGet("getallsitedetail")]
        public IActionResult GetAllSiteDetail(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetail> siteDetailes1 = _repository.AllSiteDetail(queryNum, pageNum);
            var siteDetailes = _mapper.Map<IEnumerable<SiteDetailReadedDTO>>(siteDetailes1);
            if (siteDetailes == null) { }
            return Ok(siteDetailes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidsitedetail/{id}")]
        public IActionResult GetByIdSiteDetail(int id)
        {

            SiteDetail siteDetail1 = _repository.GetSiteDetailById(id);
            if (siteDetail1 == null)
            {

            }
            var siteDetail = _mapper.Map<SiteDetailReadedDTO>(siteDetail1);
            if (siteDetail == null) { }
            return Ok(siteDetail);
        }

        [HttpGet("sitegetallsitedetail")]
        public IActionResult GetAllSiteDetailsite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetail> siteDetailes1 = _repository.AllSiteDetailSite(queryNum, pageNum);
            var siteDetailes = _mapper.Map<IEnumerable<SiteDetailReadedSiteDTO>>(siteDetailes1);
            if (siteDetailes == null) { }
            return Ok(siteDetailes);
        }

        [HttpGet("sitegetbyidsitedetail/{id}")]
        public IActionResult GetByIdSiteDetailsite(int id)
        {

            SiteDetail siteDetail1 = _repository.GetSiteDetailByIdSite(id);
            if (siteDetail1 == null)
            {

            }
            var siteDetail = _mapper.Map<SiteDetailReadedSiteDTO>(siteDetail1);
            if (siteDetail == null) { }
            return Ok(siteDetail);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletesitedetail/{id}")]
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

        [Authorize(Roles = "Admin")]
        [HttpPut("updatesitedetail/{id}")]
        public IActionResult UpdateSiteDetail(SiteDetailUpdatedDTO siteDetail1, int id)
        {

            try
            {
                if (siteDetail1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<SiteDetail>(siteDetail1);
                dbupdated.update_at = DateTime.UtcNow;


                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(siteDetail1.logo_b_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url != null && Url.Length > 0)
                {
                    dbupdated.logo_b_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }
                var Url1 = fileUpload.SaveFileAsync(siteDetail1.logo_w_up);
                if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url1 != null && Url1.Length > 0)
                {
                    dbupdated.logo_w_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url1
                    };
                }
                var Url2 = fileUpload.SaveFileAsync(siteDetail1.favicon_up);
                if (Url2 == "File not found or empty!" || Url2 == "Invalid file extension!" || Url2 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url2 != null && Url2.Length > 0)
                {
                    dbupdated.favicon_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url2
                    };
                }


                bool updatedcheck = _repository.UpdateSiteDetail(id, dbupdated);
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







        //SiteDetailTranslation CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createsitedetailtranslation")]
        public IActionResult CreateSiteDetailTranslation(SiteDetailTranslationCreatedDTO siteDetailtranslation1)
        {
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslation>(siteDetailtranslation1);
            siteDetailtranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)siteDetailtranslation.language_id);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(siteDetailtranslation1.logo_b_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                siteDetailtranslation.logo_b_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }
            var Url1 = fileUpload.SaveFileAsync(siteDetailtranslation1.logo_w_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                siteDetailtranslation.logo_w_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            var Url2 = fileUpload.SaveFileAsync(siteDetailtranslation1.favicon_up);
            if (Url2 == "File not found or empty!" || Url2 == "Invalid file extension!" || Url2 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url2 != null && Url2.Length > 0)
            {
                siteDetailtranslation.favicon_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url2
                };
            }


            int check = _repository.CreateSiteDetailTranslation(siteDetailtranslation);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                fileUpload.DeleteFileAsync(Url1);
                fileUpload.DeleteFileAsync(Url2);
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
        [HttpGet("getallsitedetailtranslation")]
        public IActionResult GetAllSiteDetailTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetailTranslation> siteDetailtranslationes1 = _repository.AllSiteDetailTranslation(queryNum, pageNum, language_code);
            var siteDetailtranslationes = _mapper.Map<IEnumerable<SiteDetailTranslationReadedDTO>>(siteDetailtranslationes1);
            if (siteDetailtranslationes == null) { }
            return Ok(siteDetailtranslationes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidsitedetailtranslation/{uz_id}")]
        public IActionResult GetByIdSiteDetailTranslation(int uz_id, string language_code)
        {

            SiteDetailTranslation siteDetailtranslation1 = _repository.GetSiteDetailTranslationById(uz_id, language_code);
            if (siteDetailtranslation1 == null)
            {

            }
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslationReadedDTO>(siteDetailtranslation1);
            if (siteDetailtranslation == null) { }
            return Ok(siteDetailtranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidsitedetailtranslation/{id}")]
        public IActionResult GetByIdSiteDetailTranslation(int id)
        {

            SiteDetailTranslation siteDetailtranslation1 = _repository.GetSiteDetailTranslationById(id);
            if (siteDetailtranslation1 == null)
            {

            }
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslationReadedDTO>(siteDetailtranslation1);
            if (siteDetailtranslation == null) { }
            return Ok(siteDetailtranslation);
        }

        [HttpGet("sitegetallsitedetailtranslation")]
        public IActionResult GetAllSiteDetailTranslationsite(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<SiteDetailTranslation> siteDetailtranslationes1 = _repository.AllSiteDetailTranslationSite(queryNum, pageNum, language_code);
            var siteDetailtranslationes = _mapper.Map<IEnumerable<SiteDetailTranslationReadedSiteDTO>>(siteDetailtranslationes1);
            if (siteDetailtranslationes == null) { }
            return Ok(siteDetailtranslationes);
        }

        [HttpGet("sitegetbyuzidsitedetailtranslation/{uz_id}")]
        public IActionResult GetByIdSiteDetailTranslationsite(int uz_id, string language_code)
        {

            SiteDetailTranslation siteDetailtranslation1 = _repository.GetSiteDetailTranslationByIdSite(uz_id, language_code);
            if (siteDetailtranslation1 == null)
            {

            }
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslationReadedSiteDTO>(siteDetailtranslation1);
            if (siteDetailtranslation == null) { }
            return Ok(siteDetailtranslation);
        }

        [HttpGet("sitegetbyidsitedetailtranslation/{id}")]
        public IActionResult GetByIdSiteDetailTranslationsite(int id)
        {

            SiteDetailTranslation siteDetailtranslation1 = _repository.GetSiteDetailTranslationByIdSite(id);
            if (siteDetailtranslation1 == null)
            {

            }
            var siteDetailtranslation = _mapper.Map<SiteDetailTranslationReadedSiteDTO>(siteDetailtranslation1);
            if (siteDetailtranslation == null) { }
            return Ok(siteDetailtranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletesitedetailtranslation/{id}")]
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

        [Authorize(Roles = "Admin")]
        [HttpPut("updatesitedetailtranslation/{id}")]
        public IActionResult UpdateSiteDetailTranslation(SiteDetailTranslationUpdatedDTO siteDetailtranslation1, int id)
        {
            try
            {
                if (siteDetailtranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<SiteDetailTranslation>(siteDetailtranslation1);
                dbupdated.update_at = DateTime.UtcNow;


                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(siteDetailtranslation1.logo_b_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url != null && Url.Length > 0)
                {
                    dbupdated.logo_b_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }

                var Url1 = fileUpload.SaveFileAsync(siteDetailtranslation1.logo_w_up);
                if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url1 != null && Url1.Length > 0)
                {
                    dbupdated.logo_w_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url1
                    };
                }

                var Url2 = fileUpload.SaveFileAsync(siteDetailtranslation1.favicon_up);
                if (Url2 == "File not found or empty!" || Url2 == "Invalid file extension!" || Url2 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url2 != null && Url2.Length > 0)
                {
                    dbupdated.favicon_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url2
                    };
                }


                bool updatedcheck = _repository.UpdateSiteDetailTranslation(id, dbupdated);
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
