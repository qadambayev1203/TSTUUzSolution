using AutoMapper;
using Contracts.AllRepository.DocumentTeacher110Repository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.DocumentTeacher110SetDTOS;
using Entities.DTO.PersonDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DocumentTeacher110Model;
using Entities.Model.FileModel;
using Entities.Model.MenuModel;
using Entities.Model.PersonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.DocumentTeacher110SetControllers
{
    [Route("api/documentteacher110setcontroller")]
    [ApiController]
    public class DocumentTeacher110SetController : ControllerBase
    {
        private readonly IDocumentTeacher110SetRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public DocumentTeacher110SetController(IDocumentTeacher110SetRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        #region Teacher

        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost("createdocumentteacher110set")]
        public IActionResult CreateDocumentTeacher110Set(DocumentTeacher110SetCreatedDTO documentTeacher110Set)
        {
            var documentTeacher110SetMap = _mapper.Map<DocumentTeacher110Set>(documentTeacher110Set);
            documentTeacher110SetMap.status_id = _status.GetStatusId("Active");
            documentTeacher110SetMap.created_at = DateTime.UtcNow;
            documentTeacher110SetMap.sequence_status = 2;
            documentTeacher110SetMap.rejection = false;

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(documentTeacher110Set.file_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                documentTeacher110SetMap.file_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }


            int id = _repository.CreateDocumentTeacher110Set(documentTeacher110SetMap);

            if (id == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                return BadRequest();
            }

            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = id,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("getalldocumentteacher110set")]
        public IActionResult GetAllDocumentTeacher110Set(int oldYear, int newYear)
        {
            IEnumerable<DocumentTeacher110Set> documentTeacher110SetMap = _repository.AllDocumentTeacher110Set(oldYear, newYear);
            var documentTeacher110Set = _mapper.Map<IEnumerable<DocumentTeacher110SetReadedDTO>>(documentTeacher110SetMap);

            return Ok(documentTeacher110Set);
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpPut("updatedocumentteacher110set/{id}")]
        public IActionResult UpdateDocumentTeacher110Set(DocumentTeacher110SetUpdatedDTO documentTeacher110Set, int id)
        {
            try
            {
                if (documentTeacher110Set == null)
                {
                    return BadRequest();
                }

                var documentTeacher110SetMap = _mapper.Map<DocumentTeacher110Set>(documentTeacher110Set);

                documentTeacher110SetMap.sequence_status = 2;

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(documentTeacher110Set.file_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url != null && Url.Length > 0)
                {
                    documentTeacher110SetMap.file_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }


                bool updatedcheck = _repository.UpdateDocumentTeacher110Set(id, documentTeacher110SetMap);
                if (!updatedcheck)
                {
                    return BadRequest("Not Updated");
                }

                return Ok("Updated");
            }
            catch
            {
                return BadRequest();
            }

        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpDelete("deletedocumentteacher110set/{id}")]
        public IActionResult DeleteDocumentTeacher110Set(int id)
        {
            bool check = _repository.DeleteDocumentTeacher110Set(id);
            if (!check)
            {
                return BadRequest("Not Deleted");
            }
            return Ok("Deleted");
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("getbyiddocumentteacher110set/{id}")]
        public IActionResult GetByIdDocumentTeacher110Set(int id)
        {
            DocumentTeacher110Set documentTeacher110SetMap = _repository.GetDocumentTeacher110SetById(id);
            var documentTeacher110Set = _mapper.Map<DocumentTeacher110SetReadedDTO>(documentTeacher110SetMap);
            return Ok(documentTeacher110Set);
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("getbydocumentiddocumentteacher110set/{document_id}")]
        public IActionResult GetByDocumentIdDocumentTeacher110Set(int oldYear, int newYear, int document_id)
        {
            IEnumerable<DocumentTeacher110Set> documentTeacher110SetMap = _repository.GetDocumentTeacher110SetByDocumentId(oldYear, newYear, document_id);
            var documentTeacher110Set = _mapper.Map<IEnumerable<DocumentTeacher110SetReadedDTO>>(documentTeacher110SetMap);
            return Ok(documentTeacher110Set);
        }

        #endregion


        #region Admin

        [Authorize(Roles = "Admin")]
        [HttpGet("getdocumentteacher110setadmin")]
        public IActionResult GetDocumentTeacher110SetAdmin(int oldYear, int newYear, int person_id)
        {
            DocumentTeacher110SetList documentMap = _repository.DocumentTeacher110SetAdmin(oldYear, newYear, person_id);
            var document = _mapper.Map<DocumentTeacher110SetListReadedDTO<DocumentTeacher110SetAdminReadedDTO>>(documentMap);
            return Ok(document);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalldocumentteacher110setadmin")]
        public IActionResult GetAllDocumentTeacher110SetAdmin(int oldYear, int newYear)
        {
            IEnumerable<Person> personListMap = _repository.AllDocumentTeacher110SetAdmin(oldYear, newYear);
            var personList = _mapper.Map<IEnumerable<PersonUserDTO>>(personListMap);
            return Ok(personList);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiddocumentteacher110setadmin/{id}")]
        public IActionResult GetByIdDocumentTeacher110SetAdmin(int id)
        {
            DocumentTeacher110Set documentTeacher110SetMap = _repository.GetDocumentTeacher110SetByIdAdmin(id);
            var documentTeacher110Set = _mapper.Map<DocumentTeacher110SetAdminReadedDTO>(documentTeacher110SetMap);
            return Ok(documentTeacher110Set);
        }

        #endregion


        #region Head of Departament 

        [Authorize(Roles = "HeadDepartment")]
        [HttpGet("getalldocumentteacher110setdepartament")]
        public IActionResult GetAllDocumentTeacher110SetDepartament(int oldYear, int newYear)
        {
            IEnumerable<Person> personListMap = _repository.AllDocumentTeacher110SetConfirmationDepartament(oldYear, newYear);
            var personList = _mapper.Map<IEnumerable<PersonUserDTO>>(personListMap);
            return Ok(personList);
        }

        [Authorize(Roles = "HeadDepartment")]
        [HttpGet("getdocumentteacher110setdepartament")]
        public IActionResult GetDocumentTeacher110SetDepartament(int oldYear, int newYear, int person_id)
        {
            DocumentTeacher110SetList documentMap = _repository.DocumentTeacher110SetConfirmDep(oldYear, newYear, person_id);
            var document = _mapper.Map<DocumentTeacher110SetListReadedDTO<DocumentTeacher110SetReadedDTO>>(documentMap);
            return Ok(document);
        }

        [Authorize(Roles = "Admin,HeadDepartment")]
        [HttpPut("confirmheaddepartamentdocument110/{id}")]
        public IActionResult ConfirmDocumentTeacher110Set(int id, bool confirm, string? reason_for_rejection)
        {
            try
            {

                bool updatedcheck = _repository.ConfirmDocumentTeacher110Set(id, confirm, reason_for_rejection);
                if (!updatedcheck)
                {
                    return BadRequest("Not Confirmed");
                }

                return Ok("Confirmed");
            }
            catch
            {
                return BadRequest();
            }

        }


        #endregion


        #region Study department

        [Authorize(Roles = "StudyDepartment")]
        [HttpGet("getalldocumentteacher110setstudydepartament")]
        public IActionResult GetAllDocumentTeacher110SetStudyDepartament(int oldYear, int newYear)
        {
            IEnumerable<Person> personListMap = _repository.AllDocumentTeacher110SetConfirmationStudyDep(oldYear, newYear);
            var personList = _mapper.Map<IEnumerable<PersonUserDTO>>(personListMap);
            return Ok(personList);
        }

        [Authorize(Roles = "StudyDepartment")]
        [HttpGet("getdocumentteacher110setstudydepartament")]
        public IActionResult GetDocumentTeacher110SetStudyDepartament(int oldYear, int newYear, int person_id)
        {
            DocumentTeacher110SetList documentMap = _repository.DocumentTeacher110SetConfirmStudyDep(oldYear, newYear, person_id);
            var document = _mapper.Map<DocumentTeacher110SetListReadedDTO<DocumentTeacher110SetReadedDTO>>(documentMap);
            return Ok(document);
        }

        [Authorize(Roles = "Admin,StudyDepartment")]
        [HttpPut("confirmstudydepartamentdocument110/{id}")]
        public IActionResult ConfirmDocumentTeacher110SetStudyDep(int id, DocumentTeacher110SetConfirmStudyDepDTO confirmStudyDepDTO)
        {
            try
            {
                if (confirmStudyDepDTO == null)
                {
                    return BadRequest();
                }

                var documentTeacher110SetMap = _mapper.Map<DocumentTeacher110Set>(confirmStudyDepDTO);

                bool updatedcheck = _repository.ConfirmDocumentTeacher110SetStudyDep(id, confirmStudyDepDTO.confirm, documentTeacher110SetMap);
                if (!updatedcheck)
                {
                    return BadRequest("Not Confirmed");
                }

                return Ok("Confirmed");
            }
            catch
            {
                return BadRequest();
            }

        }


        #endregion region



    }
}
