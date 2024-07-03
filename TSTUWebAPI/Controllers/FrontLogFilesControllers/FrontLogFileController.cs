using Contracts.AllRepository.FrontLogFilesRepository;
using Entities.DTO.FilesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.FrontLogFilesControllers
{
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
}
