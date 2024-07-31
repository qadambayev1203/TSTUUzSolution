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


        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost("createdocumentteacher110set")]
        public IActionResult CreateDocumentTeacher110Set(DocumentTeacher110SetCreatedDTO documentTeacher110Set)
        {
            var documentTeacher110SetMap = _mapper.Map<DocumentTeacher110Set>(documentTeacher110Set);
            documentTeacher110SetMap.status_id = _status.GetStatusId("Active");
            documentTeacher110SetMap.created_at = DateTime.UtcNow;
            documentTeacher110SetMap.sequence_status = 1;

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

        [Authorize(Roles = "Admin")]
        [HttpGet("getdocumentteacher110setadmin")]
        public IActionResult GetDocumentTeacher110SetAdmin(int oldYear, int newYear, int person_id)
        {
            DocumentTeacher110SetList documentMap = _repository.DocumentTeacher110SetAdmin(oldYear, newYear, person_id);
            var document = _mapper.Map<DocumentTeacher110SetListReadedDTO>(documentMap);
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

        [Authorize(Roles = "Teacher")]
        [HttpGet("getbyiddocumentteacher110set/{id}")]
        public IActionResult GetByIdDocumentTeacher110Set(int id)
        {
            DocumentTeacher110Set documentTeacher110SetMap = _repository.GetDocumentTeacher110SetById(id);
            var documentTeacher110Set = _mapper.Map<DocumentTeacher110SetReadedDTO>(documentTeacher110SetMap);
            return Ok(documentTeacher110Set);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiddocumentteacher110setadmin/{id}")]
        public IActionResult GetByIdDocumentTeacher110SetAdmin(int id)
        {
            DocumentTeacher110Set documentTeacher110SetMap = _repository.GetDocumentTeacher110SetByIdAdmin(id);
            var documentTeacher110Set = _mapper.Map<DocumentTeacher110SetAdminReadedDTO>(documentTeacher110SetMap);
            return Ok(documentTeacher110Set);
        }

        [Authorize(Roles = "Admin")]
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


    }
}
