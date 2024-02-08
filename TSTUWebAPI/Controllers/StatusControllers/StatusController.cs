using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Entities.Model;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.StatusControllers
{
    [Route("api/status")]
    [ApiController]
    //[Authorize]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _repository;
        private readonly IMapper _mapper;
        public StatusController(IStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Status CRUD

        [HttpPost("createstatus")]
        public IActionResult CreateStatus(Status status)
        {

            bool check=_repository.CreateStatus(status);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", status);
        }

        [HttpGet("getallstatus")]
        public IActionResult GetAllStatus()
        {

            IEnumerable<Status> statuses = _repository.AllStatus();

            return Ok(statuses);
        }

        [HttpGet("getbyidstatus/{id}")]
        public IActionResult GetByIdStatus(int id)
        {

            Status status = _repository.GetStatusById(id);

            return Ok(status);
        }


        [HttpDelete("deletestatus/{id}")]
        public IActionResult DeleteStatus(int id)
        {
            bool check = _repository.DeleteStatus(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatestatus/{id}")]
        public IActionResult UpdateStatus(Status status, int id)
        {
            bool check = _repository.UpdateStatus(id,status);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }







        //StatusTranslation CRUD
        [HttpPost("createstatustranslation")]
        public IActionResult CreateStatusTranslation(StatusTranslation statustranslation)
        {

            bool check = _repository.CreateStatusTranslation(statustranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", statustranslation);
        }

        [HttpGet("getallstatustranslation")]
        public IActionResult GetAllStatusTranslation()
        {

            IEnumerable<StatusTranslation> statustranslationes = _repository.AllStatusTranslation();

            return Ok(statustranslationes);
        }

        [HttpGet("getbyidstatustranslation/{id}")]
        public IActionResult GetByIdStatusTranslation(int id)
        {

            StatusTranslation statustranslation = _repository.GetStatusTranslationById(id);

            return Ok(statustranslation);
        }


        [HttpDelete("deletestatustranslation/{id}")]
        public IActionResult DeleteStatusTranslation(int id)
        {
            bool check = _repository.DeleteStatusTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatestatustranslation/{id}")]
        public IActionResult UpdateStatusTranslation(StatusTranslation statustranslation, int id)
        {
            bool check = _repository.UpdateStatusTranslation(id, statustranslation);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }

    }
}
