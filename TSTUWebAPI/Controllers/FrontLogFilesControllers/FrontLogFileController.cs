﻿using Contracts.AllRepository.FrontLogFilesRepository;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.FrontLogFilesControllers;

[Route("api/frontlogfilecontroller")]
[ApiController]
public class FrontLogFileController : ControllerBase
{
    private readonly IFrontLogFileRepository _repository;

    public FrontLogFileController(IFrontLogFileRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("createfrontlogs")]
    public IActionResult CreateFrontLogs(Exception ex)
    {
        var token = HttpContext.Request.Headers["Authorization"];
        if (token == SessionClass.tokenCheck || token == SessionClass.token)
        {
            if (ex != null)
            {
                bool check = _repository.LogFileCreated(ex);
                if (check) { return Ok(); }
                return BadRequest(); ;
            }
            return BadRequest();
        }
        return Unauthorized();
    }

}
