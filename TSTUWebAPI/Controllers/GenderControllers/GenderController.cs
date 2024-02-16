using AutoMapper;
using Contracts.AllRepository.GendersRepository;
using Entities.DTO.GenderDTOS;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
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

        [HttpPost("creategender")]
        public IActionResult Creategender(GenderCreatedDTO gender1)
        {
            var gender = _mapper.Map<Gender>(gender1);
            bool check = _repository.CreateGender(gender);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallgender")]
        public IActionResult GetAllgender(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Gender> genders1 = _repository.AllGender(queryNum, pageNum);
            var genders = _mapper.Map<IEnumerable<GenderReadedDTO>>(genders1);
            if (genders == null) { return NotFound(); }

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
            var gender=_mapper.Map<GenderReadedDTO>(gender1);
            if (gender == null) { return NotFound(); }
            return Ok(gender);
        }


        [HttpDelete("deletegender/{id}")]
        public IActionResult Deletegender(int id)
        {
            bool check = _repository.DeleteGender(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updategender/{id}")]
        public IActionResult Updategender(GenderUpdatedDTO gender1, int id)
        {
            try
            {
                var gender = _repository.GetGenderById(id);
                if (gender == null)
                {
                    return NotFound();
                }
                _mapper.Map(gender1, gender);
                bool check = _repository.UpdateGender();
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
        [HttpPost("creategendertranslation")]
        public IActionResult CreategenderTranslation(GenderTranslationCreatedDTO gendertranslation1)
        {
            var gendertranslation = _mapper.Map<GenderTranslation>(gendertranslation1);
            bool check = _repository.CreateGenderTranslation(gendertranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallgendertranslation")]
        public IActionResult GetAllgenderTranslation(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<GenderTranslation> gendertranslations1 = _repository.AllGenderTranslation(queryNum, pageNum);
            var gendertranslations = _mapper.Map<IEnumerable<GenderTranslationReadedDTO>>(gendertranslations1);
            if (gendertranslations == null) { return NotFound(); }

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


        [HttpDelete("deletegendertranslation/{id}")]
        public IActionResult DeletegenderTranslation(int id)
        {
            bool check = _repository.DeleteGenderTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updategendertranslation/{id}")]
        public IActionResult UpdategenderTranslation(GenderTranslationUpdatedDTO gendertranslation1, int id)
        {
            try
            {
                var gendertranslation = _repository.GetGenderTranslationById(id);
                if (gendertranslation == null)
                {
                    return NotFound();
                }
                _mapper.Map(gendertranslation1, gendertranslation);
                bool check = _repository.UpdateGenderTranslation();
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
