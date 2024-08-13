using AutoMapper;
using Contracts.AllRepository.SitesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.SiteDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.SitesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.SitesControllers;

[Route("api/site")]
[ApiController]
public class SiteController : ControllerBase
{
    private readonly ISiteRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public SiteController(ISiteRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // Site CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createsite")]
    public IActionResult CreateSite(SiteCreatedDTO site1)
    {
        var site = _mapper.Map<Site>(site1);
        site.user_id = SessionClass.id;
        site.status_id = _status.GetStatusId("Active");
        int check = _repository.CreateSite(site);

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
    [HttpGet("getallsite")]
    public IActionResult GetAllSite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<Site> sitees1 = _repository.AllSite(queryNum, pageNum);
        var sitees = _mapper.Map<IEnumerable<SiteReadedDTO>>(sitees1);
        return Ok(sitees);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidsite/{id}")]
    public IActionResult GetByIdSite(int id)
    {

        Site site1 = _repository.GetSiteById(id);
        if (site1 == null)
        {

        }
        var site = _mapper.Map<SiteReadedDTO>(site1);
        if (site == null) { }
        return Ok(site);
    }

    [HttpGet("sitegetallsite")]
    public IActionResult GetAllSitesite(int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<Site> sitees1 = _repository.AllSiteSite(queryNum, pageNum);
        var sitees = _mapper.Map<IEnumerable<SiteReadedSiteDTO>>(sitees1);
        if (sitees == null) { }
        return Ok(sitees);
    }

    [HttpGet("sitegetbyidsite/{id}")]
    public IActionResult GetByIdSitesite(int id)
    {

        Site site1 = _repository.GetSiteByIdSite(id);
        if (site1 == null)
        {

        }
        var site = _mapper.Map<SiteReadedSiteDTO>(site1);
        if (site == null) { }
        return Ok(site);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletesite/{id}")]
    public IActionResult DeleteSite(int id)
    {
        bool check = _repository.DeleteSite(id);
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
    [HttpPut("updatesite/{id}")]
    public IActionResult UpdateSite(SiteUpdatedDTO site1, int id)
    {

        try
        {
            if (site1 == null)
            {

            }

            var dbupdated = _mapper.Map<Site>(site1);
            
            bool updatedcheck = _repository.UpdateSite(id, dbupdated);
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







    //SiteTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createsitetranslation")]
    public IActionResult CreateSiteTranslation(SiteTranslationCreatedDTO sitetranslation1)
    {
        var sitetranslation = _mapper.Map<SiteTranslation>(sitetranslation1);
        sitetranslation.user_id = SessionClass.id;
        sitetranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)sitetranslation.language_id);
        int check = _repository.CreateSiteTranslation(sitetranslation);

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
    [HttpGet("getallsitetranslation")]
    public IActionResult GetAllSiteTranslation(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<SiteTranslation> sitetranslationes1 = _repository.AllSiteTranslation(queryNum, pageNum, language_code);
        var sitetranslationes = _mapper.Map<IEnumerable<SiteTranslationReadedDTO>>(sitetranslationes1);
        if (sitetranslationes == null) { }
        return Ok(sitetranslationes);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidsitetranslation/{uz_id}")]
    public IActionResult GetByIdSiteTranslation(int uz_id, string language_code)
    {

        SiteTranslation sitetranslation1 = _repository.GetSiteTranslationById(uz_id, language_code);
        if (sitetranslation1 == null)
        {

        }
        var sitetranslation = _mapper.Map<SiteTranslationReadedDTO>(sitetranslation1);
        if (sitetranslation == null) { }
        return Ok(sitetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidsitetranslation/{id}")]
    public IActionResult GetByIdSiteTranslation(int id)
    {

        SiteTranslation sitetranslation1 = _repository.GetSiteTranslationById(id);
        if (sitetranslation1 == null)
        {

        }
        var sitetranslation = _mapper.Map<SiteTranslationReadedDTO>(sitetranslation1);
        if (sitetranslation == null) { }
        return Ok(sitetranslation);
    }

    [HttpGet("sitegetallsitetranslation")]
    public IActionResult GetAllSiteTranslationsite(int queryNum, int pageNum, string? language_code)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<SiteTranslation> sitetranslationes1 = _repository.AllSiteTranslationSite(queryNum, pageNum, language_code);
        var sitetranslationes = _mapper.Map<IEnumerable<SiteTranslationReadedSiteDTO>>(sitetranslationes1);
        if (sitetranslationes == null) { }
        return Ok(sitetranslationes);
    }

    [HttpGet("sitegetbyuzidsitetranslation/{uz_id}")]
    public IActionResult GetByIdSiteTranslationsite(int uz_id, string language_code)
    {

        SiteTranslation sitetranslation1 = _repository.GetSiteTranslationByIdSite(uz_id, language_code);
        if (sitetranslation1 == null)
        {

        }
        var sitetranslation = _mapper.Map<SiteTranslationReadedSiteDTO>(sitetranslation1);
        if (sitetranslation == null) { }
        return Ok(sitetranslation);
    }

    [HttpGet("sitegetbyidsitetranslation/{id}")]
    public IActionResult GetByIdSiteTranslationsite(int id)
    {

        SiteTranslation sitetranslation1 = _repository.GetSiteTranslationByIdSite(id);
        if (sitetranslation1 == null)
        {

        }
        var sitetranslation = _mapper.Map<SiteTranslationReadedSiteDTO>(sitetranslation1);
        if (sitetranslation == null) { }
        return Ok(sitetranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletesitetranslation/{id}")]
    public IActionResult DeleteSiteTranslation(int id)
    {
        bool check = _repository.DeleteSiteTranslation(id);
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
    [HttpPut("updatesitetranslation/{id}")]
    public IActionResult UpdateSiteTranslation(SiteTranslationUpdatedDTO sitetranslation1, int id)
    {
        try
        {
            if (sitetranslation1 == null)
            {

            }

            var dbupdated = _mapper.Map<SiteTranslation>(sitetranslation1);
           

            bool updatedcheck = _repository.UpdateSiteTranslation(id, dbupdated);
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
