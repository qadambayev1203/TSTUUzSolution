using AutoMapper;
using Contracts.AllRepository.FilesRepository;
using Entities.DTO.FilesDTOS;
using Entities.Model.FileModel;
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
        public FilesController(IFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // files CRUD

        [HttpPost("createfiles")]
        public IActionResult Createfiles(FilesCreatedDTO files1)
        {
            var files = _mapper.Map<Files>(files1);
            bool check = _repository.CreateFiles(files);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallfiles")]
        public IActionResult GetAllfiles()
        {

            IEnumerable<Files> files1 = _repository.AllFile();
            var files = _mapper.Map<IEnumerable<FilesReadedDTO>>(files1); 
            return Ok(files);
        }

        [HttpGet("getbyidfiles/{id}")]
        public IActionResult GetByIdfiles(int id)
        {

            Files files1 = _repository.GetFilesById(id);
            if(files1 == null){
                return NotFound();
            }
            var files = _mapper.Map<FilesReadedDTO>(files1);
            return Ok(files);
        }


        [HttpDelete("deletefiles/{id}")]
        public IActionResult Deletefiles(int id)
        {
            bool check = _repository.DeleteFiles(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatefiles/{id}")]
        public IActionResult Updatefiles(FilesUpdatedDTO files, int id)
        {
            try
            {
                var file = _repository.GetFilesById(id);
                if (file == null)
                {
                    return NotFound();
                }
                _mapper.Map(files, file);
                bool check = _repository.UpdateFiles();
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







        //filesTranslation CRUD
        [HttpPost("createfilestranslation")]
        public IActionResult CreatefilesTranslation(FilesTranslationCreatedDTO filestranslation1)
        {
            var filestranslation = _mapper.Map<FilesTranslation>(filestranslation1);
            bool check = _repository.CreateFilesTranslation(filestranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Ok("Created");
        }

        [HttpGet("getallfilestranslation")]
        public IActionResult GetAllfilesTranslation()
        {

            IEnumerable<FilesTranslation> filestranslationes1 = _repository.AllFilesTranslation();
            var filestranslationes = _mapper.Map<IEnumerable<FilesTranslationReadedDTO>>(filestranslationes1);
            return Ok(filestranslationes);
        }

        [HttpGet("getbyidfilestranslation/{id}")]
        public IActionResult GetByIdfilesTranslation(int id)
        {

            FilesTranslation filestranslation1 = _repository.GetFilesTranslationById(id);
            if(filestranslation1 == null)
            {
                return NotFound();
            }
            var filestranslation = _mapper.Map<FilesTranslationReadedDTO>(filestranslation1);

            return Ok(filestranslation);
        }


        [HttpDelete("deletefilestranslation/{id}")]
        public IActionResult DeletefilesTranslation(int id)
        {
            bool check = _repository.DeleteFilesTranslation(id);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }



        [HttpPut("updatefilestranslation/{id}")]
        public IActionResult UpdatefilesTranslation(FilesTranslationUpdatedDTO filestranslation1, int id)
        {
            var filestranslation = _repository.GetFilesTranslationById(id);
            if(filestranslation == null)
            {
                return NotFound();
            }
            _mapper.Map(filestranslation1,filestranslation);
            bool check = _repository.UpdateFilesTranslation();
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }
    }
}
