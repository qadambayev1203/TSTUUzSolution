using AutoMapper;
using Contracts.AllRepository.FilesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities.DTO.FilesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.FileControllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStatusRepositoryStatic _status;

        public FilesController(IFileRepository repository, IMapper mapper, IStatusRepositoryStatic _status1)
        {
            _repository = repository;
            _mapper = mapper;
            _status = _status1;
        }


        // files CRUD

        [Authorize]
        [HttpPost("uploadfiles")]
        public IActionResult UploadFiles(FilesCreatedDTO files1)
        {
            if (files1.url == null || files1.url.Length == 0)
                return BadRequest();
            var files = _mapper.Map<Files>(files1);
            FileUploadRepository fileUpload = new FileUploadRepository();

            var Url = fileUpload.SaveFileAsync(files1.url, true);

            if (Url == "File not found or empty!")
            {
                return BadRequest("File not found or empty!");
            }
            if (Url == "Invalid file extension!")
            {
                return BadRequest("Invalid file extension!");
            }
            if (Url == "Error!")
            {
                return BadRequest("File Upload Error!");
            }

            files.url = Url;
            files.user_id = SessionClass.id;
            files.status_id = _status.GetStatusId("Active");
            int check = _repository.CreateFiles(files);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                return BadRequest();
            }
            CreatedItemFileId createdItemId = new CreatedItemFileId()
            {
                id = check,
                url = Url,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallfiles")]
        public IActionResult GetAllfiles(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Files> files1 = _repository.AllFile(queryNum, pageNum);
            var files = _mapper.Map<IEnumerable<FilesReadedDTO>>(files1);
            if (files == null) { }

            return Ok(files);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidfiles/{id}")]
        public IActionResult GetByIdfiles(int id)
        {

            Files files1 = _repository.GetFilesById(id);
            if (files1 == null)
            {

            }
            var files = _mapper.Map<FilesReadedDTO>(files1);
            return Ok(files);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletefiles/{id}")]
        public IActionResult Deletefiles(int id)
        {
            bool check = _repository.DeleteFiles(id);
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
        [HttpPut("updatefiles/{id}")]
        public IActionResult Updatefiles(FilesUpdatedDTO files, int id)
        {
            try
            {
                if (files == null)
                {
                    return BadRequest();
                }


                var file = _mapper.Map<Files>(files);
                FileUploadRepository fileUpload = new FileUploadRepository();
                var Url = fileUpload.SaveFileAsync(files.url, true);
                if (Url == "File not found or empty!")
                {
                    return BadRequest("File not found or empty!");
                }
                if (Url == "Invalid file extension!")
                {
                    return BadRequest("Invalid file extension!");
                }
                if (Url == "Error!")
                {
                    return BadRequest("File Upload Error!");
                }
                file.url = Url;
                file.updated_at = DateTime.UtcNow;

                bool updatedcheck = _repository.UpdateFiles(id, file);
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


        [Authorize]
        [HttpGet("selectgetallfiles")]
        public IActionResult SelectGetAllfiles([FromQuery] bool? image)
        {
            IEnumerable<Files> files1 = _repository.SelectFileTitle(image);
            var files = _mapper.Map<IEnumerable<FileSelectDTO>>(files1);
            if (files == null)
            {
                return NotFound();
            }
            return Ok(files);
        }



        //filesTranslation CRUD

        [Authorize]
        [HttpPost("uploadfilestranslation")]
        public IActionResult UploadFilesTranslation(FilesTranslationCreatedDTO filestranslation1)
        {
            if (filestranslation1.url == null || filestranslation1.url.Length == 0)
                return BadRequest();
            var filestranslation = _mapper.Map<FilesTranslation>(filestranslation1);
            FileUploadRepository fileUpload = new FileUploadRepository();
            string Url = fileUpload.SaveFileAsync(filestranslation1.url, true);
            if (Url == "File not found or empty!")
            {
                return BadRequest("File not found or empty!");
            }
            if (Url == "Invalid file extension!")
            {
                return BadRequest("Invalid file extension!");
            }
            if (Url == "Error!")
            {
                return BadRequest("File Upload Error!");
            }
            filestranslation.url = Url;
            filestranslation.user_id = SessionClass.id;
            filestranslation.status_translation_id = _status.GetStatusTranslationId("Active", (int)filestranslation.language_id);
            filestranslation.crated_at = DateTime.UtcNow;
            int check = _repository.CreateFilesTranslation(filestranslation);

            if (check == 0)
            {
                fileUpload.DeleteFileAsync(Url);
                return BadRequest();
            }
            CreatedItemFileId createdItemId = new CreatedItemFileId()
            {
                id = check,
                url = Url,
                StatusCode = 200
            };

            return Ok(createdItemId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getallfilestranslation")]
        public IActionResult GetAllfilesTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<FilesTranslation> filestranslationes1 = _repository.AllFilesTranslation(queryNum, pageNum, language_code);
            var filestranslationes = _mapper.Map<IEnumerable<FilesTranslationReadedDTO>>(filestranslationes1);
            if (filestranslationes == null)
            {

            }
            return Ok(filestranslationes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyuzidfilestranslation/{uz_id}")]
        public IActionResult GetByIdfilesTranslation(int uz_id, string language_code)
        {

            FilesTranslation filestranslation1 = _repository.GetFilesTranslationByIdSite(uz_id, language_code);
            if (filestranslation1 == null)
            {

            }
            var filestranslation = _mapper.Map<FilesTranslationReadedDTO>(filestranslation1);

            return Ok(filestranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidfilestranslation/{id}")]
        public IActionResult GetByIdfilesTranslation(int id)
        {

            FilesTranslation filestranslation1 = _repository.GetFilesTranslationById(id);
            if (filestranslation1 == null)
            {

            }
            var filestranslation = _mapper.Map<FilesTranslationReadedDTO>(filestranslation1);

            return Ok(filestranslation);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletefilestranslation/{id}")]
        public IActionResult DeletefilesTranslation(int id)
        {
            bool check = _repository.DeleteFilesTranslation(id);
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
        [HttpPut("updatefilestranslation/{id}")]
        public IActionResult UpdatefilesTranslation(FilesTranslationUpdatedDTO filestranslation1, int id)
        {

            try
            {
                if (filestranslation1 == null)
                {
                    return BadRequest();
                }

                var filesTranslation = _mapper.Map<FilesTranslation>(filestranslation1);

                FileUploadRepository fileUpload = new FileUploadRepository();
                var Url = fileUpload.SaveFileAsync(filestranslation1.url, true);
                if (Url == "File not found or empty!")
                {
                    return BadRequest("File not found or empty!");
                }
                if (Url == "Invalid file extension!")
                {
                    return BadRequest("Invalid file extension!");
                }
                if (Url == "Error!")
                {
                    return BadRequest("File Upload Error!");
                }
                filesTranslation.url = Url;
                filesTranslation.updated_at = DateTime.UtcNow;

                bool updatedcheck = _repository.UpdateFilesTranslation(id, filesTranslation);
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

        [Authorize]
        [HttpGet("selectgetallfilestranslation")]
        public IActionResult SelectGetAllfilesTranslation([FromQuery] bool? image, string? language_code)
        {
            IEnumerable<FilesTranslation> files1 = _repository.SelectFileTranslationTitle(image, language_code);
            var files = _mapper.Map<IEnumerable<FileTranslationSelectDTO>>(files1);
            if (files == null) { }

            return Ok(files);
        }


    }
}
