using AutoMapper;
using Contracts.AllRepository.BlogsCategoryRepository;
using Entities.DTO.BlogsCategoryDTOS;
using Entities.Model.BlogsCategoryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.BlogsCategoryControllers
{
    [Route("api/blogcategorycontroller")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IBlogCategoryRepository _repository;
        private readonly IMapper _mapper;
        public BlogCategoryController(IBlogCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // BlogCategory CRUD

        [HttpPost("createblogcategory")]
        public IActionResult CreateBlogCategory(BlogCategoryCreatedDTO blogCategory1)
        {
            var blogCategory = _mapper.Map<BlogCategory>(blogCategory1);
            bool check = _repository.CreateBlogCategory(blogCategory);

            if (!check)
            {
                return StatusCode(400);
            }

            return Ok();
        }

        [HttpGet("getallblogcategory")]
        public IActionResult GetAllBlogCategory(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<BlogCategory> blogCategorys1 = _repository.AllBlogCategory(queryNum, pageNum);
            var blogCategorys = _mapper.Map<IEnumerable<BlogCategoryReadedDTO>>(blogCategorys1);
            if (blogCategorys == null) { return NotFound(); }
            return Ok(blogCategorys);
        }

        [HttpGet("getbyidblogcategory/{id}")]
        public IActionResult GetByIdBlogCategory(int id)
        {

            BlogCategory blogCategory1 = _repository.GetBlogCategoryById(id);
            if (blogCategory1 == null)
            {
                return NotFound();
            }
            var blogCategory = _mapper.Map<BlogCategoryReadedDTO>(blogCategory1);
            if (blogCategory == null) { return NotFound(); }

            return Ok(blogCategory);
        }


        [HttpDelete("deleteblogcategory/{id}")]
        public IActionResult DeleteBlogCategory(int id)
        {
            bool check = _repository.DeleteBlogCategory(id);
            if (!check)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [HttpPut("updateblogcategory/{id}")]
        public IActionResult UpdateBlogCategory(BlogCategoryUpdatedDTO blogCategory1, int id)
        {
            try
            {
                if (blogCategory1 == null)
                {
                    return StatusCode(400);
                }
                var blogCategory = _mapper.Map<BlogCategory>(blogCategory1);
                bool check = _repository.UpdateBlogCategory(id, blogCategory);
                if (!check)
                {
                    return StatusCode(400);
                }
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }

        }







        //BlogCategoryTranslation CRUD
        [HttpPost("createblogcategorytranslation")]
        public IActionResult CreateBlogCategoryTranslation(BlogCategoryTranslationCreatedDTO blogCategorytranslation1)
        {
            var blogCategorytranslation = _mapper.Map<BlogCategoryTranslation>(blogCategorytranslation1);
            bool check = _repository.CreateBlogCategoryTranslation(blogCategorytranslation);

            if (!check)
            {
                return StatusCode(400);
            }

            return Ok();
        }

        [HttpGet("getallblogcategorytranslation")]
        public IActionResult GetAllBlogCategoryTranslation(int queryNum, int pageNum, string language_code )
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<BlogCategoryTranslation> blogCategorytranslations1 = _repository.AllBlogCategoryTranslation(queryNum, pageNum, language_code);
            var blogCategorytranslations = _mapper.Map<IEnumerable<BlogCategoryTranslationReadedDTO>>(blogCategorytranslations1);
            if (blogCategorytranslations == null) { return NotFound(); }
            return Ok(blogCategorytranslations);
        }

        [HttpGet("getbyidblogcategorytranslation/{id}")]
        public IActionResult GetByIdBlogCategoryTranslation(int id)
        {

            BlogCategoryTranslation blogCategorytranslation1 = _repository.GetBlogCategoryTranslationById(id);
            var blogCategorytranslation = _mapper.Map<BlogCategoryTranslationReadedDTO>(blogCategorytranslation1);
            if (blogCategorytranslation == null) { return NotFound(); }
            return Ok(blogCategorytranslation);
        }


        [HttpDelete("deleteblogcategorytranslation/{id}")]
        public IActionResult DeleteBlogCategoryTranslation(int id)
        {
            bool check = _repository.DeleteBlogCategoryTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [HttpPut("updateblogcategorytranslation/{id}")]
        public IActionResult UpdateBlogCategoryTranslation(BlogCategoryTranslationUpdatedDTO blogCategorytranslation1, int id)
        {
            try
            {
                if (blogCategorytranslation1 == null)
                {
                    return StatusCode(400);
                }
                var blogCategorytranslation = _mapper.Map<BlogCategoryTranslation>(blogCategorytranslation1);
                bool check = _repository.UpdateBlogCategoryTranslation(id, blogCategorytranslation);
                if (!check)
                {
                    return StatusCode(400);
                }
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }

        }
    }
}
