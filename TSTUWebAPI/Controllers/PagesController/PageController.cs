using AutoMapper;
using Contracts.AllRepository.PagesRepository;
using Entities.DTO.PageDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.LanguagesModel;
using Entities.Model.PagesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.PagesController
{
    [Route("api/page")]
    [Authorize]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageRepository _repository;
        private readonly IMapper _mapper;
        public PageController(IPageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // page CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createpage")]
        public IActionResult Createpage(PageCreatedDTO page1)
        {
            var page = _mapper.Map<Pages>(page1);
            page.user_id = UserCreatedId.id;
            int check = _repository.CreatePage(page);

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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallpage")]
        public IActionResult GetAllpage(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Pages> pages1 = _repository.AllPage(queryNum, pageNum);
            var pages = _mapper.Map<IEnumerable<PageReadedDTO>>(pages1);
            if (pages == null || pages.Count() == 0) { return NotFound(); }

            return Ok(pages);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidpage/{id}")]
        public IActionResult GetByIdpage(int id)
        {

            Pages page1 = _repository.GetPageById(id);
            var page = _mapper.Map<PageReadedDTO>(page1);
            if (page == null) { return NotFound(); }
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
                var page = GetByIdpage(id);
                if (page1 == null || page == null)
                {
                    return BadRequest();
                }
                _mapper.Map(page1, page);
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
            pagetranslation.user_id = UserCreatedId.id;
            int check = _repository.CreatePageTranslation(pagetranslation);

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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallpagetranslation")]
        public IActionResult GetAllpageTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PageTranslation> pagetranslationes1 = _repository.AllPageTranslation(queryNum, pageNum, language_code);
            var pagetranslationes = _mapper.Map<IEnumerable<PageTranslationReadedDTO>>(pagetranslationes1);
            if (pagetranslationes == null || pagetranslationes.Count() == 0) { return NotFound(); }
            return Ok(pagetranslationes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidpagetranslation/{id}")]
        public IActionResult GetByIdpageTranslation(int id)
        {
            PageTranslation pagetranslation1 = _repository.GetPageTranslationById(id);
            var pagetranslation = _mapper.Map<PageTranslationReadedDTO>(pagetranslation1);
            if (pagetranslation == null) { return NotFound(); }
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
        public IActionResult UpdatepageTranslation(PageTranslation pagetranslation1, int id)
        {
            try
            {
                var page = _repository.GetPageTranslationById(id);
                if (pagetranslation1 == null || page == null)
                {
                    return BadRequest();
                }
                _mapper.Map(pagetranslation1, page);
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
