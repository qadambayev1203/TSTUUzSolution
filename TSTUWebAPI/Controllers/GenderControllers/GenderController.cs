using AutoMapper;
using Contracts.AllRepository.GendersRepository;
using Entities.DTO.GenderDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace TSTUWebAPI.Controllers.GenderControllers
{
    [Route("api/gender")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository _repository;
        private readonly IMapper _mapper;
        public GenderController(IGenderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // gender CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("creategender")]
        public IActionResult Creategender(GenderCreatedDTO gender1)
        {
            var gender = _mapper.Map<Gender>(gender1);
            int check = _repository.CreateGender(gender);

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
        [HttpGet("getallgender")]
        public IActionResult GetAllgender(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Gender> genders1 = _repository.AllGender(queryNum, pageNum);
            var genders = _mapper.Map<IEnumerable<GenderReadedDTO>>(genders1);
            if (genders == null || genders.Count() == 0) { return NotFound(); }

            return Ok(genders);
        }
        [HttpGet("getbyidgender/{id}")]
        public IActionResult GetByIdgender(int id)
        {

            Gender gender1 = _repository.GetGenderById(id);
            if (gender1 == null)
            {
                return NotFound();
            }
            var gender = _mapper.Map<GenderReadedDTO>(gender1);
            if (gender == null) { return NotFound(); }
            return Ok(gender);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deletegender/{id}")]
        public IActionResult Deletegender(int id)
        {
            bool check = _repository.DeleteGender(id);
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



        [Authorize(Roles = "Admin")]
        [HttpPut("updategender/{id}")]
        public IActionResult Updategender(GenderUpdatedDTO gender1, int id)
        {
            try
            {
                var gender = _repository.GetGenderById(id);
                if (gender == null || gender1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(gender1, gender);
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







        //genderTranslation CRUD
        [Authorize(Roles = "Admin")]
        [HttpPost("creategendertranslation")]
        public IActionResult CreategenderTranslation(GenderTranslationCreatedDTO gendertranslation1)
        {
            var gendertranslation = _mapper.Map<GenderTranslation>(gendertranslation1);
            int check = _repository.CreateGenderTranslation(gendertranslation);

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
        [HttpGet("getallgendertranslation")]
        public IActionResult GetAllgenderTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<GenderTranslation> gendertranslations1 = _repository.AllGenderTranslation(queryNum, pageNum, language_code);
            var gendertranslations = _mapper.Map<IEnumerable<GenderTranslationReadedDTO>>(gendertranslations1);
            if (gendertranslations == null || gendertranslations.Count() == 0) { return NotFound(); }

            return Ok(gendertranslations);
        }
        [HttpGet("getbyidgendertranslation/{id}")]
        public IActionResult GetByIdgenderTranslation(int id)
        {

            GenderTranslation gendertranslation1 = _repository.GetGenderTranslationById(id);
            var gendertranslation = _mapper.Map<GenderTranslationReadedDTO>(gendertranslation1);
            if (gendertranslation == null) { return NotFound(); }

            return Ok(gendertranslation);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deletegendertranslation/{id}")]
        public IActionResult DeletegenderTranslation(int id)
        {
            bool check = _repository.DeleteGenderTranslation(id);
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



        [Authorize(Roles = "Admin")]
        [HttpPut("updategendertranslation/{id}")]
        public IActionResult UpdategenderTranslation(GenderTranslationUpdatedDTO gendertranslation1, int id)
        {
            try
            {
                var gendertranslation = _repository.GetGenderTranslationById(id);
                if (gendertranslation == null || gendertranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(gendertranslation1, gendertranslation);
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
