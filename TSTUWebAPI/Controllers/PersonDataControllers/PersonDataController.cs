using AutoMapper;
using Entities.Model.PersonDataModel;
using Contracts.AllRepository.PersonsDataRepository;
using Entities.DTO.PersonDataDTOS;
using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;
using Contracts.AllRepository.StatusesRepository;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.FileModel;
using Entities.Model.PersonModel;
using Entities.Model;
using Entities.DTO.UserCrudDTOS;

namespace TSTUWebAPI.Controllers.PersonDataControllers
{
    [Route("api/persondata")]
    [ApiController]
    public class PersonDataController : ControllerBase
    {
        private readonly IPersonDataRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public PersonDataController(IPersonDataRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // personData CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createpersondata")]
        public IActionResult CreatepersonData(PersonDataCreatedDTO personData1)
        {
            var personData = _mapper.Map<PersonData>(personData1);
            personData.status_id = _status.GetStatusId("Active");
            personData.persons_.status_id = _status.GetStatusId("Active");

            UserCrudCreatedDTO userDTO = null;

            if (personData1.login != null || personData1.password != null)
            {
                userDTO = new UserCrudCreatedDTO
                {
                    login = personData1.login.Trim(),
                    password = PasswordManager.EncryptPassword(personData1.login.Trim() + personData1.password.Trim()),
                    user_type_id = 0,
                    person_id = 0
                };
            }

           

            User user = _mapper.Map<User>(userDTO);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(personData1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                personData.persons_.img_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }


            int check = _repository.CreatePersonData(personData, user);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
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
        [HttpGet("getallpersondata")]
        public IActionResult GetAllpersonData(int queryNum, int pageNum, string? employee_type)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PersonData> personDatas1;
            if (employee_type == null)
            {
                personDatas1 = _repository.AllPersonData(queryNum, pageNum);
                var personDatas = _mapper.Map<IEnumerable<PersonDataReadedDTO>>(personDatas1);
                return Ok(personDatas);
            }
            else
            {
                personDatas1 = _repository.AllPersonDataEmployeeType(queryNum, pageNum, employee_type);
                var personDatas = _mapper.Map<IEnumerable<PersonDataReadedEmployeeTypeDTO>>(personDatas1);
                return Ok(personDatas);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidpersondata/{id}")]
        public IActionResult GetByIdpersonData(int id)
        {

            PersonData personData1 = _repository.GetPersonDataById(id);
            User user = _repository.GetPersonUserById(personData1.persons_id);
            var personData = _mapper.Map<PersonDataReadedDTO>(personData1);
            if (user != null)
            {
                personData.login = user.login;
            }

            return Ok(personData);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbypersonidpersondata/{person_id}")]
        public IActionResult GetByPersonIdpersonData(int person_id)
        {

            PersonData personData1 = _repository.GetPersonDataByPersonId(person_id);
            var personData = _mapper.Map<PersonDataReadedDTO>(personData1);
            if (personData == null) { }
            return Ok(personData);
        }

        [HttpGet("sitegetallpersondata")]
        public IActionResult GetAllpersonDatasite(int queryNum, int pageNum, string? employee_type)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PersonData> personDatas1;
            if (employee_type == null)
            {
                personDatas1 = _repository.AllPersonDataSite(queryNum, pageNum);
                var personDatas = _mapper.Map<IEnumerable<PersonDataReadedSiteDTO>>(personDatas1);
                return Ok(personDatas);
            }
            else
            {
                personDatas1 = _repository.AllPersonDataEmployeeTypeSite(queryNum, pageNum, employee_type);
                var personDatas = _mapper.Map<IEnumerable<PersonDataReadedEmployeeTypeSiteDTO>>(personDatas1);
                return Ok(personDatas);
            }

        }

        [HttpGet("sitegetallpersondatadepid/{department_id}")]
        public IActionResult GetAllpersonDataDepId(int department_id)
        {
            IEnumerable<PersonData> personDatas1;
            personDatas1 = _repository.AllPersonDataDepId(department_id);
            var personDatas = _mapper.Map<IEnumerable<PersonDataReadedSiteDTO>>(personDatas1);
            return Ok(personDatas);

        }

        [HttpGet("sitegetbyidpersondata/{id}")]
        public IActionResult GetByIdpersonDatasite(int id)
        {

            PersonData personData1 = _repository.GetPersonDataByIdSite(id);
            var personData = _mapper.Map<PersonDataReadedSiteDTO>(personData1);
            if (personData == null) { }
            return Ok(personData);
        }


        [HttpGet("sitegetbypersonidpersondata/{person_id}")]
        public IActionResult GetByPersonIdpersonDatasite(int person_id)
        {

            PersonData personData1 = _repository.GetPersonDataByPersonIdSite(person_id);
            var personData = _mapper.Map<PersonDataReadedSiteDTO>(personData1);
            if (personData == null) { }
            return Ok(personData);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletepersondata/{id}")]
        public IActionResult DeletepersonData(int id)
        {
            bool check = _repository.DeletePersonData(id);
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
        [HttpPut("updatepersondata/{id}")]
        public IActionResult UpdatepersonData(PersonDataUpdatedDTO personData1, int id)
        {
            try
            {
                if (personData1 == null)
                {
                    return BadRequest();
                }
                var dbupdated = _mapper.Map<PersonData>(personData1);
                dbupdated.persons_.status_id = dbupdated.status_id;

                UserCrudCreatedDTO userDTO = null;

                if (personData1.password != null)
                {
                    userDTO = new UserCrudCreatedDTO
                    {
                        login = personData1.login.Trim(),
                        password = PasswordManager.EncryptPassword(personData1.login.Trim() + personData1.password.Trim()),
                        user_type_id = 0,
                        person_id = 0
                    };
                }

                User user = _mapper.Map<User>(userDTO);


                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(personData1.img_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url != null && Url.Length > 0)
                {
                    dbupdated.persons_.img_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }

                bool updatedcheck = _repository.UpdatePersonData(id, dbupdated, user);
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





        //personDataTranslation CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createpersondatatranslation")]
        public IActionResult CreatepersonDataTranslation(PersonDataTranslationCreatedDTO personDatatranslation1)
        {
            var personDatatranslation = _mapper.Map<PersonDataTranslation>(personDatatranslation1);
            personDatatranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)personDatatranslation.language_id);
            personDatatranslation.persons_translation_.status_translation_id = _status.GetStatusTranslationId("Active", (int)personDatatranslation.language_id);
            int check = _repository.CreatePersonDataTranslation(personDatatranslation);

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
        [HttpGet("getallpersondatatranslation")]
        public IActionResult GetAllpersonDataTranslation(int queryNum, int pageNum, string? language_code, string? employee_type)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PersonDataTranslation> personDatatranslationes1;
            if (employee_type == null)
            {
                personDatatranslationes1 = _repository.AllPersonDataTranslation(queryNum, pageNum, language_code);
                var personDatatranslationes = _mapper.Map<IEnumerable<PersonDataTranslationReadedDTO>>(personDatatranslationes1);
                return Ok(personDatatranslationes);
            }
            else
            {
                personDatatranslationes1 = _repository.AllPersonDataTranslationEmployeeType(queryNum, pageNum, language_code, employee_type);
                var personDatatranslationes = _mapper.Map<IEnumerable<PersonDataTranslationReadedEmployeeTypeDTO>>(personDatatranslationes1);
                return Ok(personDatatranslationes);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidpersondatatranslation/{uz_id}")]
        public IActionResult GetByIdpersonDataTranslation(int uz_id, string language_code)
        {
            PersonDataTranslation personDatatranslation1 = _repository.GetPersonDataTranslationById(uz_id, language_code);
            var personDatatranslation = _mapper.Map<PersonDataTranslationReadedDTO>(personDatatranslation1);
            if (personDatatranslation == null) { }
            return Ok(personDatatranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidpersondatatranslation/{id}")]
        public IActionResult GetByIdpersonDataTranslation(int id)
        {
            PersonDataTranslation personDatatranslation1 = _repository.GetPersonDataTranslationById(id);
            var personDatatranslation = _mapper.Map<PersonDataTranslationReadedDTO>(personDatatranslation1);
            if (personDatatranslation == null) { }
            return Ok(personDatatranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getpersonbyidpersondatatranslation/{person_id}")]
        public IActionResult GetByPersonIdpersonDataTranslation(int person_id, string language_code)
        {
            PersonDataTranslation personDatatranslation1 = _repository.GetPersonDataTranslationByPersonId(person_id, language_code);
            var personDatatranslation = _mapper.Map<PersonDataTranslationReadedDTO>(personDatatranslation1);
            if (personDatatranslation == null) { }
            return Ok(personDatatranslation);
        }

        [HttpGet("sitegetallpersondatatranslation")]
        public IActionResult GetAllpersonDataTranslationsite(int queryNum, int pageNum, string? language_code, string? employee_type)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<PersonDataTranslation> personDatatranslationes1;
            if (employee_type == null)
            {
                personDatatranslationes1 = _repository.AllPersonDataTranslationSite(queryNum, pageNum, language_code);
                var personDatatranslationes = _mapper.Map<IEnumerable<PersonDataTranslationReadedSiteDTO>>(personDatatranslationes1);
                return Ok(personDatatranslationes);
            }
            else
            {
                personDatatranslationes1 = _repository.AllPersonDataTranslationEmployeeTypeSite(queryNum, pageNum, language_code, employee_type);
                var personDatatranslationes = _mapper.Map<IEnumerable<PersonDataTranslationReadedEmployeeTypeSiteDTO>>(personDatatranslationes1);
                return Ok(personDatatranslationes);
            }

        }

        [HttpGet("sitegetallpersondatatranslationdepuzid/{department_uz_id}")]
        public IActionResult GetAllpersonDataTranslationsiteDepUzId(int department_uz_id, string language_code)
        {
            IEnumerable<PersonDataTranslation> personDatatranslationes1;
            personDatatranslationes1 = _repository.AllPersonDataTranslationDepId(department_uz_id, language_code);
            var personDatatranslationes = _mapper.Map<IEnumerable<PersonDataTranslationReadedSiteDTO>>(personDatatranslationes1);
            return Ok(personDatatranslationes);
        }

        [HttpGet("sitegetbyuzidpersondatatranslation/{uz_id}")]
        public IActionResult GetByIdpersonDataTranslationsite(int uz_id, string language_code)
        {
            PersonDataTranslation personDatatranslation1 = _repository.GetPersonDataTranslationByIdSite(uz_id, language_code);
            var personDatatranslation = _mapper.Map<PersonDataTranslationReadedSiteDTO>(personDatatranslation1);
            if (personDatatranslation == null) { }
            return Ok(personDatatranslation);
        }

        [HttpGet("sitegetbyidpersondatatranslation/{id}")]
        public IActionResult GetByIdpersonDataTranslationsite(int id)
        {
            PersonDataTranslation personDatatranslation1 = _repository.GetPersonDataTranslationByIdSite(id);
            var personDatatranslation = _mapper.Map<PersonDataTranslationReadedSiteDTO>(personDatatranslation1);
            if (personDatatranslation == null) { }
            return Ok(personDatatranslation);
        }


        [HttpGet("sitegetbypersonidpersondatatranslation/{person_id}")]
        public IActionResult GetByPersonIdpersonDataTranslationsite(int person_id, string language_code)
        {
            PersonDataTranslation personDatatranslation1 = _repository.GetPersonDataTranslationByPersonIdSite(person_id, language_code);
            var personDatatranslation = _mapper.Map<PersonDataTranslationReadedSiteDTO>(personDatatranslation1);
            if (personDatatranslation == null) { }
            return Ok(personDatatranslation);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deletepersondatatranslation/{id}")]
        public IActionResult DeletepersonDataTranslation(int id)
        {
            bool check = _repository.DeletePersonDataTranslation(id);
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
        [HttpPut("updatepersondatatranslation/{id}")]
        public IActionResult UpdatepersonDataTranslation(PersonDataTranslationUpdatedDTO personDatatranslation1, int id)
        {
            try
            {
                if (personDatatranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<PersonDataTranslation>(personDatatranslation1);
                dbupdated.persons_translation_.status_translation_id = dbupdated.status_translation_id;
                bool updatedcheck = _repository.UpdatePersonDataTranslation(id, dbupdated);
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
