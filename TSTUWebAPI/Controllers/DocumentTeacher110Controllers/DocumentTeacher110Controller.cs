using AutoMapper;
using Contracts.AllRepository.DocumentTeacher110Repository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.DocumentTeacher110DTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DocumentTeacher110Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.DocumentTeacher110Controllers
{
    [Route("api/documentteacher110controller")]
    [ApiController]
    public class DocumentTeacher110Controller : ControllerBase
    {
        private readonly IDocumentTeacher110Repository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public DocumentTeacher110Controller(IDocumentTeacher110Repository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createdocumentteacher110")]
        public IActionResult CreateDocumentTeacher110(DocumentTeacher110CreatedDTO documentTeacher110)
        {
            var documentTeacher110Map = _mapper.Map<DocumentTeacher110>(documentTeacher110);
            documentTeacher110Map.status_id = _status.GetStatusId("Active");
            int id = _repository.CreateDocumentTeacher110(documentTeacher110Map);

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

        [Authorize(Roles = "Admin,Teacher")]
        [HttpGet("getalldocumentteacher110")]
        public IActionResult GetAllDocumentTeacher110(bool parent, int? parent_id)
        {
            IEnumerable<DocumentTeacher110> documentTeacher110Map = _repository.AllDocumentTeacher110(parent_id, parent);
            var documentTeacher110 = _mapper.Map<IEnumerable<DocumentTeacher110ReadedDTO>>(documentTeacher110Map);

            return Ok(documentTeacher110);
        }

        [Authorize(Roles = "")]
        [HttpGet("getalldocumentteacher110select")]
        public IActionResult GetAllDocumentTeacher110Select()
        {
            IEnumerable<DocumentTeacher110> documentTeacher110Map = _repository.AllDocumentTeacher110Select();
            var documentTeacher110 = _mapper.Map<IEnumerable<DocumentTeacher110SelectDTO>>(documentTeacher110Map);
            return Ok(documentTeacher110);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("getalldocumentteacher110admin")]
        public IActionResult GetAllDocumentTeacher110Admin(bool parent, int? parent_id)
        {
            IEnumerable<DocumentTeacher110> documentTeacher110Map = _repository.AllDocumentTeacher110Admin(parent_id, parent);
            var documentTeacher110 = _mapper.Map<IEnumerable<DocumentTeacher110AdminReadedDTO>>(documentTeacher110Map);

            return Ok(documentTeacher110);
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpGet("getbyiddocumentteacher110/{id}")]
        public IActionResult GetByIdDocumentTeacher110(int id)
        {
            DocumentTeacher110 documentTeacher110Map = _repository.GetDocumentTeacher110ById(id);
            var documentTeacher110 = _mapper.Map<DocumentTeacher110ReadedDTO>(documentTeacher110Map);
            return Ok(documentTeacher110);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiddocumentteacher110admin/{id}")]
        public IActionResult GetByIdDocumentTeacher110Admin(int id)
        {
            DocumentTeacher110 documentTeacher110Map = _repository.GetDocumentTeacher110ByIdAdmin(id);
            var documentTeacher110 = _mapper.Map<DocumentTeacher110AdminReadedDTO>(documentTeacher110Map);
            return Ok(documentTeacher110);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletedocumentteacher110/{id}")]
        public IActionResult DeleteDocumentTeacher110(int id)
        {
            bool check = _repository.DeleteDocumentTeacher110(id);
            if (!check)
            {
                return BadRequest("Not Deleted");
            }
            return Ok("Deleted");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatedocumentteacher110/{id}")]
        public IActionResult UpdateDocumentTeacher110(DocumentTeacher110UpdatedDTO documentTeacher110, int id)
        {
            try
            {
                if (documentTeacher110 == null)
                {
                    return BadRequest();
                }

                var documentTeacher110Map = _mapper.Map<DocumentTeacher110>(documentTeacher110);

                bool updatedcheck = _repository.UpdateDocumentTeacher110(id, documentTeacher110Map);
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
