using AutoMapper;
using Contracts.AllRepository.NeighborhoodsRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.NeighborhoodsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.NeighborhoodsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.NeighborhoodControllers;

[Route("api/neighborhood")]
[ApiController]
public class NeighborhoodController : ControllerBase
{
    private readonly INeighborhoodRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public NeighborhoodController(INeighborhoodRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _mapper = mapper;
        _status = _status1;
    }


    // Neighborhood CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createneighborhood")]
    public IActionResult CreateNeighborhood(NeighborhoodCreatedDTO Neighborhood1)
    {
        var Neighborhood = _mapper.Map<Neighborhood>(Neighborhood1);
        Neighborhood.status_id = _status.GetStatusId("Active");
        int id = _repository.CreateNeighborhood(Neighborhood);

        if (id == 0)
        {
            return BadRequest();
        }

        CreatedItemId createdItemId = new CreatedItemId()
        {
            id = id,
            StatusCode = 200
        };

        return Ok(createdItemId);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallneighborhood")]
    public IActionResult GetAllNeighborhood(int? district_id, int queryNum, int pageNum)
    {
        queryNum = Math.Abs(queryNum);
        pageNum = Math.Abs(pageNum);
        IEnumerable<Neighborhood> Neighborhoods1;
        if (district_id == null || district_id == 0)
        {

            Neighborhoods1 = _repository.AllNeighborhood(queryNum, pageNum);
        }
        else
        {
            Neighborhoods1 = _repository.AllNeighborhood(district_id);
        }
        var Neighborhoods = _mapper.Map<IEnumerable<NeighborhoodReadedDTO>>(Neighborhoods1);
        if (Neighborhoods == null) { }

        return Ok(Neighborhoods);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidneighborhood/{id}")]
    public IActionResult GetByIdNeighborhood(int id)
    {

        Neighborhood Neighborhood1 = _repository.GetNeighborhoodById(id);
        if (Neighborhood1 == null)
        {

        }
        var Neighborhood = _mapper.Map<NeighborhoodReadedIdDTO>(Neighborhood1);
        if (Neighborhood == null) { }
        return Ok(Neighborhood);
    }

    [HttpGet("sitegetallneighborhood")]
    public IActionResult GetAllNeighborhoodsite(int district_id)
    {
        IEnumerable<Neighborhood> Neighborhoods1 = _repository.AllNeighborhoodSite(district_id);
        var Neighborhoods = _mapper.Map<IEnumerable<NeighborhoodReadedSiteDTO>>(Neighborhoods1);
        if (Neighborhoods == null) { }

        return Ok(Neighborhoods);
    }

    [HttpGet("sitegetbyidneighborhood/{id}")]
    public IActionResult GetByIdNeighborhoodsite(int id)
    {

        Neighborhood Neighborhood1 = _repository.GetNeighborhoodByIdSite(id);
        if (Neighborhood1 == null)
        {

        }
        var Neighborhood = _mapper.Map<NeighborhoodReadedSiteDTO>(Neighborhood1);
        if (Neighborhood == null) { }
        return Ok(Neighborhood);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteNeighborhood/{id}")]
    public IActionResult DeleteNeighborhood(int id)
    {
        bool check = _repository.DeleteNeighborhood(id);
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
    [HttpPut("updateneighborhood/{id}")]
    public IActionResult UpdateNeighborhood(NeighborhoodUpdatedDTO Neighborhood1, int id)
    {
        try
        {
            if (Neighborhood1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<Neighborhood>(Neighborhood1);

            bool updatedcheck = _repository.UpdateNeighborhood(id, dbupdated);
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







    //NeighborhoodTranslation CRUD

    [Authorize(Roles = "Admin")]
    [HttpPost("createneighborhoodtranslation")]
    public IActionResult CreateNeighborhoodTranslation(NeighborhoodTranslationCreatedDTO Neighborhoodtranslation1)
    {
        var Neighborhoodtranslation = _mapper.Map<NeighborhoodTranslation>(Neighborhoodtranslation1);
        Neighborhoodtranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)Neighborhoodtranslation.language_id);
        int id = _repository.CreateNeighborhoodTranslation(Neighborhoodtranslation);
        if (id == 0)
        {
            return BadRequest();
        }

        if (id == 0)
        {
            return BadRequest();
        }
        CreatedItemId createdItemId = new CreatedItemId()
        {
            id = id,
            StatusCode = 200
        };

        return Ok(createdItemId);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getallneighborhoodtranslation")]
    public IActionResult GetAllNeighborhoodTranslation(int? district_translation_id, int queryNum, int pageNum, string? language_code)
    {
        IEnumerable<NeighborhoodTranslation> Neighborhoodtranslations1;
        if (district_translation_id == null || district_translation_id == 0)
        {
            Neighborhoodtranslations1 = _repository.AllNeighborhoodTranslation(queryNum, pageNum, language_code);

        }
        else
        {
            Neighborhoodtranslations1 = _repository.AllNeighborhoodTranslation(district_translation_id, language_code);
        }
        var Neighborhoodtranslations = _mapper.Map<IEnumerable<NeighborhoodTranslationReadedDTO>>(Neighborhoodtranslations1);
        if (Neighborhoodtranslations == null) { }

        return Ok(Neighborhoodtranslations);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyuzidneighborhoodtranslation/{uz_id}")]
    public IActionResult GetByIdNeighborhoodTranslation(int uz_id, string language_code)
    {

        NeighborhoodTranslation Neighborhoodtranslation1 = _repository.GetNeighborhoodTranslationById(uz_id, language_code);
        var Neighborhoodtranslation = _mapper.Map<NeighborhoodTranslationReadedIdDTO>(Neighborhoodtranslation1);
        if (Neighborhoodtranslation == null) { }

        return Ok(Neighborhoodtranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyidneighborhoodtranslation/{id}")]
    public IActionResult GetByIdNeighborhoodTranslation(int id)
    {

        NeighborhoodTranslation Neighborhoodtranslation1 = _repository.GetNeighborhoodTranslationById(id);
        var Neighborhoodtranslation = _mapper.Map<NeighborhoodTranslationReadedIdDTO>(Neighborhoodtranslation1);
        if (Neighborhoodtranslation == null) { }

        return Ok(Neighborhoodtranslation);
    }

    [HttpGet("sitegetallneighborhoodtranslation")]
    public IActionResult GetAllNeighborhoodTranslationsite(int country_translation_id, string? language_code)
    {
        IEnumerable<NeighborhoodTranslation> Neighborhoodtranslations1 = _repository.AllNeighborhoodTranslationSite(country_translation_id, language_code);
        var Neighborhoodtranslations = _mapper.Map<IEnumerable<NeighborhoodTranslationReadedSiteDTO>>(Neighborhoodtranslations1);
        if (Neighborhoodtranslations == null) { }

        return Ok(Neighborhoodtranslations);
    }

    [HttpGet("sitegetbyuzidneighborhoodtranslation/{uz_id}")]
    public IActionResult GetByIdNeighborhoodTranslationsite(int uz_id, string language_code)
    {

        NeighborhoodTranslation Neighborhoodtranslation1 = _repository.GetNeighborhoodTranslationByIdSite(uz_id, language_code);
        var Neighborhoodtranslation = _mapper.Map<NeighborhoodTranslationReadedSiteDTO>(Neighborhoodtranslation1);
        if (Neighborhoodtranslation == null) { }

        return Ok(Neighborhoodtranslation);
    }

    [HttpGet("sitegetbyidneighborhoodtranslation/{id}")]
    public IActionResult GetByIdNeighborhoodTranslationsite(int id)
    {

        NeighborhoodTranslation Neighborhoodtranslation1 = _repository.GetNeighborhoodTranslationByIdSite(id);
        var Neighborhoodtranslation = _mapper.Map<NeighborhoodTranslationReadedSiteDTO>(Neighborhoodtranslation1);
        if (Neighborhoodtranslation == null) { }

        return Ok(Neighborhoodtranslation);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteNeighborhoodtranslation/{id}")]
    public IActionResult DeleteNeighborhoodTranslation(int id)
    {
        bool check = _repository.DeleteNeighborhoodTranslation(id);
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
    [HttpPut("updateneighborhoodtranslation/{id}")]
    public IActionResult UpdateNeighborhoodTranslation(NeighborhoodTranslationUpdatedDTO Neighborhoodtranslation1, int id)
    {
        try
        {
            if (Neighborhoodtranslation1 == null)
            {
                return BadRequest();
            }

            var dbupdated = _mapper.Map<NeighborhoodTranslation>(Neighborhoodtranslation1);

            bool updatedcheck = _repository.UpdateNeighborhoodTranslation(id, dbupdated);
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
