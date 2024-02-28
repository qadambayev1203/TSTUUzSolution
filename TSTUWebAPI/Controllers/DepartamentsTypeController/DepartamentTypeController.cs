using AutoMapper;
using Contracts.AllRepository.DepartamentsTypeRepository;
using Entities.DTO.DepartamentTypeDTOS;
using Entities.Model.DepartamentsModel;
using Entities.Model.DepartamentsTypeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DepartamentTypesTypeController
{
    [Route("api/deartamenttypecontroller")]
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

        [HttpPost("createdepartamentType")]
        public IActionResult CreateDepartamentType(DepartamentTypeCreatedDTO departamentType1)
        {
            var departamentType = _mapper.Map<DepartamentType>(departamentType1);
            bool check = _repository.CreateDepartamentType(departamentType);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getalldepartamentType")]
        public IActionResult GetAllDepartamentType(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentType> departamentTypes1 = _repository.AllDepartamentType(queryNum, pageNum);
            var departamentTypes = _mapper.Map<IEnumerable<DepartamentTypeReadedDTO>>(departamentTypes1);
            if (departamentTypes == null) { return NotFound(); }
            return Ok(departamentTypes);
        }

        [HttpGet("getbyiddepartamentType/{id}")]
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


        [HttpDelete("deletedepartamentType/{id}")]
        public IActionResult DeleteDepartamentType(int id)
        {
            bool check = _repository.DeleteDepartamentType(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatedepartamentType/{id}")]
        public IActionResult UpdateDepartamentType(DepartamentTypeUpdatedDTO departamentType1, int id)
        {
            try
            {
                if (departamentType1 == null)
                {
                    return BadRequest();
                }
                var departamentType = _mapper.Map<DepartamentType>(departamentType1);
                bool check = _repository.UpdateDepartamentType(id, departamentType);
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
        [HttpPost("createdepartamentTypetranslation")]
        public IActionResult CreateDepartamentTypeTranslation(DepartamentTypeTranslationCreatedDTO departamentTypetranslation1)
        {
            var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslation>(departamentTypetranslation1);
            bool check = _repository.CreateDepartamentTypeTranslation(departamentTypetranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getalldepartamentTypetranslation")]
        public IActionResult GetAllDepartamentTypeTranslation(int queryNum, int pageNum, string language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentTypeTranslation> departamentTypetranslations1 = _repository.AllDepartamentTypeTranslation(queryNum, pageNum, language_code);
            var departamentTypetranslations = _mapper.Map<IEnumerable<DepartamentTypeTranslationReadedDTO>>(departamentTypetranslations1);
            if (departamentTypetranslations == null) { return NotFound(); }

            return Ok(departamentTypetranslations);
        }

        [HttpGet("getbyiddepartamentTypetranslation/{id}")]
        public IActionResult GetByIdDepartamentTypeTranslation(int id)
        {

            DepartamentTypeTranslation departamentTypetranslation1 = _repository.GetDepartamentTypeTranslationById(id);
            var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslationReadedDTO>(departamentTypetranslation1);
            if (departamentTypetranslation== null) { return NotFound(); }
            return Ok(departamentTypetranslation);
        }


        [HttpDelete("deletedepartamentTypetranslation/{id}")]
        public IActionResult DeleteDepartamentTypeTranslation(int id)
        {
            bool check = _repository.DeleteDepartamentTypeTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatedepartamentTypetranslation/{id}")]
        public IActionResult UpdateDepartamentTypeTranslation(DepartamentTypeTranslationUpdatedDTO departamentTypetranslation1, int id)
        {
            try
            {
                if (departamentTypetranslation1 == null)
                {
                    return BadRequest();
                }
                var departamentTypetranslation = _mapper.Map<DepartamentTypeTranslation>(departamentTypetranslation1);
                bool check = _repository.UpdateDepartamentTypeTranslation(id, departamentTypetranslation);
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
