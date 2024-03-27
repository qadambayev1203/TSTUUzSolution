using AutoMapper;
using Contracts.AllRepository.DepartamentsTypeRepository;
using Entities.DTO.DepartamentTypeDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DepartamentsModel;
using Entities.Model.DepartamentsTypeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DepartamentTypesTypeController
{
    [Route("api/deartamenttypecontroller")]
    [Authorize]
    [ApiController]
    public class DepartamentTypeController : ControllerBase
    {
        private readonly IDepartamentTypeRepository _repository;
        private readonly IMapper _mapper;
        public DepartamentTypeController(IDepartamentTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // DepartamentType CRUD

        [Authorize(Roles="Admin")]       [HttpPost("createdepartamentType")]
        public IActionResult CreateDepartamentType(DepartamentTypeCreatedDTO departamentType1)
        {
            var departamentType = _mapper.Map<DepartamentType>(departamentType1);
            departamentType.status_id = 1;
            int check = _repository.CreateDepartamentType(departamentType);

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

        [Authorize(Roles="Admin")]       [HttpGet("getalldepartamentType")]
        public IActionResult GetAllDepartamentType(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentType> departamentTypes1 = _repository.AllDepartamentType(queryNum, pageNum);
            var departamentTypes = _mapper.Map<IEnumerable<DepartamentTypeReadedDTO>>(departamentTypes1);
            if (departamentTypes == null || departamentTypes.Count() == 0) { return NotFound(); }
            return Ok(departamentTypes);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyiddepartamentType/{id}")]
        public IActionResult GetByIdDepartamentType(int id)
        {

            DepartamentType departamentType1 = _repository.GetDepartamentTypeById(id);
            if (departamentType1 == null)
            {
                return NotFound();
            }
            var departamentType = _mapper.Map<DepartamentTypeReadedDTO>(departamentType1);
            if (departamentType == null) { return NotFound(); }

            return Ok(departamentType);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deletedepartamentType/{id}")]
        public IActionResult DeleteDepartamentType(int id)
        {
            bool check = _repository.DeleteDepartamentType(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updatedepartamentType/{id}")]
        public IActionResult UpdateDepartamentType(DepartamentTypeUpdatedDTO departamentType1, int id)
        {
            try
            {
                var departamentType = GetByIdDepartamentType(id);
                if (departamentType1 == null || departamentType == null)
                {
                    return BadRequest();
                }
                _mapper.Map(departamentType1, departamentType);
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







        //DepartamentTypeTranslation CRUD
        [Authorize(Roles="Admin")]       [HttpPost("createdepartamentTypetranslation")]
        public IActionResult CreateDepartamentTypeTranslation(DepartamentTypeTranslationCreatedDTO departamentTypetranslation1)
        {
            var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslation>(departamentTypetranslation1);
            departamentTypetranslation.status_translation_id = 1;
            int check = _repository.CreateDepartamentTypeTranslation(departamentTypetranslation);

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

        [Authorize(Roles="Admin")]       [HttpGet("getalldepartamentTypetranslation")]
        public IActionResult GetAllDepartamentTypeTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentTypeTranslation> departamentTypetranslations1 = _repository.AllDepartamentTypeTranslation(queryNum, pageNum, language_code);
            var departamentTypetranslations = _mapper.Map<IEnumerable<DepartamentTypeTranslationReadedDTO>>(departamentTypetranslations1);
            if (departamentTypetranslations == null || departamentTypetranslations.Count() == 0) { return NotFound(); }

            return Ok(departamentTypetranslations);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getbyiddepartamentTypetranslation/{id}")]
        public IActionResult GetByIdDepartamentTypeTranslation(int id)
        {

            DepartamentTypeTranslation departamentTypetranslation1 = _repository.GetDepartamentTypeTranslationById(id);
            var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslationReadedDTO>(departamentTypetranslation1);
            if (departamentTypetranslation == null) { return NotFound(); }
            return Ok(departamentTypetranslation);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deletedepartamentTypetranslation/{id}")]
        public IActionResult DeleteDepartamentTypeTranslation(int id)
        {
            bool check = _repository.DeleteDepartamentTypeTranslation(id);
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



        [Authorize(Roles="Admin")]       [HttpPut("updatedepartamentTypetranslation/{id}")]
        public IActionResult UpdateDepartamentTypeTranslation(DepartamentTypeTranslationUpdatedDTO departamentTypetranslation1, int id)
        {
            try
            {
                var departamentTypetranslation = GetByIdDepartamentTypeTranslation(id);
                if (departamentTypetranslation1 == null || departamentTypetranslation == null)
                {
                    return BadRequest();
                }
                _mapper.Map(departamentTypetranslation1, departamentTypetranslation);
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
