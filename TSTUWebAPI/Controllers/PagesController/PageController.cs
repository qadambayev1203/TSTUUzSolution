using AutoMapper;
using Contracts.AllRepository.PagesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.PageDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.PagesModel;
using Entities.Model.PersonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.PagesController
{
    [Route("api/page")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public PageController(IPageRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // page CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createpage")]
        public IActionResult Createpage(PageCreatedDTO page1)
        {
            var page = _mapper.Map<Pages>(page1);
            page.user_id = SessionClass.id;
            page.status_id = _status.GetStatusId("Active");

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(page1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                page.img_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }


            int check = _repository.CreatePage(page);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
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
        [HttpGet("getallpage")]
        public IActionResult GetAllpage(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Pages> pages1 = _repository.AllPage(queryNum, pageNum);
            var pages = _mapper.Map<IEnumerable<PageReadedDTO>>(pages1);
            if (pages == null) { }

            return Ok(pages);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallpageselect")]
        public IActionResult GetAllpageSelect()
        {

            IEnumerable<Pages> pages1 = _repository.AllPageSelect();
            var pages = _mapper.Map<IEnumerable<PageReadedSelectDTO>>(pages1);
            if (pages == null) { }

            return Ok(pages);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidpage/{id}")]
        public IActionResult GetByIdpage(int id)
        {

            Pages page1 = _repository.GetPageById(id);
            var page = _mapper.Map<PageReadedDTO>(page1);
            if (page == null) { }
            return Ok(page);
        }

        [HttpGet("sitegetallpage")]
        public IActionResult GetAllpagesite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Pages> pages1 = _repository.AllPageSite(queryNum, pageNum);
            var pages = _mapper.Map<IEnumerable<PageReadedSiteDTO>>(pages1);
            if (pages == null) { }

            return Ok(pages);
        }

        [HttpGet("sitegetbyidpage/{id}")]
        public IActionResult GetByIdpagesite(int id)
        {

            Pages page1 = _repository.GetPageByIdSite(id);
            var page = _mapper.Map<PageReadedSiteDTO>(page1);
            if (page == null) { }
            return Ok(page);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletepage/{id}")]
        public IActionResult Deletepage(int id)
        {
            bool check = _repository.DeletePage(id);
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
        [HttpPut("updatepage/{id}")]
        public IActionResult Updatepage(PageUpdatedDTO page1, int id)
        {
            try
            {
                if (page1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<Pages>(page1);
                dbupdated.updated_at = DateTime.UtcNow;

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(page1.img_up);
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

                bool updatedcheck = _repository.UpdatePage(id, dbupdated);
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







        //pageTranslation CRUD
        [Authorize(Roles = "Admin")]
        [HttpPost("createpagetranslation")]
        public IActionResult CreatepageTranslation(PageTranslationCreatedDTO pagetranslation1)
        {
            var pagetranslation = _mapper.Map<PageTranslation>(pagetranslation1);
            pagetranslation.user_id = SessionClass.id;
            pagetranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)pagetranslation.language_id);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(pagetranslation1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }

            if (Url != null && Url.Length > 0)
            {
                pagetranslation.img_translation_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }

            int check = _repository.CreatePageTranslation(pagetranslation);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
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
        [HttpGet("getallpagetranslation")]
        public IActionResult GetAllpageTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PageTranslation> pagetranslationes1 = _repository.AllPageTranslation(queryNum, pageNum, language_code);
            var pagetranslationes = _mapper.Map<IEnumerable<PageTranslationReadedDTO>>(pagetranslationes1);
            if (pagetranslationes == null) { }
            return Ok(pagetranslationes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallpagetranslationselect/{language_code}")]
        public IActionResult GetAllpageTranslationSelect(string language_code)
        {

            IEnumerable<PageTranslation> pages1 = _repository.AllPageTranslationSelect(language_code);
            var pages = _mapper.Map<IEnumerable<PageTranslationReadedSelectDTO>>(pages1);
            if (pages == null) { }

            return Ok(pages);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidpagetranslation/{uz_id}")]
        public IActionResult GetByIdpageTranslation(int uz_id, string language_code)
        {
            PageTranslation pagetranslation1 = _repository.GetPageTranslationById(uz_id, language_code);
            var pagetranslation = _mapper.Map<PageTranslationReadedDTO>(pagetranslation1);
            if (pagetranslation == null) { }
            return Ok(pagetranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidpagetranslation/{id}")]
        public IActionResult GetByIdpageTranslation(int id)
        {
            PageTranslation pagetranslation1 = _repository.GetPageTranslationById(id);
            var pagetranslation = _mapper.Map<PageTranslationReadedDTO>(pagetranslation1);
            if (pagetranslation == null) { }
            return Ok(pagetranslation);
        }

        [HttpGet("sitegetallpagetranslation")]
        public IActionResult GetAllpageTranslationsite(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PageTranslation> pagetranslationes1 = _repository.AllPageTranslationSite(queryNum, pageNum, language_code);
            var pagetranslationes = _mapper.Map<IEnumerable<PageTranslationReadedSiteDTO>>(pagetranslationes1);
            if (pagetranslationes == null) { }
            return Ok(pagetranslationes);
        }

        [HttpGet("sitegetbyuzidpagetranslation/{uz_id}")]
        public IActionResult GetByIdpageTranslationsite(int uz_id, string language_code)
        {
            PageTranslation pagetranslation1 = _repository.GetPageTranslationByIdSite(uz_id, language_code);
            var pagetranslation = _mapper.Map<PageTranslationReadedSiteDTO>(pagetranslation1);
            if (pagetranslation == null) { }
            return Ok(pagetranslation);
        }

        [HttpGet("sitegetbyidpagetranslation/{id}")]
        public IActionResult GetByIdpageTranslationsite(int id)
        {
            PageTranslation pagetranslation1 = _repository.GetPageTranslationByIdSite(id);
            var pagetranslation = _mapper.Map<PageTranslationReadedSiteDTO>(pagetranslation1);
            if (pagetranslation == null) { }
            return Ok(pagetranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletepagetranslation/{id}")]
        public IActionResult DeletepageTranslation(int id)
        {
            bool check = _repository.DeletePageTranslation(id);
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
        [HttpPut("updatepagetranslation/{id}")]
        public IActionResult UpdatepageTranslation(PageTranslationUpdatedDTO pagetranslation1, int id)
        {
            try
            {
                if (pagetranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<PageTranslation>(pagetranslation1);
                dbupdated.updated_at = DateTime.UtcNow;

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(pagetranslation1.img_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }

                if (Url != null && Url.Length > 0)
                {
                    dbupdated.img_translation_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }



                bool updatedcheck = _repository.UpdatePageTranslation(id, dbupdated);
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
