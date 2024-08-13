using AutoMapper;
using Contracts.AllRepository.BlogsCategoryRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.BlogsCategoryDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.BlogsCategoryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.BlogsCategoryControllers;

[Route("api/blogcategorycontroller")]
[ApiController]
public class BlogCategoryController : ControllerBase
{
    private readonly IBlogCategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public BlogCategoryController(IBlogCategoryRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // BlogCategory CRUD

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpPost("createblogcategory")]
    public IActionResult CreateBlogCategory(BlogCategoryCreatedDTO blogCategory1)
    {
        var blogCategory = _mapper.Map<BlogCategory>(blogCategory1);
        blogCategory.status_id = _status.GetStatusId("Active");
        int check = _repository.CreateBlogCategory(blogCategory);

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

    [HttpGet("sitegetallblogcategory")]
    public IActionResult GetAllBlogCategorySite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<BlogCategory> blogCategorys1 = _repository.AllBlogCategorySite(queryNum, pageNum);
        var blogCategorys = _mapper.Map<IEnumerable<BlogCategoryReadedSiteDTO>>(blogCategorys1);
        if (blogCategorys == null) { }
        return Ok(blogCategorys);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallblogcategory")]
    public IActionResult GetAllBlogCategory(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<BlogCategory> blogCategorys1 = _repository.AllBlogCategory(queryNum, pageNum);
        var blogCategorys = _mapper.Map<IEnumerable<BlogCategoryReadedDTO>>(blogCategorys1);
        if (blogCategorys == null) { }
        return Ok(blogCategorys);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidblogcategory/{id}")]
    public IActionResult GetByIdBlogCategory(int id)
    {

        BlogCategory blogCategory1 = _repository.GetBlogCategoryById(id);
        if (blogCategory1 == null)
        {

        }
        var blogCategory = _mapper.Map<BlogCategoryReadedDTO>(blogCategory1);
        if (blogCategory == null) { }

        return Ok(blogCategory);
    }

    [HttpGet("sitegetbyidblogcategory/{id}")]
    public IActionResult GetByIdBlogCategorySite(int id)
    {

        BlogCategory blogCategory1 = _repository.GetBlogCategoryByIdSite(id);
        if (blogCategory1 == null)
        {

        }
        var blogCategory = _mapper.Map<BlogCategoryReadedSiteDTO>(blogCategory1);
        if (blogCategory == null) { }

        return Ok(blogCategory);
    }

    [HttpGet("sitegetbytitleblogcategory/{title}")]
    public IActionResult GetByTitleBlogCategorySite(string title)
    {
        title = title.ToLower();
        var blogCategory1 = _repository.AllBlogCategorySite(0, 0).FirstOrDefault(x => x.title.ToLower() == title);

        var blogCategory = _mapper.Map<BlogCategoryReadedSiteDTO>(blogCategory1);
        if (blogCategory == null) { }

        return Ok(blogCategory);
    }

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpDelete("deleteblogcategory/{id}")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("updateblogcategory/{id}")]
    public IActionResult UpdateBlogCategory(BlogCategoryUpdatedDTO blogCategory1, int id)
    {
        try
        {
            if (blogCategory1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<BlogCategory>(blogCategory1);

            bool updatedcheck = _repository.UpdateBlogCategory(id, dbupdated);
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
    [HttpPut("updateblogcategorymoderatorcontent/{id}")]
    public IActionResult UpdateBlogCategoryModeratorContent(int id, BlogCategoryUpdatedModeratorDTO blogCategory1)
    {
        try
        {
            if (blogCategory1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<BlogCategory>(blogCategory1);
            dbupdated.status_id = _status.GetStatusId("Active");
            bool updatedcheck = _repository.UpdateBlogCategory(id, dbupdated);
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






    //BlogCategoryTranslation CRUD

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpPost("createblogcategorytranslation")]
    public IActionResult CreateBlogCategoryTranslation(BlogCategoryTranslationCreatedDTO blogCategorytranslation1)
    {
        var blogCategorytranslation = _mapper.Map<BlogCategoryTranslation>(blogCategorytranslation1);
        blogCategorytranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)blogCategorytranslation.language_id);
        int check = _repository.CreateBlogCategoryTranslation(blogCategorytranslation);

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

    [Authorize(Roles = "Admin")]
    [HttpGet("getallblogcategorytranslation")]
    public IActionResult GetAllBlogCategoryTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<BlogCategoryTranslation> blogCategorytranslations1 = _repository.AllBlogCategoryTranslation(queryNum, pageNum, language_code);
        var blogCategorytranslations = _mapper.Map<IEnumerable<BlogCategoryTranslationReadedDTO>>(blogCategorytranslations1);
        if (blogCategorytranslations == null) { }
        return Ok(blogCategorytranslations);
    }

    [HttpGet("sitegetallblogcategorytranslation")]
    public IActionResult GetAllBlogCategoryTranslationSite(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<BlogCategoryTranslation> blogCategorytranslations1 = _repository.AllBlogCategoryTranslationSite(queryNum, pageNum, language_code);
        var blogCategorytranslations = _mapper.Map<IEnumerable<BlogCategoryTranslationReadedSiteDTO>>(blogCategorytranslations1);
        return Ok(blogCategorytranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidblogcategorytranslation/{uz_id}")]
    public IActionResult GetByIdBlogCategoryTranslation(int uz_id, string language_code)
    {

        BlogCategoryTranslation blogCategorytranslation1 = _repository.GetBlogCategoryTranslationById(uz_id, language_code);
        var blogCategorytranslation = _mapper.Map<BlogCategoryTranslationReadedDTO>(blogCategorytranslation1);
        if (blogCategorytranslation == null) { }
        return Ok(blogCategorytranslation);
    }

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpGet("getbyidblogcategorytranslation/{id}")]
    public IActionResult GetByIdBlogCategoryTranslation(int id)
    {

        BlogCategoryTranslation blogCategorytranslation1 = _repository.GetBlogCategoryTranslationById(id);
        var blogCategorytranslation = _mapper.Map<BlogCategoryTranslationReadedDTO>(blogCategorytranslation1);
        if (blogCategorytranslation == null) { }
        return Ok(blogCategorytranslation);
    }

    [HttpGet("sitegetbyuzidblogcategorytranslation/{uz_id}")]
    public IActionResult GetByIdBlogCategoryTranslationSite(int uz_id, string language_code)
    {

        BlogCategoryTranslation blogCategorytranslation1 = _repository.GetBlogCategoryTranslationByIdSite(uz_id, language_code);
        var blogCategorytranslation = _mapper.Map<BlogCategoryTranslationReadedSiteDTO>(blogCategorytranslation1);
        if (blogCategorytranslation == null) { }
        return Ok(blogCategorytranslation);
    }

    [HttpGet("sitegetbyidblogcategorytranslation/{id}")]
    public IActionResult GetByIdBlogCategoryTranslationSite(int id)
    {

        BlogCategoryTranslation blogCategorytranslation1 = _repository.GetBlogCategoryTranslationByIdSite(id);
        var blogCategorytranslation = _mapper.Map<BlogCategoryTranslationReadedSiteDTO>(blogCategorytranslation1);
        if (blogCategorytranslation == null) { }
        return Ok(blogCategorytranslation);
    }

    [Authorize(Roles = "Admin,ModeratorContent")]
    [HttpDelete("deleteblogcategorytranslation/{id}")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("updateblogcategorytranslation/{id}")]
    public IActionResult UpdateBlogCategoryTranslation(BlogCategoryTranslationUpdatedDTO blogCategorytranslation1, int id)
    {
        try
        {
            if (blogCategorytranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<BlogCategoryTranslation>(blogCategorytranslation1);

            bool updatedcheck = _repository.UpdateBlogCategoryTranslation(id, dbupdated);
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
    [HttpPut("updateblogcategorytranslationmoderatorcontent/{id}")]
    public IActionResult UpdateBlogCategoryTranslationModContent(BlogCategoryTranslationUpdatedModeratorDTO blogCategorytranslation1, int id)
    {
        try
        {
            if (blogCategorytranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<BlogCategoryTranslation>(blogCategorytranslation1);
            dbupdated.status_translation_id = _status.GetStatusTranslationId("Active", (int)dbupdated.language_id);
            bool updatedcheck = _repository.UpdateBlogCategoryTranslation(id, dbupdated);
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
