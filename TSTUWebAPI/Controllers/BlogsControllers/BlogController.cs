using AutoMapper;
using Contracts.AllRepository.BlogsRepository;
using Entities.DTO.BlogsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.BlogsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.BlogsControllers
{
    [Route("api/blogcontroller")]
    [Authorize]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        public BlogController(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        #region Blog CRUD

        [Authorize(Roles="Admin")]       [HttpPost("createblog")]
        public IActionResult CreateBlog(BlogCreatedDTO blog1)
        {
            var blog = _mapper.Map<Blog>(blog1);
            int check = _repository.CreateBlog(blog);

            if (check == 0)
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

        [Authorize(Roles="Admin")]       [HttpGet("getallblog")]
        public IActionResult GetAllBlog(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Blog> blogs1 = _repository.AllBlog(queryNum, pageNum);
            var blogs = _mapper.Map<IEnumerable<BlogReadedDTO>>(blogs1);
            if (blogs == null || blogs.Count() == 0) { return NotFound(); }
            return Ok(blogs);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidblog/{id}")]
        public IActionResult GetByIdBlog(int id)
        {

            Blog blog1 = _repository.GetBlogById(id);
            if (blog1 == null)
            {
                return NotFound();
            }
            var blog = _mapper.Map<BlogReadedDTO>(blog1);
            if (blog == null) { return NotFound(); }

            return Ok(blog);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteblog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            bool check = _repository.DeleteBlog(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updateblog/{id}")]
        public IActionResult UpdateBlog(BlogUpdatedDTO blog1, int id)
        {
            try
            {
                var blog = GetByIdBlog(id);
                if (blog1 == null || blog == null)
                {
                    return StatusCode(400);
                }
                _mapper.Map(blog1, blog);
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

        #endregion





        #region BlogTranslation CRUD

        [Authorize(Roles="Admin")]       [HttpPost("createblogtranslation")]
        public IActionResult CreateBlogTranslation(BlogTranslationCreatedDTO blogtranslation1)
        {
            var blogtranslation = _mapper.Map<BlogTranslation>(blogtranslation1);
            int check = _repository.CreateBlogTranslation(blogtranslation);

            if (check == 0)
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

        [Authorize(Roles="Admin")]       [HttpGet("getallblogtranslation")]
        public IActionResult GetAllBlogTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<BlogTranslation> blogtranslations1 = _repository.AllBlogTranslation(queryNum, pageNum, language_code);
            var blogtranslations = _mapper.Map<IEnumerable<BlogTranslationReadedDTO>>(blogtranslations1);
            if (blogtranslations == null || blogtranslations.Count() == 0) { return NotFound(); }
            return Ok(blogtranslations);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyidblogtranslation/{id}")]
        public IActionResult GetByIdBlogTranslation(int id)
        {

            BlogTranslation blogtranslation1 = _repository.GetBlogTranslationById(id);
            var blogtranslation = _mapper.Map<BlogTranslationReadedDTO>(blogtranslation1);
            if (blogtranslation == null) { return NotFound(); }
            return Ok(blogtranslation);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deleteblogtranslation/{id}")]
        public IActionResult DeleteBlogTranslation(int id)
        {
            bool check = _repository.DeleteBlogTranslation(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updateblogtranslation/{id}")]
        public IActionResult UpdateBlogTranslation(BlogTranslationUpdatedDTO blogtranslation1, int id)
        {
            try
            {
                var blogtranslation = GetByIdBlogTranslation(id);
                if (blogtranslation1 == null || blogtranslation == null)
                {
                    return StatusCode(400);
                }
                _mapper.Map(blogtranslation1, blogtranslation);
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
        #endregion
    }
}
