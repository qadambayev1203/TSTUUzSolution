using AutoMapper;
using Contracts.AllRepository.PagesRepository;
using Entities.DTO.PageDTOS;
using Entities.Model.LanguagesModel;
using Entities.Model.PagesModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.PagesController
{
    [Route("api/page")]
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

        [HttpPost("createpage")]
        public IActionResult Createpage(PageCreatedDTO page1)
        {
            var page = _mapper.Map<Pages>(page1);
            bool check = _repository.CreatePage(page);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallpage")]
        public IActionResult GetAllpage(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Pages> pages1 = _repository.AllPage(queryNum, pageNum);
            var pages = _mapper.Map<IEnumerable<PageReadedDTO>>(pages1);
            if (pages == null) { return NotFound(); }

            return Ok(pages);
        }

        [HttpGet("getbyidpage/{id}")]
        public IActionResult GetByIdpage(int id)
        {

            Pages page1 = _repository.GetPageById(id);
            var page = _mapper.Map<PageReadedDTO>(page1);
            if (page == null) { return NotFound(); }
            return Ok(page);
        }


        [HttpDelete("deletepage/{id}")]
        public IActionResult Deletepage(int id)
        {
            bool check = _repository.DeletePage(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatepage/{id}")]
        public IActionResult Updatepage(PageUpdatedDTO page1, int id)
        {
            try
            {
                if (page1 == null)
                {
                    return BadRequest();
                }
                var page = _mapper.Map<Pages>(page1);
                bool check = _repository.UpdatePage(id,page);
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
        [HttpPost("createpagetranslation")]
        public IActionResult CreatepageTranslation(PageTranslationCreatedDTO pagetranslation1)
        {
            var pagetranslation = _mapper.Map<PageTranslation>(pagetranslation1);
            bool check = _repository.CreatePageTranslation(pagetranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallpagetranslation")]
        public IActionResult GetAllpageTranslation(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PageTranslation> pagetranslationes1 = _repository.AllPageTranslation(queryNum, pageNum);
            var pagetranslationes = _mapper.Map<IEnumerable<PageTranslationReadedDTO>>(pagetranslationes1);
            if (pagetranslationes == null) { return NotFound(); }
            return Ok(pagetranslationes);
        }

        [HttpGet("getbyidpagetranslation/{id}")]
        public IActionResult GetByIdpageTranslation(int id)
        {
            PageTranslation pagetranslation1 = _repository.GetPageTranslationById(id);
            var pagetranslation = _mapper.Map<PageTranslationReadedDTO>(pagetranslation1);
            if (pagetranslation == null) { return NotFound(); }
            return Ok(pagetranslation);
        }


        [HttpDelete("deletepagetranslation/{id}")]
        public IActionResult DeletepageTranslation(int id)
        {
            bool check = _repository.DeletePageTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatepagetranslation/{id}")]
        public IActionResult UpdatepageTranslation(PageTranslation pagetranslation1, int id)
        {
            try
            {
                if (pagetranslation1 == null)
                {
                    return BadRequest();
                }
                var pagetranslation = _mapper.Map<PageTranslation>(pagetranslation1);
                bool check = _repository.UpdatePageTranslation(id,pagetranslation);
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
