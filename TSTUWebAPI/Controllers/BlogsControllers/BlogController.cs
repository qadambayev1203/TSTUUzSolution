﻿using AutoMapper;
using Contracts.AllRepository.BlogsRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.BlogsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.BlogsModel;
using Entities.Model.FileModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.BlogsControllers;

[Route("api/blogcontroller")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public BlogController(IBlogRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    #region Blog CRUD

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpPost("createblog")]
    public IActionResult CreateBlog(BlogCreatedDTO blog1)
    {
        var blog = _mapper.Map<Blog>(blog1);
        blog.user_id = SessionClass.id;
        blog.status_id = _status.GetStatusId("Active");

        FileUploadRepository fileUpload = new FileUploadRepository();

        var Url = fileUpload.SaveFileAsync(blog1.img_up);
        if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
        {
            return BadRequest("File created error!");
        }
        if (Url != null && Url.Length > 0)
        {
            blog.img_ = new Files
            {
                title = Guid.NewGuid().ToString(),
                url = Url
            };
        }


        int check = _repository.CreateBlog(blog);

        if (check == 0)
        {
            fileUpload.DeleteFileAsync(Url);
            return StatusCode(400);
        }
        CreatedItemId createdItemId = new CreatedItemId()
        {
            id = check,
            StatusCode = 200
        };

        return Ok(createdItemId);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallblog")]
    public IActionResult GetAllBlog(int queryNum, int pageNum, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        QueryList<Blog> blogList = _repository.AllBlog(queryNum, pageNum, blog_category, favorite, start_time, end_time);
        IEnumerable<BlogReadedDTO> blogs = _mapper.Map<IEnumerable<BlogReadedDTO>>(blogList.query_list);

        ResponseModel<BlogReadedDTO> response = new ResponseModel<BlogReadedDTO>
        {
            length = blogList.length,
            list = blogs,
        };

        return Ok(blogs);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallblogselect")]
    public IActionResult GetAllBlogSelect(string? blog_category, bool? favorite)
    {
        QueryList<Blog> blogList = _repository.AllBlogSelect(blog_category, favorite);
        var blogs = _mapper.Map<IEnumerable<BlogReadedSelectDTO>>(blogList.query_list);
        ResponseModel<BlogReadedSelectDTO> response = new ResponseModel<BlogReadedSelectDTO>
        {
            length = blogList.length,
            list = blogs,
        };

        return Ok(blogs);
    }

    [HttpGet("sitegetallblog")]
    public IActionResult GetAllBlogSite(int queryNum, int pageNum, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        QueryList<Blog> blogList = _repository.AllBlogSite(queryNum, pageNum, blog_category, favorite, start_time, end_time);
        var blogs = _mapper.Map<IEnumerable<BlogReadedSiteDTO>>(blogList.query_list);
        ResponseModel<BlogReadedSiteDTO> response = new ResponseModel<BlogReadedSiteDTO>
        {
            length = blogList.length,
            list = blogs,
        };

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidblog/{id}")]
    public IActionResult GetByIdBlog(int id)
    {

        Blog blog1 = _repository.GetBlogById(id);
        if (blog1 == null)
        {

        }
        var blog = _mapper.Map<BlogReadedDTO>(blog1);
        if (blog == null) { }

        return Ok(blog);
    }

    [HttpGet("sitegetbyidblog/{id}")]
    public IActionResult GetByIdBlogSite(int id)
    {

        Blog blog1 = _repository.GetBlogByIdSite(id);
        if (blog1 == null)
        {

        }
        var blog = _mapper.Map<BlogReadedSiteDTO>(blog1);
        if (blog == null) { }

        return Ok(blog);
    }

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpDelete("deleteblog/{id}")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("updateblog/{id}")]
    public IActionResult UpdateBlog(BlogUpdatedDTO blog1, int id)
    {
        try
        {
            if (blog1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<Blog>(blog1);


            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(blog1.img_up);
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

            bool updatedcheck = _repository.UpdateBlog(id, dbupdated);
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

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpPut("updateblogmoderatorcontent/{id}")]
    public IActionResult UpdateBlogModerator(BlogUpdatedModeratorDTO blog1, int id)
    {
        try
        {
            if (blog1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<Blog>(blog1);
            dbupdated.status_id = _status.GetStatusId("Active");

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(blog1.img_up);
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

            bool updatedcheck = _repository.UpdateBlog(id, dbupdated);
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

    #endregion





    #region BlogTranslation CRUD

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpPost("createblogtranslation")]
    public IActionResult CreateBlogTranslation(BlogTranslationCreatedDTO blogtranslation1)
    {
        var blogtranslation = _mapper.Map<BlogTranslation>(blogtranslation1);
        blogtranslation.user_id = SessionClass.id;
        blogtranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)blogtranslation.language_id);

        FileUploadRepository fileUpload = new FileUploadRepository();

        var Url = fileUpload.SaveFileAsync(blogtranslation1.img_up);
        if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
        {
            return BadRequest("File created error!");
        }
        if (Url != null && Url.Length > 0)
        {
            blogtranslation.img_translation_ = new FilesTranslation
            {
                title = Guid.NewGuid().ToString(),
                url = Url
            };
        }

        int check = _repository.CreateBlogTranslation(blogtranslation);

        if (check == 0)
        {
            fileUpload.DeleteFileAsync(Url);
            return StatusCode(400);
        }
        CreatedItemId createdItemId = new CreatedItemId()
        {
            id = check,
            StatusCode = 200
        };

        return Ok(createdItemId);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallblogtranslation")]
    public IActionResult GetAllBlogTranslation(int queryNum, int pageNum, string? language_code, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        QueryList<BlogTranslation> blogList = _repository.AllBlogTranslation(queryNum, pageNum, language_code, blog_category, favorite, start_time, end_time);
        var blogtranslations = _mapper.Map<IEnumerable<BlogTranslationReadedDTO>>(blogList.query_list);
        ResponseModel<BlogTranslationReadedDTO> response = new ResponseModel<BlogTranslationReadedDTO>
        {
            length = blogList.length,
            list = blogtranslations,
        };

        return Ok(blogtranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallblogtranslationselect/{language_code}")]
    public IActionResult GetAllBlogTranslationSelect(string language_code, string? blog_category, bool? favorite)
    {

        QueryList<BlogTranslation> blogList = _repository.AllBlogTranslationSelect(language_code, blog_category, favorite);
        var blogtranslations = _mapper.Map<IEnumerable<BlogTranslationReadedSelectDTO>>(blogList.query_list);
        ResponseModel<BlogTranslationReadedSelectDTO> response = new ResponseModel<BlogTranslationReadedSelectDTO>
        {
            length = blogList.length,
            list = blogtranslations,
        };

        return Ok(blogtranslations);
    }

    [HttpGet("sitegetallblogtranslation")]
    public IActionResult GetAllBlogTranslationSite(int queryNum, int pageNum, string? language_code, string? blog_category_uz, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        QueryList<BlogTranslation> blogList = _repository.AllBlogTranslationSite(queryNum, pageNum, language_code, blog_category_uz, favorite, start_time, end_time);
        var blogtranslations = _mapper.Map<IEnumerable<BlogTranslationReadedSiteDTO>>(blogList.query_list);
        ResponseModel<BlogTranslationReadedSiteDTO> response = new ResponseModel<BlogTranslationReadedSiteDTO>
        {
            length = blogList.length,
            list = blogtranslations,
        };

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidblogtranslation/{id}")]
    public IActionResult GetByIdBlogTranslation(int id)
    {

        BlogTranslation blogtranslation1 = _repository.GetBlogTranslationById(id);
        var blogtranslation = _mapper.Map<BlogTranslationReadedDTO>(blogtranslation1);
        if (blogtranslation == null) { }
        return Ok(blogtranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidblogtranslation/{uz_id}")]
    public IActionResult GetByIdBlogTranslation(int uz_id, string language_code)
    {

        BlogTranslation blogtranslation1 = _repository.GetBlogTranslationById(uz_id, language_code);
        var blogtranslation = _mapper.Map<BlogTranslationReadedDTO>(blogtranslation1);
        if (blogtranslation == null) { }
        return Ok(blogtranslation);
    }

    [HttpGet("sitegetbyidblogtranslation/{id}")]
    public IActionResult GetByIdBlogTranslationSite(int id)
    {

        BlogTranslation blogtranslation1 = _repository.GetBlogTranslationByIdSite(id);
        var blogtranslation = _mapper.Map<BlogTranslationReadedSiteDTO>(blogtranslation1);
        if (blogtranslation == null) { }
        return Ok(blogtranslation);
    }

    [HttpGet("sitegetbyuzidblogtranslation/{uz_id}")]
    public IActionResult GetByIdBlogTranslationSite(int uz_id, string language_code)
    {

        BlogTranslation blogtranslation1 = _repository.GetBlogTranslationByIdSite(uz_id, language_code);
        var blogtranslation = _mapper.Map<BlogTranslationReadedSiteDTO>(blogtranslation1);
        if (blogtranslation == null) { }
        return Ok(blogtranslation);
    }

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpDelete("deleteblogtranslation/{id}")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("updateblogtranslation/{id}")]
    public IActionResult UpdateBlogTranslation(BlogTranslationUpdatedDTO blogtranslation1, int id)
    {
        try
        {
            if (blogtranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<BlogTranslation>(blogtranslation1);


            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(blogtranslation1.img_up);
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

            bool updatedcheck = _repository.UpdateBlogTranslation(id, dbupdated);
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

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpPut("updateblogtranslationmoderatorcontent/{id}")]
    public IActionResult UpdateBlogTranslationModerator(BlogTranslationUpdatedModeratorDTO blogtranslation1, int id)
    {
        try
        {
            if (blogtranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<BlogTranslation>(blogtranslation1);
            dbupdated.status_translation_id = _status.GetStatusTranslationId("Active", (int)dbupdated.language_id);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(blogtranslation1.img_up);
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

            bool updatedcheck = _repository.UpdateBlogTranslation(id, dbupdated);
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
    #endregion
}
