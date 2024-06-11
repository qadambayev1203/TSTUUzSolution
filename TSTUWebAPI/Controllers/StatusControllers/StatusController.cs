using AutoMapper;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.StatusDTOS;
using Entities.Model;
using Entities.Model.AnyClasses;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.StatusControllers
{
    [Route("api/status")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<StatusController> _logger;
        public StatusController(IStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Status CRUD


        [HttpPost("createstatus")]
        public IActionResult CreateStatus(StatusCreatedDTO status1)
        {
            if (status1 == null)
            {
                return BadRequest();
            }
            var status = _mapper.Map<Status>(status1);
            int check = _repository.CreateStatus(status);

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

        [HttpGet("getallstatus")]
        public IActionResult GetAllStatus(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Status> statuses1 = _repository.AllStatus(queryNum, pageNum);
            var statuses = _mapper.Map<IEnumerable<StatusReadedDTO>>(statuses1);
            return Ok(statuses);
        }

        [HttpGet("getbyidstatus/{id}")]
        public IActionResult GetByIdStatus(int id)
        {

            Status status1 = _repository.GetStatusById(id);
            if (status1 == null)
            {

            }
            var status = _mapper.Map<StatusReadedDTO>(status1);
            return Ok(status);
        }

        [HttpGet("selectgetallstatus")]
        public IActionResult GetAllStatusselect(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Status> statuses1 = _repository.AllStatusSelect(queryNum, pageNum);
            var statuses = _mapper.Map<IEnumerable<StatusReadedSiteDTO>>(statuses1);
            return Ok(statuses);
        }

        [HttpGet("selectgetbyidstatus/{id}")]
        public IActionResult GetByIdStatusselect(int id)
        {

            Status status1 = _repository.GetStatusByIdSelect(id);
            if (status1 == null)
            {

            }
            var status = _mapper.Map<StatusReadedSiteDTO>(status1);
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
            bool check1 = _repository.SaveChanges();
            if (!check1)
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
                if (status1 == null)
                {
                    return BadRequest();
                }

                var status = _mapper.Map<Status>(status1);

                bool updatedcheck = _repository.UpdateStatus(id, status);
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







        //StatusTranslation CRUD

        [HttpPost("createstatustranslation")]
        public IActionResult CreateStatusTranslation(StatusTranslationCreatedDTO statustranslation1)
        {
            var statustranslation = _mapper.Map<StatusTranslation>(statustranslation1);
            int check = _repository.CreateStatusTranslation(statustranslation);

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

        [HttpGet("getallstatustranslation")]
        public IActionResult GetAllStatusTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<StatusTranslation> statustranslationes1 = _repository.AllStatusTranslation(queryNum, pageNum, language_code);
            var statustranslationes = _mapper.Map<IEnumerable<StatusTranslationReadedDTO>>(statustranslationes1);
            return Ok(statustranslationes);
        }

        [HttpGet("getbyiduzstatustranslation/{uz_id}")]
        public IActionResult GetByIdStatusTranslation(int uz_id, string language_code)
        {

            StatusTranslation statustranslation1 = _repository.GetStatusTranslationById(uz_id, language_code);
           
            var statustranslation = _mapper.Map<StatusTranslationReadedDTO>(statustranslation1);
            return Ok(statustranslation);
        }
        
        [HttpGet("getbyiduzstatustranslationsite/{uz_id}")]
        public IActionResult GetByIdStatusTranslationSite(int uz_id, string language_code)
        {

            StatusTranslation statustranslation1 = _repository.GetStatusTranslationByIdSite(uz_id, language_code);
           
            var statustranslation = _mapper.Map<StatusTranslationReadedDTO>(statustranslation1);
            return Ok(statustranslation);
        }

        [HttpGet("getbyidstatustranslation/{id}")]
        public IActionResult GetByIdStatusTranslation(int id)
        {

            StatusTranslation statustranslation1 = _repository.GetStatusTranslationById(id);
            if (statustranslation1 == null)
            {

            }
            var statustranslation = _mapper.Map<StatusTranslationReadedDTO>(statustranslation1);
            return Ok(statustranslation);
        }

        [HttpGet("selectgetallstatustranslation")]
        public IActionResult GetAllStatusTranslationselect(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<StatusTranslation> statustranslationes1 = _repository.AllStatusTranslationSelect(queryNum, pageNum, language_code);
            var statustranslationes = _mapper.Map<IEnumerable<StatusTranslationReadedSiteDTO>>(statustranslationes1);
            return Ok(statustranslationes);
        }

        [HttpGet("selectgetbyidstatustranslation/{id}")]
        public IActionResult GetByIdStatusTranslationselect(int id)
        {

            StatusTranslation statustranslation1 = _repository.GetStatusTranslationByIdSelect(id);
            if (statustranslation1 == null)
            {

            }
            var statustranslation = _mapper.Map<StatusTranslationReadedSiteDTO>(statustranslation1);
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
            bool check1 = _repository.SaveChanges();
            if (!check1)
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
                if (statustranslation1 == null)
                {
                    return BadRequest();
                }

                var status = _mapper.Map<StatusTranslation>(statustranslation1);

                bool updatedcheck = _repository.UpdateStatusTranslation(id, status);
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
}
