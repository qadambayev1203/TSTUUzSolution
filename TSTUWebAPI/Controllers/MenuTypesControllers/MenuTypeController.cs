using AutoMapper;
using Contracts.AllRepository.MenuTypesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.MenuTypesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.MenuTypesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.MenuTypesControllers;

[Route("api/menutype")]
[ApiController]
public class MenuTypeController : ControllerBase
{
    private readonly IMenuTypeRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public MenuTypeController(IMenuTypeRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // MenuType CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createmenutype")]
    public IActionResult CreateMenuType(MenuTypeCreatedDTO MenuType1)
    {
        var MenuType = _mapper.Map<MenuType>(MenuType1);
        MenuType.status_id = _status.GetStatusId("Active");
        int check = _repository.CreateMenuType(MenuType);

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
    [HttpGet("getallmenutype")]
    public IActionResult GetAllMenuType(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<MenuType> MenuTypees1 = _repository.AllMenuType(queryNum, pageNum);
        var MenuTypees = _mapper.Map<IEnumerable<MenuTypeReadedDTO>>(MenuTypees1);
        if (MenuTypees == null) { }
        return Ok(MenuTypees);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidmenutype/{id}")]
    public IActionResult GetByIdMenuType(int id)
    {

        MenuType MenuType1 = _repository.GetMenuTypeById(id);
        if (MenuType1 == null)
        {

        }
        var MenuType = _mapper.Map<MenuTypeReadedDTO>(MenuType1);
        if (MenuType == null) { }
        return Ok(MenuType);
    }

    [HttpGet("sitegetallmenutype")]
    public IActionResult GetAllMenuTypesite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<MenuType> MenuTypees1 = _repository.AllMenuTypeSite(queryNum, pageNum);
        var MenuTypees = _mapper.Map<IEnumerable<MenuTypeReadedSiteDTO>>(MenuTypees1);
        if (MenuTypees == null) { }
        return Ok(MenuTypees);
    }

    [HttpGet("sitegetbyidmenutype/{id}")]
    public IActionResult GetByIdMenuTypesite(int id)
    {

        MenuType MenuType1 = _repository.GetMenuTypeByIdSite(id);
        if (MenuType1 == null)
        {

        }
        var MenuType = _mapper.Map<MenuTypeReadedSiteDTO>(MenuType1);
        if (MenuType == null) { }
        return Ok(MenuType);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletemenutype/{id}")]
    public IActionResult DeleteMenuType(int id)
    {
        bool check = _repository.DeleteMenuType(id);
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
    [HttpPut("updatemenutype/{id}")]
    public IActionResult UpdateMenuType(MenuTypeUpdatedDTO MenuType1, int id)
    {

        try
        {
            if (MenuType1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<MenuType>(MenuType1);

            bool updatedcheck = _repository.UpdateMenuType(id, dbupdated);
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







    //MenuTypeTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createmenutypetranslation")]
    public IActionResult CreateMenuTypeTranslation(MenuTypeTranslationCreatedDTO MenuTypetranslation1)
    {
        var MenuTypetranslation = _mapper.Map<MenuTypeTranslation>(MenuTypetranslation1);
        MenuTypetranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)MenuTypetranslation.language_id);
        int check = _repository.CreateMenuTypeTranslation(MenuTypetranslation);

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
    [HttpGet("getallmenutypetranslation")]
    public IActionResult GetAllMenuTypeTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<MenuTypeTranslation> MenuTypetranslationes1 = _repository.AllMenuTypeTranslation(queryNum, pageNum, language_code);
        var MenuTypetranslationes = _mapper.Map<IEnumerable<MenuTypeTranslationReadedDTO>>(MenuTypetranslationes1);
        if (MenuTypetranslationes == null) { }
        return Ok(MenuTypetranslationes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidmenutypetranslation/{uz_id}")]
    public IActionResult GetByIdMenuTypeTranslation(int uz_id, string language_code)
    {

        MenuTypeTranslation MenuTypetranslation1 = _repository.GetMenuTypeTranslationById(uz_id, language_code);
        if (MenuTypetranslation1 == null)
        {

        }
        var MenuTypetranslation = _mapper.Map<MenuTypeTranslationReadedDTO>(MenuTypetranslation1);
        if (MenuTypetranslation == null) { }
        return Ok(MenuTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidmenutypetranslation/{id}")]
    public IActionResult GetByIdMenuTypeTranslation(int id)
    {

        MenuTypeTranslation MenuTypetranslation1 = _repository.GetMenuTypeTranslationById(id);
        if (MenuTypetranslation1 == null)
        {

        }
        var MenuTypetranslation = _mapper.Map<MenuTypeTranslationReadedDTO>(MenuTypetranslation1);
        if (MenuTypetranslation == null) { }
        return Ok(MenuTypetranslation);
    }

    [HttpGet("sitegetallmenutypetranslation")]
    public IActionResult GetAllMenuTypeTranslationsite(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<MenuTypeTranslation> MenuTypetranslationes1 = _repository.AllMenuTypeTranslationSite(queryNum, pageNum, language_code);
        var MenuTypetranslationes = _mapper.Map<IEnumerable<MenuTypeTranslationReadedSiteDTO>>(MenuTypetranslationes1);
        if (MenuTypetranslationes == null) { }
        return Ok(MenuTypetranslationes);
    }

    [HttpGet("sitegetbyuzidmenutypetranslation/{uz_id}")]
    public IActionResult GetByIdMenuTypeTranslationsite(int uz_id, string language_code)
    {

        MenuTypeTranslation MenuTypetranslation1 = _repository.GetMenuTypeTranslationByIdSite(uz_id, language_code);
        if (MenuTypetranslation1 == null)
        {

        }
        var MenuTypetranslation = _mapper.Map<MenuTypeTranslationReadedSiteDTO>(MenuTypetranslation1);
        if (MenuTypetranslation == null) { }
        return Ok(MenuTypetranslation);
    }

    [HttpGet("sitegetbyidmenutypetranslation/{id}")]
    public IActionResult GetByIdMenuTypeTranslationsite(int id)
    {

        MenuTypeTranslation MenuTypetranslation1 = _repository.GetMenuTypeTranslationByIdSite(id);
        if (MenuTypetranslation1 == null)
        {

        }
        var MenuTypetranslation = _mapper.Map<MenuTypeTranslationReadedSiteDTO>(MenuTypetranslation1);
        if (MenuTypetranslation == null) { }
        return Ok(MenuTypetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletemenutypetranslation/{id}")]
    public IActionResult DeleteMenuTypeTranslation(int id)
    {
        bool check = _repository.DeleteMenuTypeTranslation(id);
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
    [HttpPut("updatemenutypetranslation/{id}")]
    public IActionResult UpdateMenuTypeTranslation(MenuTypeTranslationUpdatedDTO MenuTypetranslation1, int id)
    {
        try
        {
            if (MenuTypetranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<MenuTypeTranslation>(MenuTypetranslation1);

            bool updatedcheck = _repository.UpdateMenuTypeTranslation(id, dbupdated);
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
