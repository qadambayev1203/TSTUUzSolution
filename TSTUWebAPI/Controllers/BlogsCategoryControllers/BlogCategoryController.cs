using AutoMapper;
using Contracts.AllRepository.BlogsCategoryRepository;
using Entities.DTO.BlogsCategoryDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.BlogsCategoryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.BlogsCategoryControllers
{
    [Route("api/blogcategorycontroller")]
    [Authorize]
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

        [Authorize(Roles="Admin")]       [HttpPost("createblogcategory")]
        public IActionResult CreateBlogCategory(BlogCategoryCreatedDTO blogCategory1)
        {
            var blogCategory = _mapper.Map<BlogCategory>(blogCategory1);
            int check = _repository.CreateBlogCategory(blogCategory);

            if (check==0)
            {
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getallblogcategory")]
        public IActionResult GetAllBlogCategory(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<BlogCategory> blogCategorys1 = _repository.AllBlogCategory(queryNum, pageNum);
            var blogCategorys = _mapper.Map<IEnumerable<BlogCategoryReadedDTO>>(blogCategorys1);
            if (blogCategorys == null || blogCategorys.Count() == 0) { return NotFound(); }
            return Ok(blogCategorys);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidblogcategory/{id}")]
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


        [Authorize(Roles="Admin")]       [HttpDelete("deleteblogcategory/{id}")]
        public IActionResult DeleteBlogCategory(int id)
        {
            bool check = _repository.DeleteBlogCategory(id);
            if (!check)
            {
                return StatusCode(400);
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [Authorize(Roles="Admin")]       [HttpPut("updateblogcategory/{id}")]
        public IActionResult UpdateBlogCategory(BlogCategoryUpdatedDTO blogCategory1, int id)
        {
            try
            {
                if (blogCategory1 == null)
                {
                    return StatusCode(400);
                }
                var BlogCategory = _repository.GetBlogCategoryById(id);
                if(BlogCategory == null)
                {
                    return BadRequest();
                }
                _mapper.Map(blogCategory1, BlogCategory);
                bool check = _repository.SaveChanges();
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
        [Authorize(Roles="Admin")]       [HttpPost("createblogcategorytranslation")]
        public IActionResult CreateBlogCategoryTranslation(BlogCategoryTranslationCreatedDTO blogCategorytranslation1)
        {
            var blogCategorytranslation = _mapper.Map<BlogCategoryTranslation>(blogCategorytranslation1);
            int check = _repository.CreateBlogCategoryTranslation(blogCategorytranslation);

            if (check==0)
            {
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getallblogcategorytranslation")]
        public IActionResult GetAllBlogCategoryTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<BlogCategoryTranslation> blogCategorytranslations1 = _repository.AllBlogCategoryTranslation(queryNum, pageNum, language_code);
            var blogCategorytranslations = _mapper.Map<IEnumerable<BlogCategoryTranslationReadedDTO>>(blogCategorytranslations1);
            if (blogCategorytranslations == null || blogCategorytranslations.Count() == 0) { return NotFound(); }
            return Ok(blogCategorytranslations);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidblogcategorytranslation/{id}")]
        public IActionResult GetByIdBlogCategoryTranslation(int id)
        {

            BlogCategoryTranslation blogCategorytranslation1 = _repository.GetBlogCategoryTranslationById(id);
            var blogCategorytranslation = _mapper.Map<BlogCategoryTranslationReadedDTO>(blogCategorytranslation1);
            if (blogCategorytranslation == null) { return NotFound(); }
            return Ok(blogCategorytranslation);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteblogcategorytranslation/{id}")]
        public IActionResult DeleteBlogCategoryTranslation(int id)
        {
            bool check = _repository.DeleteBlogCategoryTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [Authorize(Roles="Admin")]       [HttpPut("updateblogcategorytranslation/{id}")]
        public IActionResult UpdateBlogCategoryTranslation(BlogCategoryTranslationUpdatedDTO blogCategorytranslation1, int id)
        {
            try
            {
                if (blogCategorytranslation1 == null)
                {
                    return StatusCode(400);
                }
                var blogCategorytranslation = _repository.GetBlogCategoryTranslationById(id);
                if (blogCategorytranslation == null)
                {
                    return StatusCode(400);
                }
                _mapper.Map(blogCategorytranslation1, blogCategorytranslation);
                bool check = _repository.SaveChanges();
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
