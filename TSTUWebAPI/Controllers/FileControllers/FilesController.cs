using AutoMapper;
using Contracts.AllRepository.FilesRepository;
using Entities.DTO.FilesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.FileControllers
{
    [Route("api/files")]
    [Authorize]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileRepository _repository;
        private readonly IMapper _mapper;
        public FilesController(IFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // files CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("uploadfiles")]
        public IActionResult UploadFiles(FilesCreatedDTO files1)
        {
            var files = _mapper.Map<Files>(files1);
            FileUploadRepository fileUpload = new FileUploadRepository();
            var Url = fileUpload.SaveFileAsync(files1.url);
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
            int check = _repository.CreateFiles(files);

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
        [HttpGet("getallfiles")]
        public IActionResult GetAllfiles(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Files> files1 = _repository.AllFile(queryNum, pageNum);
            var files = _mapper.Map<IEnumerable<FilesReadedDTO>>(files1);
            if (files == null || files.Count() == 0) { return NotFound(); }

            return Ok(files);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidfiles/{id}")]
        public IActionResult GetByIdfiles(int id)
        {

            Files files1 = _repository.GetFilesById(id);
            if (files1 == null)
            {
                return NotFound();
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
                var file = _repository.GetFilesById(id);
                if (file == null || files == null)
                {
                    return NotFound();
                }
                file.updated_at = DateTime.UtcNow;

                FileUploadRepository fileUpload = new FileUploadRepository();
                var Url = fileUpload.SaveFileAsync(files.url);
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



                _mapper.Map(files, file);
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


        [Authorize(Roles = "Admin")]
        [HttpGet("selectgetallfiles")]
        public IActionResult SelectGetAllfiles()
        {
            IEnumerable<Files> files1 = _repository.SelectFileTitle();
            var files = _mapper.Map<IEnumerable<FileSelectDTO>>(files1);
            if (files == null || files.Count() == 0) { return NotFound(); }

            return Ok(files);
        }







        //filesTranslation CRUD
        [Authorize(Roles = "Admin")]
        [HttpPost("uploadfilestranslation")]
        public IActionResult UploadFilesTranslation(FilesTranslationCreatedDTO filestranslation1)
        {
            var filestranslation = _mapper.Map<FilesTranslation>(filestranslation1);
            FileUploadRepository fileUpload = new FileUploadRepository();
            string Url = fileUpload.SaveFileAsync(filestranslation1.url);
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
            int check = _repository.CreateFilesTranslation(filestranslation);

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
        [HttpGet("getallfilestranslation")]
        public IActionResult GetAllfilesTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<FilesTranslation> filestranslationes1 = _repository.AllFilesTranslation(queryNum, pageNum, language_code);
            var filestranslationes = _mapper.Map<IEnumerable<FilesTranslationReadedDTO>>(filestranslationes1);
            if (filestranslationes == null || filestranslationes.Count() == 0)
            {
                return NotFound();
            }
            return Ok(filestranslationes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyidfilestranslation/{id}")]
        public IActionResult GetByIdfilesTranslation(int id)
        {

            FilesTranslation filestranslation1 = _repository.GetFilesTranslationById(id);
            if (filestranslation1 == null)
            {
                return NotFound();
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
                var filestranslation = _repository.GetFilesTranslationById(id);
                if (filestranslation == null || filestranslation1 == null)
                {
                    return NotFound();
                }


                FileUploadRepository fileUpload = new FileUploadRepository();
                string Url = fileUpload.SaveFileAsync(filestranslation1.url);
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

                _mapper.Map(filestranslation1, filestranslation);
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

        [Authorize(Roles = "Admin")]
        [HttpGet("selectgetallfilestranslation")]
        public IActionResult SelectGetAllfilesTranslation(string? language_code)
        {
            IEnumerable<FilesTranslation> files1 = _repository.SelectFileTranslationTitle(language_code);
            var files = _mapper.Map<IEnumerable<FileTranslationSelectDTO>>(files1);
            if (files == null || files.Count() == 0) { return NotFound(); }

            return Ok(files);
        }
    }
}
