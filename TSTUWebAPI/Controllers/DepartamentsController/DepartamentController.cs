using AutoMapper;
using Contracts.AllRepository.DepartamentsRepository;
using Entities.DTO.DepartamentDTOS;
using Entities.Model.DepartamentsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DepartamentsController
{
    [Route("api/departament")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartamentRepository _repository;
        private readonly IMapper _mapper;
        public DepartamentController(IDepartamentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Departament CRUD

        [HttpPost("createdepartament")]
        public IActionResult CreateDepartament(DepartamentCreatedDTO departament1)
        {
            var departament = _mapper.Map<Departament>(departament1);
            bool check = _repository.CreateDepartament(departament);

            if (!check)
            {
                return StatusCode(400);
            }

            return Ok();
        }

        [HttpGet("getalldepartament")]
        public IActionResult GetAllDepartament(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Departament> departaments1 = _repository.AllDepartament(queryNum, pageNum);
            var departaments = _mapper.Map<IEnumerable<DepartamentReadedDTO>>(departaments1);
            if (departaments == null||departaments.Count() == 0) { return NotFound(); }
            return Ok(departaments);
        }

        [HttpGet("getbyiddepartament/{id}")]
        public IActionResult GetByIdDepartament(int id)
        {

            Departament departament1 = _repository.GetDepartamentById(id);
            if (departament1 == null)
            {
                return NotFound();
            }
            var departament = _mapper.Map<DepartamentReadedDTO>(departament1);
            if (departament == null) { return NotFound(); }

            return Ok(departament);
        }


        [HttpDelete("deletedepartament/{id}")]
        public IActionResult DeleteDepartament(int id)
        {
            bool check = _repository.DeleteDepartament(id);
            if (!check)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [HttpPut("updatedepartament/{id}")]
        public IActionResult UpdateDepartament(DepartamentUpdatedDTO departament1, int id)
        {
            try
            {
                if (departament1 == null)
                {
                    return StatusCode(400);
                }
                var departament = _mapper.Map<Departament>(departament1);
                bool check = _repository.UpdateDepartament(id,departament);
                if (!check)
                {
                    return StatusCode(400);
                }
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }

        }







        //DepartamentTranslation CRUD
        [HttpPost("createdepartamenttranslation")]
        public IActionResult CreateDepartamentTranslation(DepartamentTranslationCreatedDTO departamenttranslation1)
        {
            var departamenttranslation = _mapper.Map<DepartamentTranslation>(departamenttranslation1);
            bool check = _repository.CreateDepartamentTranslation(departamenttranslation);

            if (!check)
            {
                return StatusCode(400);
            }

            return Ok();
        }

        [HttpGet("getalldepartamenttranslation")]
        public IActionResult GetAllDepartamentTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslation(queryNum, pageNum, language_code);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationReadedDTO>>(departamenttranslations1);
            if (departamenttranslations == null||departamenttranslations.Count() == 0) { return NotFound(); }
            return Ok(departamenttranslations);
        }

        [HttpGet("getbyiddepartamenttranslation/{id}")]
        public IActionResult GetByIdDepartamentTranslation(int id)
        {

            DepartamentTranslation departamenttranslation1 = _repository.GetDepartamentTranslationById(id);
            var departamenttranslation = _mapper.Map<DepartamentTranslationReadedDTO>(departamenttranslation1);
            if (departamenttranslation == null) { return NotFound(); }
            return Ok(departamenttranslation);
        }


        [HttpDelete("deletedepartamenttranslation/{id}")]
        public IActionResult DeleteDepartamentTranslation(int id)
        {
            bool check = _repository.DeleteDepartamentTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            }
            return Ok();
        }



        [HttpPut("updatedepartamenttranslation/{id}")]
        public IActionResult UpdateDepartamentTranslation(DepartamentTranslationUpdatedDTO departamenttranslation1, int id)
        {
            try
            {
                if (departamenttranslation1 == null)
                {
                    return StatusCode(400);
                }
                var departamenttranslation = _mapper.Map<DepartamentTranslation>(departamenttranslation1);
                bool check = _repository.UpdateDepartamentTranslation(id, departamenttranslation);
                if (!check)
                {
                    return StatusCode(400);
                }
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }

        }
    }
}
