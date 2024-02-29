using AutoMapper;
using Contracts.AllRepository.DepartamentDetailsRepository;
using Entities.DTO.DepartamentDetailsDTOS;
using Entities.Model.DepartamentDetailsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DepartamentDetailDetailsController
{
    [Route("api/departamentDetaildetail")]
    [ApiController]
    public class DepartamentDetailController : ControllerBase
    {
        private readonly IDepartamentDetailRepository _repository;
        private readonly IMapper _mapper;
        public DepartamentDetailController(IDepartamentDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // DepartamentDetail CRUD

        [HttpPost("createdepartamentDetail")]
        public IActionResult CreateDepartamentDetail(DepartamentDetailCreatedDTO departamentDetail1)
        {
            if (departamentDetail1 == null)
            {
                return StatusCode(422);
            }
            var departamentDetail = _mapper.Map<DepartamentDetail>(departamentDetail1);
            bool check = _repository.CreateDepartamentDetail(departamentDetail);

            if (!check)
            {
                return StatusCode(400);
            }

            return StatusCode(200); 
        }

        [HttpGet("getalldepartamentDetail")]
        public IActionResult GetAllDepartamentDetail(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentDetail> departamentDetails1 = _repository.AllDepartamentDetail(queryNum, pageNum);
            var departamentDetails = _mapper.Map<IEnumerable<DepartamentDetailReadedDTO>>(departamentDetails1);
            if (departamentDetails == null||departamentDetails.Count() == 0)
            {
                return NotFound();
            }
            return Ok(departamentDetails);
        }

        [HttpGet("getbyiddepartamentDetail/{id}")]
        public IActionResult GetByIdDepartamentDetail(int id)
        {

            DepartamentDetail departamentDetail1 = _repository.GetDepartamentDetailById(id);
            if (departamentDetail1 == null)
            {
                return NotFound();
            }
            var departamentDetail = _mapper.Map<DepartamentDetailReadedDTO>(departamentDetail1);
            if (departamentDetail == null) { return NotFound(); }

            return Ok(departamentDetail);
        }


        [HttpDelete("deletedepartamentDetail/{id}")]
        public IActionResult DeleteDepartamentDetail(int id)
        {
            
            bool check = _repository.DeleteDepartamentDetail(id);
            if (!check)
            {
                return StatusCode(404);
            }
            return Ok("Deleted");
        }



        [HttpPut("updatedepartamentDetail/{id}")]
        public IActionResult UpdateDepartamentDetail(DepartamentDetailUpdatedDTO departamentDetail1, int id)
        {
            try
            {
                if (departamentDetail1 == null)
                {
                    return StatusCode(422);
                }
                var departamentDetail = _mapper.Map<DepartamentDetail>(departamentDetail1);
                bool check = _repository.UpdateDepartamentDetail(id, departamentDetail);
                if (!check)
                {
                    return StatusCode(400);
                }
                return Ok("Updated");
            }
            catch
            {
                return StatusCode(400);
            }

        }







        //DepartamentDetailTranslation CRUD
        [HttpPost("createdepartamentDetailtranslation")]
        public IActionResult CreateDepartamentDetailTranslation(DepartamentDetailTranslationCreatedDTO departamentDetailtranslation1)
        {
            if(departamentDetailtranslation1 == null)
            {
                return StatusCode(422);
            }
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslation>(departamentDetailtranslation1);
            bool check = _repository.CreateDepartamentDetailTranslation(departamentDetailtranslation);

            if (!check)
            {
                return StatusCode(400);
            }

            return StatusCode(200);
        }

        [HttpGet("getalldepartamentDetailtranslation")]
        public IActionResult GetAllDepartamentDetailTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<DepartamentDetailTranslation> departamentDetailtranslations1 = _repository.AllDepartamentDetailTranslation(queryNum, pageNum, language_code);
            var departamentDetailtranslations = _mapper.Map<IEnumerable<DepartamentDetailTranslationReadedDTO>>(departamentDetailtranslations1);
            if (departamentDetailtranslations == null || departamentDetailtranslations.Count() == 0)
            {
                return NotFound();
            }
            return Ok(departamentDetailtranslations);
        }

        [HttpGet("getbyiddepartamentDetailtranslation/{id}")]
        public IActionResult GetByIdDepartamentDetailTranslation(int id)
        {

            DepartamentDetailTranslation departamentDetailtranslation1 = _repository.GetDepartamentDetailTranslationById(id);
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslationReadedDTO>(departamentDetailtranslation1);
            if (departamentDetailtranslation == null) { return NotFound(); }
            return Ok(departamentDetailtranslation);
        }


        [HttpDelete("deletedepartamentDetailtranslation/{id}")]
        public IActionResult DeleteDepartamentDetailTranslation(int id)
        {
            bool check = _repository.DeleteDepartamentDetailTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            }
            return StatusCode(200);
        }



        [HttpPut("updatedepartamentDetailtranslation/{id}")]
        public IActionResult UpdateDepartamentDetailTranslation(DepartamentDetailTranslationUpdatedDTO departamentDetailtranslation1, int id)
        {
            try
            {
                if (departamentDetailtranslation1 == null)
                {
                    return StatusCode(422);
                }
                var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslation>(departamentDetailtranslation1);
                bool check = _repository.UpdateDepartamentDetailTranslation(id, departamentDetailtranslation);
                if (!check)
                {
                    return StatusCode(400);
                }
                return Ok("Updated");
            }
            catch
            {
                return StatusCode(400);
            }

        }
    }
}
