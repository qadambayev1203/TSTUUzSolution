using AutoMapper;
using Contracts.AllRepository.DepartamentsRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.DepartamentDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.FileModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSTUWebAPI.Controllers.FileControllers;

namespace TSTUWebAPI.Controllers.DepartamentsController
{
    [Route("api/departament")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartamentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public DepartamentController(IDepartamentRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // Departament CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createdepartament")]
        public IActionResult CreateDepartament(DepartamentCreatedDTO departament1)
        {
            var departament = _mapper.Map<Departament>(departament1);
            departament.status_id = _status.GetStatusId("Active");

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(departament1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                departament.img_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }

            var Url1 = fileUpload.SaveFileAsync(departament1.img_icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                departament.img_icon_ = new Files
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }


            int check = _repository.CreateDepartament(departament);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                fileUpload.DeleteFileAsync(Url1);
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalldepartament")]
        public IActionResult GetAllDepartament(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<Departament> departaments1 = _repository.AllDepartament(queryNum, pageNum);
            var departaments = _mapper.Map<IEnumerable<DepartamentReadedDTO>>(departaments1.query_list);

            ResponseModel<DepartamentReadedDTO> response = new ResponseModel<DepartamentReadedDTO>
            {
                length = departaments1.length,
                list = departaments
            };

            return Ok(departaments);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiddepartament/{id}")]
        public IActionResult GetByIdDepartament(int id)
        {

            Departament departament1 = _repository.GetDepartamentById(id);
            var departament = _mapper.Map<DepartamentReadedDTO>(departament1);
            return Ok(departament);
        }

        [HttpGet("sitegetalldepartament")]
        public IActionResult GetAllDepartamentsite(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<Departament> departaments1 = _repository.AllDepartamentSite(queryNum, pageNum);
            var departaments = _mapper.Map<IEnumerable<DepartamentReadedSiteDTO>>(departaments1.query_list);

            ResponseModel<DepartamentReadedSiteDTO> response = new ResponseModel<DepartamentReadedSiteDTO>
            {
                length = departaments1.length,
                list = departaments
            };

            return Ok(response);
        }

        [HttpGet("sitegetalldepartamentchild/{parent_id}")]
        public IActionResult GetAllDepartamentChild(int parent_id)
        {

            IEnumerable<Departament> departaments1 = _repository.AllDepartamentChild(parent_id);
            var departaments = _mapper.Map<IEnumerable<DepartamentReadedSiteDTO>>(departaments1);

            return Ok(departaments);
        }

        [HttpGet("sitegetalldepartamentfacultychild/{faculty_id}")]
        public IActionResult GetAllDepartamentFacultyChildDirection(int faculty_id)
        {

            IEnumerable<Departament> departaments1 = _repository.AllDepartamentFacultyDirection(faculty_id);
            var departaments = _mapper.Map<IEnumerable<DepartamentReadedSiteDTO>>(departaments1);

            return Ok(departaments);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalldepartamenttype/{departament_type}")]
        public IActionResult GetAllDepartamentType(string departament_type, int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<Departament> departaments1 = _repository.AllDepartamentType(departament_type, queryNum, pageNum);
            var departaments = _mapper.Map<IEnumerable<DepartamentReadedTypedDTO>>(departaments1.query_list);

            ResponseModel<DepartamentReadedTypedDTO> response = new ResponseModel<DepartamentReadedTypedDTO>
            {
                length = departaments1.length,
                list = departaments
            };

            return Ok(departaments);
        }

        [HttpGet("getalldepartamenttypesite/{departament_type}")]
        public IActionResult GetAllDepartamentTypeSite(string departament_type, int queryNum, int pageNum, bool? favorite)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<Departament> departaments1 = _repository.AllDepartamentTypeSite(departament_type, queryNum, pageNum, favorite);
            var departaments = _mapper.Map<IEnumerable<DepartamentReadedSiteDTO>>(departaments1.query_list);

            ResponseModel<DepartamentReadedSiteDTO> response = new ResponseModel<DepartamentReadedSiteDTO>
            {
                length = departaments1.length,
                list = departaments
            };

            return Ok(response);
        }

        [HttpGet("selecteddepartament")]
        public IActionResult SelectDepartamentType()
        {

            IEnumerable<Departament> departaments1 = _repository.SelectDepartaments();
            var departaments = _mapper.Map<IEnumerable<DepartamentSelectedReadedDTO>>(departaments1);
            return Ok(departaments);
        }

        [HttpGet("structuredepartament")]
        public IActionResult StructureDepartament()
        {

            IEnumerable<Departament> departaments1 = _repository.AllDepartamentStructure();
            var departaments = _mapper.Map<IEnumerable<DepartamentStructureReadedDTO>>(departaments1);
            return Ok(departaments);
        }

        [HttpGet("sitegetbyiddepartament/{id}")]
        public IActionResult GetByIdDepartamentsite(int id)
        {

            Departament departament1 = _repository.GetDepartamentByIdSite(id);

            var departament = _mapper.Map<DepartamentReadedSiteDTO>(departament1);
            if (departament == null) { }

            return Ok(departament);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletedepartament/{id}")]
        public IActionResult DeleteDepartament(int id)
        {
            bool check = _repository.DeleteDepartament(id);
            if (!check)
            {
                return StatusCode(400);
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(400);
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatedepartament/{id}")]
        public IActionResult UpdateDepartament(DepartamentUpdatedDTO departament1, int id)
        {

            try
            {
                if (departament1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<Departament>(departament1);
                

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(departament1.img_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url != null && Url.Length > 0)
                {
                    dbupdated.img_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }

                var Url1 = fileUpload.SaveFileAsync(departament1.img_icon_up);
                if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url1 != null && Url1.Length > 0)
                {
                    dbupdated.img_icon_ = new Files
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url1
                    };
                }

                bool updatedcheck = _repository.UpdateDepartament(id, dbupdated);
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







        //DepartamentTranslation CRUD
        [Authorize(Roles = "Admin")]
        [HttpPost("createdepartamenttranslation")]
        public IActionResult CreateDepartamentTranslation(DepartamentTranslationCreatedDTO departamenttranslation1)
        {
            var departamenttranslation = _mapper.Map<DepartamentTranslation>(departamenttranslation1);
            departamenttranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)departamenttranslation.language_id);

            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(departamenttranslation1.img_up);
            if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url != null && Url.Length > 0)
            {
                departamenttranslation.img_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url
                };
            }

            var Url1 = fileUpload.SaveFileAsync(departamenttranslation1.img_icon_up);
            if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
            {
                return BadRequest("File created error!");
            }
            if (Url1 != null && Url1.Length > 0)
            {
                departamenttranslation.img_icon_ = new FilesTranslation
                {
                    title = Guid.NewGuid().ToString(),
                    url = Url1
                };
            }

            int check = _repository.CreateDepartamentTranslation(departamenttranslation);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                fileUpload.DeleteFileAsync(Url1);
                return StatusCode(400);
            }
            CreatedItemId createdItemId = new CreatedItemId()
            {
                id = check,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalldepartamenttranslation")]
        public IActionResult GetAllDepartamentTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslation(queryNum, pageNum, language_code);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationReadedDTO>>(departamenttranslations1.query_list);

            ResponseModel<DepartamentTranslationReadedDTO> response = new ResponseModel<DepartamentTranslationReadedDTO>
            {
                length = departamenttranslations1.length,
                list = departamenttranslations
            };
            return Ok(departamenttranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuziddepartamenttranslation/{uz_id}")]
        public IActionResult GetByIdDepartamentTranslation(int uz_id, string language_code)
        {

            DepartamentTranslation departamenttranslation1 = _repository.GetDepartamentTranslationById(uz_id, language_code);
            var departamenttranslation = _mapper.Map<DepartamentTranslationReadedDTO>(departamenttranslation1);

            return Ok(departamenttranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyiddepartamenttranslation/{id}")]
        public IActionResult GetByIdDepartamentTranslation(int id)
        {

            DepartamentTranslation departamenttranslation1 = _repository.GetDepartamentTranslationById(id);
            var departamenttranslation = _mapper.Map<DepartamentTranslationReadedDTO>(departamenttranslation1);
            if (departamenttranslation == null) { }
            return Ok(departamenttranslation);
        }

        [HttpGet("sitegetalldepartamenttranslation")]
        public IActionResult GetAllDepartamentTranslationsite(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslationSite(queryNum, pageNum, language_code);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationReadedSiteDTO>>(departamenttranslations1.query_list);

            ResponseModel<DepartamentTranslationReadedSiteDTO> response = new ResponseModel<DepartamentTranslationReadedSiteDTO>
            {
                length = departamenttranslations1.length,
                list = departamenttranslations
            };
            return Ok(response);
        }

        [HttpGet("sitegetalldepartamenttranslationchild/{parent_id}")]
        public IActionResult GetAllDepartamentTranslationChild(int parent_id, string? language_code)
        {

            IEnumerable<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslationChild(parent_id, language_code);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationReadedSiteFacultyDTO>>(departamenttranslations1);

            return Ok(departamenttranslations);
        }

        [HttpGet("sitegetalldepartamenttranslationfacultychild/{faculty_id}")]
        public IActionResult GetAllDepartamentTranslationFacultyChildDirection(int faculty_id, string? language_code)
        {

            IEnumerable<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslationFacultyDirection(faculty_id, language_code);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationReadedSiteFacultyDTO>>(departamenttranslations1);

            return Ok(departamenttranslations);
        }

        [HttpGet("selectdepartamenttranslation")]
        public IActionResult SelectDepartamentTranslation(string? language_code)
        {

            IEnumerable<DepartamentTranslation> departamenttranslations1 = _repository.SelectDepartamentsTranslation(language_code);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationSelectedReadedDTO>>(departamenttranslations1);

            return Ok(departamenttranslations);
        }

        [HttpGet("structuredepartamenttranslation")]
        public IActionResult StructureDepartamentTranslation(string? language_code)
        {

            IEnumerable<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslationStructure(language_code);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationStructureReadedDTO>>(departamenttranslations1);
            return Ok(departamenttranslations);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getalldepartamenttranslationtype/{departament_type}")]
        public IActionResult GetAllDepartamentTranslationChild(string departament_type, string? language_code, int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslationType(departament_type, language_code, queryNum, pageNum);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationReadedTypedDTO>>(departamenttranslations1.query_list);

            ResponseModel<DepartamentTranslationReadedTypedDTO> response = new ResponseModel<DepartamentTranslationReadedTypedDTO>
            {
                length = departamenttranslations1.length,
                list = departamenttranslations
            };
            return Ok(departamenttranslations);
        }

        [HttpGet("getalldepartamenttranslationtypesite/{departament_type_uz}")]
        public IActionResult GetAllDepartamentTranslationChildSite(string departament_type_uz, string? language_code, int queryNum, int pageNum, bool? favorite)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            QueryList<DepartamentTranslation> departamenttranslations1 = _repository.AllDepartamentTranslationTypeSite(departament_type_uz, language_code, queryNum, pageNum, favorite);
            var departamenttranslations = _mapper.Map<IEnumerable<DepartamentTranslationReadedSiteDTO>>(departamenttranslations1.query_list);

            ResponseModel<DepartamentTranslationReadedSiteDTO> response = new ResponseModel<DepartamentTranslationReadedSiteDTO>
            {
                length = departamenttranslations1.length,
                list = departamenttranslations
            };
            return Ok(response);
        }

        [HttpGet("sitegetbyiddepartamenttranslation/{id}")]
        public IActionResult GetByIdDepartamentTranslationsite(int id)
        {

            DepartamentTranslation departamenttranslation1 = _repository.GetDepartamentTranslationByIdSite(id);
            var departamenttranslation = _mapper.Map<DepartamentTranslationReadedSiteDTO>(departamenttranslation1);

            return Ok(departamenttranslation);
        }

        [HttpGet("sitegetbyuziddepartamenttranslation/{uz_id}")]
        public IActionResult GetByIdDepartamentTranslationsite(int uz_id, string language_code)
        {

            DepartamentTranslation departamenttranslation1 = _repository.GetDepartamentTranslationByIdSite(uz_id, language_code);
            var departamenttranslation = _mapper.Map<DepartamentTranslationReadedSiteDTO>(departamenttranslation1);

            return Ok(departamenttranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletedepartamenttranslation/{id}")]
        public IActionResult DeleteDepartamentTranslation(int id)
        {
            bool check = _repository.DeleteDepartamentTranslation(id);
            if (!check)
            {
                return StatusCode(400);
            }
            bool check1 = _repository.SaveChanges();
            if (!check1)
            {
                return StatusCode(400);
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatedepartamenttranslation/{id}")]
        public IActionResult UpdateDepartamentTranslation(DepartamentTranslationUpdatedDTO departamenttranslation1, int id)
        {

            try
            {
                if (departamenttranslation1 == null)
                {
                    return BadRequest();
                }

                var dbupdated = _mapper.Map<DepartamentTranslation>(departamenttranslation1);

                FileUploadRepository fileUpload = new FileUploadRepository();

                var Url = fileUpload.SaveFileAsync(departamenttranslation1.img_up);
                if (Url == "File not found or empty!" || Url == "Invalid file extension!" || Url == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url != null && Url.Length > 0)
                {
                    dbupdated.img_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url
                    };
                }

                var Url1 = fileUpload.SaveFileAsync(departamenttranslation1.img_icon_up);
                if (Url1 == "File not found or empty!" || Url1 == "Invalid file extension!" || Url1 == "Error!")
                {
                    return BadRequest("File created error!");
                }
                if (Url1 != null && Url1.Length > 0)
                {
                    dbupdated.img_icon_ = new FilesTranslation
                    {
                        title = Guid.NewGuid().ToString(),
                        url = Url1
                    };
                }

                bool updatedcheck = _repository.UpdateDepartamentTranslation(id, dbupdated);
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
