using AutoMapper;
using Contracts.AllRepository.MenuesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.MenuDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Entities.Model.MenuModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.MenuControllers;

[Route("api/menu")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMenuRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public MenuController(IMenuRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // Menu CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createmenu")]
    public IActionResult CreateMenu(MenuCreatedDTO Menu1)
    {
        var Menu = _mapper.Map<Menu>(Menu1);
        Menu.status_id = _status.GetStatusId("Active");
        Menu.user_id = SessionClass.id;

        FileUploadRepository fileUpload = new FileUploadRepository();

        var Url = fileUpload.SaveFileAsync(Menu1.icon_upload);
        if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
        {
            return BadRequest("File created error!");
        }
        if (Url != null && Url.Length > 0)
        {
            Menu.icon_ = new Files
            {
                title = Guid.NewGuid().ToString(),
                url = Url
            };
        }


        int check = _repository.CreateMenu(Menu);

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

    [HttpGet("getallmenu")]
    public IActionResult GetAllMenu(int queryNum, int pageNum, bool? top_menu)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<Menu> Menues1 = _repository.AllMenu(queryNum, pageNum, top_menu);
        var Menues = _mapper.Map<IEnumerable<MenuReadedDTO>>(Menues1);
        if (Menues == null) { }
        return Ok(Menues);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidmenu/{id}")]
    public IActionResult GetByIdMenu(int id)
    {

        Menu Menu1 = _repository.GetMenuById(id);
        if (Menu1 == null)
        {

        }
        var Menu = _mapper.Map<MenuReadedDTO>(Menu1);
        if (Menu == null) { }
        return Ok(Menu);
    }

    [HttpGet("sitegetallmenu")]
    public IActionResult GetAllMenusite(int queryNum, int pageNum, bool? top_menu)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<Menu> Menues1 = _repository.AllMenuSite(queryNum, pageNum, top_menu);
        var Menues = _mapper.Map<IEnumerable<MenuReadedSiteDTO>>(Menues1);
        if (Menues == null) { }
        return Ok(Menues);
    }

    [HttpGet("sitegetbyidmenu/{id}")]
    public IActionResult GetByIdMenusite(int id)
    {

        Menu Menu1 = _repository.GetMenuByIdSite(id);
        if (Menu1 == null)
        {

        }
        var Menu = _mapper.Map<MenuReadedSiteDTO>(Menu1);
        if (Menu == null) { }
        return Ok(Menu);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletemenu/{id}")]
    public IActionResult DeleteMenu(int id)
    {
        bool check = _repository.DeleteMenu(id);
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
    [HttpPut("updatemenu/{id}")]
    public IActionResult UpdateMenu(MenuUpdatedDTO Menu1, int id)
    {

        try
        {
            if (Menu1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<Menu>(Menu1);
            

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(Menu1.icon_upload);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                dbupdated.icon_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }


            bool updatedcheck = _repository.UpdateMenu(id, dbupdated);
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







    //MenuTranslation CRUD
    [Authorize(Roles = "Admin")]
    [HttpPost("createmenutranslation")]
    public IActionResult CreateMenuTranslation(MenuTranslationCreatedDTO Menutranslation1)
    {
        var Menutranslation = _mapper.Map<MenuTranslation>(Menutranslation1);
        Menutranslation.status_id = _status.GetStatusTranslationId("Active", (int)Menutranslation.language_id);
        Menutranslation.user_id = SessionClass.id;

        FileUploadRepository fileUpload = new FileUploadRepository();

        var Url = fileUpload.SaveFileAsync(Menutranslation1.icon_upload);
        if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
        {
            return BadRequest("File created error!");
        }
        if (Url != null && Url.Length > 0)
        {
            Menutranslation.icon_ = new FilesTranslation
            {
                title = Guid.NewGuid().ToString(),
                url = Url
            };
        }

        int check = _repository.CreateMenuTranslation(Menutranslation);

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
    [HttpGet("getallmenutranslation")]
    public IActionResult GetAllMenuTranslation(int queryNum, int pageNum, string? language_code, bool? top_menu)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<MenuTranslation> Menutranslationes1 = _repository.AllMenuTranslation(queryNum, pageNum, language_code, top_menu);
        var Menutranslationes = _mapper.Map<IEnumerable<MenuTranslationReadedDTO>>(Menutranslationes1);
        if (Menutranslationes == null) { }
        return Ok(Menutranslationes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidmenutranslation/{id}")]
    public IActionResult GetByIdMenuTranslation(int id)
    {

        MenuTranslation Menutranslation1 = _repository.GetMenuTranslationById(id);
        if (Menutranslation1 == null)
        {

        }
        var Menutranslation = _mapper.Map<MenuTranslationReadedDTO>(Menutranslation1);
        if (Menutranslation == null) { }
        return Ok(Menutranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidmenutranslation/{uz_id}")]
    public IActionResult GetByIdMenuTranslation(int uz_id, string language_code)
    {

        MenuTranslation Menutranslation1 = _repository.GetMenuTranslationById(uz_id, language_code);
        if (Menutranslation1 == null)
        {

        }
        var Menutranslation = _mapper.Map<MenuTranslationReadedDTO>(Menutranslation1);
        if (Menutranslation == null) { }
        return Ok(Menutranslation);
    }

    [HttpGet("sitegetallmenutranslation")]
    public IActionResult GetAllMenuTranslationsite(int queryNum, int pageNum, string? language_code, bool? top_menu)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<MenuTranslation> Menutranslationes1 = _repository.AllMenuTranslationSite(queryNum, pageNum, language_code, top_menu);
        var Menutranslationes = _mapper.Map<IEnumerable<MenuTranslationReadedSiteDTO>>(Menutranslationes1);
        if (Menutranslationes == null) { }
        return Ok(Menutranslationes);
    }

    [HttpGet("sitegetbyidmenutranslation/{id}")]
    public IActionResult GetByIdMenuTranslationsite(int id)
    {

        MenuTranslation Menutranslation1 = _repository.GetMenuTranslationByIdSite(id);
        if (Menutranslation1 == null)
        {

        }
        var Menutranslation = _mapper.Map<MenuTranslationReadedSiteDTO>(Menutranslation1);
        if (Menutranslation == null) { }
        return Ok(Menutranslation);
    }

    [HttpGet("sitegetbyuzidmenutranslation/{uz_id}")]
    public IActionResult GetByIdMenuTranslationsite(int uz_id, string language_code)
    {

        MenuTranslation Menutranslation1 = _repository.GetMenuTranslationByIdSite(uz_id, language_code);
       
        var Menutranslation = _mapper.Map<MenuTranslationReadedSiteDTO>(Menutranslation1);
        if (Menutranslation == null) { }
        return Ok(Menutranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletemenutranslation/{id}")]
    public IActionResult DeleteMenuTranslation(int id)
    {
        bool check = _repository.DeleteMenuTranslation(id);
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
    [HttpPut("updatemenutranslation/{id}")]
    public IActionResult UpdateMenuTranslation(MenuTranslationUpdatedDTO Menutranslation1, int id)
    {
        try
        {
            if (Menutranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<MenuTranslation>(Menutranslation1);
            

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(Menutranslation1.icon_upload);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                dbupdated.icon_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }


            bool updatedcheck = _repository.UpdateMenuTranslation(id, dbupdated);
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
