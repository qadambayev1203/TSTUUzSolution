using AutoMapper;
using Contracts.AllRepository.BlogsRepository;
using Entities.DTO.BlogsDTOS;
using Entities.Model.BlogsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.BlogsControllers
{
    [Route("api/blogcontroller")]
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

        [HttpPost("createblog")]
        public IActionResult CreateBlog(BlogCreatedDTO blog1)
        {
            var blog = _mapper.Map<Blog>(blog1);
            bool check = _repository.CreateBlog(blog);

            if (!check)
            {
                return StatusCode(400);
            }

            return Ok();
        }

        [HttpGet("getallblog")]
        public IActionResult GetAllBlog(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Blog> blogs1 = _repository.AllBlog(queryNum, pageNum);
            var blogs = _mapper.Map<IEnumerable<BlogReadedDTO>>(blogs1);
            if (blogs == null||blogs.Count() == 0) { return NotFound(); }
            return Ok(blogs);
        }

        [HttpGet("getbyidblog/{id}")]
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


        [HttpDelete("deleteblog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            bool check = _repository.DeleteBlog(id);
            if (!check)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [HttpPut("updateblog/{id}")]
        public IActionResult UpdateBlog(BlogUpdatedDTO blog1, int id)
        {
            try
            {
                if (blog1 == null)
                {
                    return StatusCode(400);
                }
                var blog = _mapper.Map<Blog>(blog1);
                bool check = _repository.UpdateBlog(id, blog);
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

        [HttpPost("createblogtranslation")]
        public IActionResult CreateBlogTranslation(BlogTranslationCreatedDTO blogtranslation1)
        {
            var blogtranslation = _mapper.Map<BlogTranslation>(blogtranslation1);
            bool check = _repository.CreateBlogTranslation(blogtranslation);

            if (!check)
            {
                return StatusCode(400);
            }

            return Ok();
        }

        [HttpGet("getallblogtranslation")]
        public IActionResult GetAllBlogTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<BlogTranslation> blogtranslations1 = _repository.AllBlogTranslation(queryNum, pageNum, language_code);
            var blogtranslations = _mapper.Map<IEnumerable<BlogTranslationReadedDTO>>(blogtranslations1);
            if (blogtranslations == null||blogtranslations.Count() == 0) { return NotFound(); }
            return Ok(blogtranslations);
        }

        [HttpGet("getbyidblogtranslation/{id}")]
        public IActionResult GetByIdBlogTranslation(int id)
        {

            BlogTranslation blogtranslation1 = _repository.GetBlogTranslationById(id);
            var blogtranslation = _mapper.Map<BlogTranslationReadedDTO>(blogtranslation1);
            if (blogtranslation == null) { return NotFound(); }
            return Ok(blogtranslation);
        }


        [HttpDelete("deleteblogtranslation/{id}")]
        public IActionResult DeleteBlogTranslation(int id)
        {
            bool check = _repository.DeleteBlogTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [HttpPut("updateblogtranslation/{id}")]
        public IActionResult UpdateBlogTranslation(BlogTranslationUpdatedDTO blogtranslation1, int id)
        {
            try
            {
                if (blogtranslation1 == null)
                {
                    return StatusCode(400);
                }
                var blogtranslation = _mapper.Map<BlogTranslation>(blogtranslation1);
                bool check = _repository.UpdateBlogTranslation(id, blogtranslation);
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
