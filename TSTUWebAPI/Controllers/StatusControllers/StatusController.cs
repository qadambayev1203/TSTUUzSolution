using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.StatusDTOS;
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
        public IActionResult CreateStatus(StatusCreatedDTO status1)
        {
            var status = _mapper.Map<Status>(status1);
            bool check = _repository.CreateStatus(status);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallstatus")]
        public IActionResult GetAllStatus(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Status> statuses1 = _repository.AllStatus(queryNum, pageNum);
            var statuses = _mapper.Map<IEnumerable<StatusReadedDTO>>(statuses1);
            if (statuses == null||statuses.Count()==0) { return NotFound(); }
            return Ok(statuses);
        }

        [HttpGet("getbyidstatus/{id}")]
        public IActionResult GetByIdStatus(int id)
        {

            Status status1 = _repository.GetStatusById(id);
            if (status1 == null)
            {
                return NotFound();
            }
            var status = _mapper.Map<StatusReadedDTO>(status1);
            if (status == null) { return NotFound(); }
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
        public IActionResult UpdateStatus(StatusUpdatedDTO status1, int id)
        {

            try
            {
                Status status = _repository.GetStatusById(id);
                if(status == null)
                {
                    return NotFound();
                }
                _mapper.Map(status1, status);
                var a = _repository.UpdateStatus();
                if (a)
                {
                    return BadRequest(a);
                }
                return Ok("Updated");
            }
            catch 
            {
                return BadRequest();
            }

        }







        //StatusTranslation CRUD
        [HttpPost("createstatustranslation")]
        public IActionResult CreateStatusTranslation(StatusTranslationCreatedDTO statustranslation1)
        {
            var statustranslation = _mapper.Map<StatusTranslation>(statustranslation1);
            bool check = _repository.CreateStatusTranslation(statustranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallstatustranslation")]
        public IActionResult GetAllStatusTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<StatusTranslation> statustranslationes1 = _repository.AllStatusTranslation(queryNum, pageNum, language_code);
            var statustranslationes = _mapper.Map<IEnumerable<StatusTranslationReadedDTO>>(statustranslationes1);
            if (statustranslationes == null||statustranslationes.Count() == 0) { return NotFound(); }
            return Ok(statustranslationes);
        }

        [HttpGet("getbyidstatustranslation/{id}")]
        public IActionResult GetByIdStatusTranslation(int id)
        {

            StatusTranslation statustranslation1 = _repository.GetStatusTranslationById(id);
            if (statustranslation1 == null)
            {
                return NotFound();
            }
            var statustranslation = _mapper.Map<StatusTranslationReadedDTO>(statustranslation1);
            if (statustranslation == null) { return NotFound(); }
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
        public IActionResult UpdateStatusTranslation(StatusTranslationUpdatedDTO statustranslation1, int id)
        {
            try
            {
                var status = _repository.GetStatusTranslationById(id);
                if (status == null)
                {
                    return NotFound();
                }
                _mapper.Map(statustranslation1, status);
                bool check = _repository.UpdateStatusTranslation();
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
}
