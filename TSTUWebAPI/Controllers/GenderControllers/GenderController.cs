using AutoMapper;
using Contracts.AllRepository.GendersRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.GenderDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
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
        private readonly IStatusRepositoryStatic _status;

        public GenderController(IGenderRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // gender CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("creategender")]
        public IActionResult Creategender(GenderCreatedDTO gender1)
        {
            var gender = _mapper.Map<Gender>(gender1);
            gender.status_id = _status.GetStatusId("Active");
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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallgender")]
        public IActionResult GetAllgender(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Gender> genders1 = _repository.AllGender(queryNum, pageNum);
            var genders = _mapper.Map<IEnumerable<GenderReadedDTO>>(genders1);
            if (genders == null) { }

            return Ok(genders);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidgender/{id}")]
        public IActionResult GetByIdgender(int id)
        {

            Gender gender1 = _repository.GetGenderById(id);
            if (gender1 == null)
            {

            }
            var gender = _mapper.Map<GenderReadedDTO>(gender1);
            if (gender == null) { }
            return Ok(gender);
        }

        [HttpGet("sitegetallgender")]
        public IActionResult GetAllgendersite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Gender> genders1 = _repository.AllGenderSite(queryNum, pageNum);
            var genders = _mapper.Map<IEnumerable<GenderReadedSiteDTO>>(genders1);
            if (genders == null) { }

            return Ok(genders);
        }

        [HttpGet("sitegetbyidgender/{id}")]
        public IActionResult GetByIdgendersite(int id)
        {

            Gender gender1 = _repository.GetGenderByIdSite(id);
            if (gender1 == null)
            {

            }
            var gender = _mapper.Map<GenderReadedSiteDTO>(gender1);
            if (gender == null) { }
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
                if (gender1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<Gender>(gender1);

                bool updatedcheck = _repository.UpdateGender(id, dbupdated);
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







        //genderTranslation CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("creategendertranslation")]
        public IActionResult CreategenderTranslation(GenderTranslationCreatedDTO gendertranslation1)
        {
            var gendertranslation = _mapper.Map<GenderTranslation>(gendertranslation1);
            gendertranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)gendertranslation.language_id);
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

        [Authorize(Roles = "Admin")]
        [HttpGet("getallgendertranslation")]
        public IActionResult GetAllgenderTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<GenderTranslation> gendertranslations1 = _repository.AllGenderTranslation(queryNum, pageNum, language_code);
            var gendertranslations = _mapper.Map<IEnumerable<GenderTranslationReadedDTO>>(gendertranslations1);
            if (gendertranslations == null) { }

            return Ok(gendertranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidgendertranslation/{uz_id}")]
        public IActionResult GetByIdgenderTranslation(int uz_id, string language_code)
        {

            GenderTranslation gendertranslation1 = _repository.GetGenderTranslationById(uz_id, language_code);
            var gendertranslation = _mapper.Map<GenderTranslationReadedDTO>(gendertranslation1);
            if (gendertranslation == null) { }

            return Ok(gendertranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidgendertranslation/{id}")]
        public IActionResult GetByIdgenderTranslation(int id)
        {

            GenderTranslation gendertranslation1 = _repository.GetGenderTranslationById(id);
            var gendertranslation = _mapper.Map<GenderTranslationReadedDTO>(gendertranslation1);
            if (gendertranslation == null) { }

            return Ok(gendertranslation);
        }

        [HttpGet("sitegetallgendertranslation")]
        public IActionResult GetAllgenderTranslationsite(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<GenderTranslation> gendertranslations1 = _repository.AllGenderTranslationSite(queryNum, pageNum, language_code);
            var gendertranslations = _mapper.Map<IEnumerable<GenderTranslationReadedSiteDTO>>(gendertranslations1);
            if (gendertranslations == null) { }

            return Ok(gendertranslations);
        }

        [HttpGet("sitegetbyidgendertranslation/{id}")]
        public IActionResult GetByIdgenderTranslationsite(int id)
        {

            GenderTranslation gendertranslation1 = _repository.GetGenderTranslationByIdSite(id);
            var gendertranslation = _mapper.Map<GenderTranslationReadedSiteDTO>(gendertranslation1);
            if (gendertranslation == null) { }

            return Ok(gendertranslation);
        }

        [HttpGet("sitegetbyuzidgendertranslation/{uz_id}")]
        public IActionResult GetByIdgenderTranslationsite(int uz_id, string language_code)
        {

            GenderTranslation gendertranslation1 = _repository.GetGenderTranslationByIdSite(uz_id, language_code);
            var gendertranslation = _mapper.Map<GenderTranslationReadedSiteDTO>(gendertranslation1);
            if (gendertranslation == null) { }

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
                if (gendertranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<GenderTranslation>(gendertranslation1);

                bool updatedcheck = _repository.UpdateGenderTranslation(id, dbupdated);
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
