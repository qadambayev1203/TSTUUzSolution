using AutoMapper;
using Contracts.AllRepository.DocumentTeacher110Repository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.DocumentTeacher110DTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DocumentTeacher110Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TSTUWebAPI.Controllers.DocumentTeacher110Controllers;

[Route("api/documentteacher110controller")]
[ApiController]
public class DocumentTeacher110Controller : ControllerBase
{
    private readonly IDocumentTeacher110Repository _repository;
    private readonly IDocumentTeacher110SetRepository _repositorySet;
    private readonly IMapper _mapper;
    private readonly IStatusRepositoryStatic _status;

    public DocumentTeacher110Controller(IDocumentTeacher110Repository repository, IDocumentTeacher110SetRepository repositorySet, IMapper mapper, IStatusRepositoryStatic _status1)
    {
        _repository = repository;
        _repositorySet = repositorySet;
        _mapper = mapper;
        _status = _status1;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("createdocumentteacher110")]
    public IActionResult CreateDocumentTeacher110(DocumentTeacher110CreatedDTO documentTeacher110)
    {

        if (documentTeacher110.max_score == 0)
        {
            return BadRequest("max_score cannot be 0");
        }

        var documentTeacher110Map = _mapper.Map<DocumentTeacher110>(documentTeacher110);
        documentTeacher110Map.status_id = _status.GetStatusId("Active");
        int id = _repository.CreateDocumentTeacher110(documentTeacher110Map);

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

    [Authorize(Roles = "Admin,Teacher")]
    [HttpGet("getalldocumentteacher110")]
    public IActionResult GetAllDocumentTeacher110(bool parent, int? parent_id, int old_year, int new_year)
    {
        IEnumerable<DocumentTeacher110> documentTeacher110Map = _repository.AllDocumentTeacher110(parent_id, parent);
        var documentTeacher110 = _mapper.Map<IEnumerable<DocumentTeacher110ReadedDTO>>(documentTeacher110Map);

        List<DocumentTeacher110ReadedDTO> res = new List<DocumentTeacher110ReadedDTO>();

        foreach (var item in documentTeacher110)
        {
            if (item != null)
            {
                DocumentTeacher110ReadedDTO documentTeacher = item;
                if (documentTeacher.id != 0 && documentTeacher != null)
                {
                    documentTeacher.score = _repositorySet.GetTeacherDocumentScoreAllDoc(old_year, new_year, 0, documentTeacher.id, true) ?? 0;
                    res.Add(documentTeacher);
                }
            }
        }

        return Ok(documentTeacher110);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getalldocumentteacher110select")]
    public IActionResult GetAllDocumentTeacher110Select()
    {
        IEnumerable<DocumentTeacher110> documentTeacher110Map = _repository.AllDocumentTeacher110Select();
        var documentTeacher110 = _mapper.Map<IEnumerable<DocumentTeacher110SelectDTO>>(documentTeacher110Map);
        return Ok(documentTeacher110);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("getalldocumentteacher110admin")]
    public IActionResult GetAllDocumentTeacher110Admin(bool parent, int? parent_id)
    {
        IEnumerable<DocumentTeacher110> documentTeacher110Map = _repository.AllDocumentTeacher110Admin(parent_id, parent);
        var documentTeacher110 = _mapper.Map<IEnumerable<DocumentTeacher110AdminReadedDTO>>(documentTeacher110Map);

        return Ok(documentTeacher110);
    }

    [Authorize(Roles = "Admin,Teacher")]
    [HttpGet("getbyiddocumentteacher110/{id}")]
    public IActionResult GetByIdDocumentTeacher110(int id, int old_year, int new_year)
    {
        DocumentTeacher110 documentTeacher110Map = _repository.GetDocumentTeacher110ById(id);
        var documentTeacher110 = _mapper.Map<DocumentTeacher110ReadedDTO>(documentTeacher110Map);
        documentTeacher110.score = _repositorySet.GetTeacherDocumentScoreAllDoc(old_year, new_year, 0, documentTeacher110.id, true) ?? 0;

        return Ok(documentTeacher110);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("getbyiddocumentteacher110admin/{id}")]
    public IActionResult GetByIdDocumentTeacher110Admin(int id)
    {
        DocumentTeacher110 documentTeacher110Map = _repository.GetDocumentTeacher110ByIdAdmin(id);
        var documentTeacher110 = _mapper.Map<DocumentTeacher110AdminReadedDTO>(documentTeacher110Map);
        return Ok(documentTeacher110);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletedocumentteacher110/{id}")]
    public IActionResult DeleteDocumentTeacher110(int id)
    {
        bool check = _repository.DeleteDocumentTeacher110(id);
        if (!check)
        {
            return BadRequest("Not Deleted");
        }
        return Ok("Deleted");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("updatedocumentteacher110/{id}")]
    public IActionResult UpdateDocumentTeacher110(DocumentTeacher110UpdatedDTO documentTeacher110, int id)
    {
        try
        {

            if (documentTeacher110 == null)
            {
                return BadRequest();
            }

            if (documentTeacher110.parent_id == 0 || documentTeacher110.max_score == 0)
            {
                return BadRequest("parent_id and max_score cannot be 0");
            }

            var documentTeacher110Map = _mapper.Map<DocumentTeacher110>(documentTeacher110);

            bool updatedcheck = _repository.UpdateDocumentTeacher110(id, documentTeacher110Map);
            if (!updatedcheck)
            {
                return BadRequest("Not Updated");
            }

            return Ok("Updated");
        }
        catch
        {
            return BadRequest();
        }

    }




}
