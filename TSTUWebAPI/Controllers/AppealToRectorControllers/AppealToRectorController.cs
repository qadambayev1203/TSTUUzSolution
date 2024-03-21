using AutoMapper;
using Contracts.AllRepository.AppealsToRectorRepository;
using Entities.DTO.AppealsToRectorDTOS;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Mvc;
using Entities.Model.AppealsToTheRectorsModel;
using Microsoft.AspNetCore.Authorization;

namespace TSTUWebAPI.Controllers.AppealToRectorControllers
{
    [Route("api/appealtorector")]
    [ApiController]
    public class AppealToRectorController : ControllerBase
    {
        private readonly IAppealToRectorRepository _repository;
        private readonly IMapper _mapper;
        public AppealToRectorController(IAppealToRectorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // AppealToRector CRUD

        [HttpPost("createappealtorector")]
        public IActionResult CreateAppealToRector(AppealToRectorCreatedDTO AppealToRector1)
        {
            if (AppealToRector1 == null)
            {
                return BadRequest();
            }
            var AppealToRector = _mapper.Map<AppealToRector>(AppealToRector1);
            int id = _repository.CreateAppealToRector(AppealToRector);

            if (id == 0)
            {
                return BadRequest();
            }

            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = id,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallappealtorector")]
        public IActionResult GetAllAppealToRector(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<AppealToRector> AppealToRectors1 = _repository.AllAppealToRector(queryNum, pageNum);
            var AppealToRectors = _mapper.Map<IEnumerable<AppealToRectorReadedDTO>>(AppealToRectors1);
            if (AppealToRectors == null || AppealToRectors.Count() == 0) { return NotFound(); }

            return Ok(AppealToRectors);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidappealtorector/{id}")]
        public IActionResult GetByIdAppealToRector(int id)
        {

            AppealToRector AppealToRector1 = _repository.GetAppealToRectorById(id);
            if (AppealToRector1 == null)
            {
                return NotFound();
            }
            var AppealToRector = _mapper.Map<AppealToRectorReadedDTO>(AppealToRector1);
            if (AppealToRector == null) { return NotFound(); }
            return Ok(AppealToRector);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteappealtorector/{id}")]
        public IActionResult DeleteAppealToRector(int id)
        {
            bool check = _repository.DeleteAppealToRector(id);
            if (!check)
            {
                return BadRequest();
            }
            bool check2 = _repository.SaveChanges();
            if (!check2)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [Authorize(Roles = "Admin")]
        [HttpPut("updateappealtorector/{id}")]
        public IActionResult UpdateAppealToRector(int status_id, int id)
        {
            try
            {
                var AppealToRectorcheck = _repository.GetAppealToRectorById(id);
                AppealToRectorUpdatedDTO AppealToRector1 = new AppealToRectorUpdatedDTO()
                {
                    status_id = status_id
                };
                if (AppealToRectorcheck == null || AppealToRector1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(AppealToRector1, AppealToRectorcheck);
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

        [HttpGet("getallappealtorectoremailstatus/{email}")]
        public IActionResult GetAllAppealToRectorEmailStatus(string email)
        {
            IEnumerable<AppealToRector> AppealToRectors1 = _repository.GetByAppealStatus(email);
            var AppealToRectors = _mapper.Map<IEnumerable<AppealEmailCheckStatusDTO>>(AppealToRectors1);
            if (AppealToRectors == null || AppealToRectors.Count() == 0) { return NotFound(); }

            return Ok(AppealToRectors);
        }





        //AppealToRectorTranslation CRUD
        [HttpPost("createappealtorectortranslation")]
        public IActionResult CreateAppealToRectorTranslation(AppealToRectorTranslationCreatedDTO AppealToRectortranslation1)
        {
            if (AppealToRectortranslation1 == null)
            {
                return BadRequest();
            }
            var AppealToRectortranslation = _mapper.Map<AppealToRectorTranslation>(AppealToRectortranslation1);
            int id = _repository.CreateAppealToRectorTranslation(AppealToRectortranslation);
            if (id == 0)
            {
                return BadRequest();
            }

            if (id == 0)
            {
                return BadRequest();
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = id,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallappealtorectortranslation")]
        public IActionResult GetAllAppealToRectorTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<AppealToRectorTranslation> AppealToRectortranslations1 = _repository.AllAppealToRectorTranslation(queryNum, pageNum, language_code);
            var AppealToRectortranslations = _mapper.Map<IEnumerable<AppealToRectorTranslationReadedDTO>>(AppealToRectortranslations1);
            if (AppealToRectortranslations == null || AppealToRectortranslations.Count() == 0) { return NotFound(); }

            return Ok(AppealToRectortranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidappealtorectortranslation/{id}")]
        public IActionResult GetByIdAppealToRectorTranslation(int id)
        {

            AppealToRectorTranslation AppealToRectortranslation1 = _repository.GetAppealToRectorTranslationById(id);
            var AppealToRectortranslation = _mapper.Map<AppealToRectorTranslationReadedDTO>(AppealToRectortranslation1);
            if (AppealToRectortranslation == null) { return NotFound(); }

            return Ok(AppealToRectortranslation);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteappealtorectortranslation/{id}")]
        public IActionResult DeleteAppealToRectorTranslation(int id)
        {
            bool check = _repository.DeleteAppealToRectorTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            bool check2 = _repository.SaveChanges();
            if (!check2)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [Authorize(Roles = "Admin")]
        [HttpPut("updateappealtorectortranslation/{id}")]
        public IActionResult UpdateAppealToRectorTranslation(int status_translation_id, int id)
        {
            try
            {
                var AppealToRectortranslationch = _repository.GetAppealToRectorTranslationById(id);
                AppealToRectorTranslationUpdatedDTO AppealToRectortranslation1 = new AppealToRectorTranslationUpdatedDTO()
                {
                    status_translation_id = status_translation_id,
                };
                if (AppealToRectortranslationch == null || AppealToRectortranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(AppealToRectortranslation1, AppealToRectortranslationch);
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


        [HttpGet("getallappealtorectortranslationemailstatus/{email}")]
        public IActionResult GetAllAppealToRectorTranslationEmailStatus(string email, string language_code)
        {
            IEnumerable<AppealToRectorTranslation> AppealToRectors1 = _repository.GetByAppealStatusTranslation(email, language_code);
            var AppealToRectorsTranslation = _mapper.Map<IEnumerable<AppealTranslationEmailCheckStatusDTO>>(AppealToRectors1);
            if (AppealToRectorsTranslation == null || AppealToRectorsTranslation.Count() == 0) { return NotFound(); }

            return Ok(AppealToRectorsTranslation);
        }
    }
}
