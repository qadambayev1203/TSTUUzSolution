using AutoMapper;
using Contracts.AllRepository.DepartamentDetailsRepository;
using Entities.DTO.DepartamentDetailsDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DepartamentDetailsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DepartamentDetailDetailsController
{
    [Route("api/departamentDetaildetail")]
    [Authorize]
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

        [Authorize(Roles="Admin")]       [HttpPost("createdepartamentDetail")]
        public IActionResult CreateDepartamentDetail(DepartamentDetailCreatedDTO departamentDetail1)
        {
            if (departamentDetail1 == null)
            {
                return StatusCode(422);
            }
            var departamentDetail = _mapper.Map<DepartamentDetail>(departamentDetail1);
            departamentDetail.status_id = 1;
            int check = _repository.CreateDepartamentDetail(departamentDetail);

            if (check==0)
            {
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getalldepartamentDetail")]
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

        [Authorize(Roles="Admin")]       [HttpGet("getbyiddepartamentDetail/{id}")]
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


        [Authorize(Roles="Admin")]       [HttpDelete("deletedepartamentDetail/{id}")]
        public IActionResult DeleteDepartamentDetail(int id)
        {
            
            bool check = _repository.DeleteDepartamentDetail(id);
            if (!check)
            {
                return StatusCode(404);
            }bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(404);
            }
            return Ok("Deleted");
        }



        [Authorize(Roles="Admin")]       [HttpPut("updatedepartamentDetail/{id}")]
        public IActionResult UpdateDepartamentDetail(DepartamentDetailUpdatedDTO departamentDetail1, int id)
        {
            try
            {
                var departamentDetail = GetByIdDepartamentDetail(id);
                if (departamentDetail1 == null|| departamentDetail==null)
                {
                    return StatusCode(422);
                }
                _mapper.Map(departamentDetail1, departamentDetail);
                bool check = _repository.SaveChanges();
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
        [Authorize(Roles="Admin")]       [HttpPost("createdepartamentDetailtranslation")]
        public IActionResult CreateDepartamentDetailTranslation(DepartamentDetailTranslationCreatedDTO departamentDetailtranslation1)
        {
            if(departamentDetailtranslation1 == null)
            {
                return StatusCode(422);
            }
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslation>(departamentDetailtranslation1);
            departamentDetailtranslation.status_translation_id = 1;
            int check = _repository.CreateDepartamentDetailTranslation(departamentDetailtranslation);

            if (check == 0)
            {
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles="Admin")]       [HttpGet("getalldepartamentDetailtranslation")]
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

        [Authorize(Roles="Admin")]       [HttpGet("getbyiddepartamentDetailtranslation/{id}")]
        public IActionResult GetByIdDepartamentDetailTranslation(int id)
        {

            DepartamentDetailTranslation departamentDetailtranslation1 = _repository.GetDepartamentDetailTranslationById(id);
            var departamentDetailtranslation = _mapper.Map<DepartamentDetailTranslationReadedDTO>(departamentDetailtranslation1);
            if (departamentDetailtranslation == null) { return NotFound(); }
            return Ok(departamentDetailtranslation);
        }


        [Authorize(Roles="Admin")]       [HttpDelete("deletedepartamentDetailtranslation/{id}")]
        public IActionResult DeleteDepartamentDetailTranslation(int id)
        {
            bool check = _repository.DeleteDepartamentDetailTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            } bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(400);
            }
            return StatusCode(200);
        }



        [Authorize(Roles="Admin")]       [HttpPut("updatedepartamentDetailtranslation/{id}")]
        public IActionResult UpdateDepartamentDetailTranslation(DepartamentDetailTranslationUpdatedDTO departamentDetailtranslation1, int id)
        {
            try
            {
                var departamentDetailtranslation = GetByIdDepartamentDetailTranslation(id);
                if (departamentDetailtranslation1 == null || departamentDetailtranslation == null)
                {
                    return StatusCode(422);
                }
                _mapper.Map(departamentDetailtranslation1, departamentDetailtranslation);
                bool check = _repository.SaveChanges();
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
