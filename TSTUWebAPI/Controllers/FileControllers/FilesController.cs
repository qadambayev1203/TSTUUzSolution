using AutoMapper;
using Contracts.AllRepository.FilesRepository;
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
        public IActionResult Createfiles(Files files)
        {

            bool check = _repository.CreateFiles(files);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", files);
        }

        [HttpGet("getallfiles")]
        public IActionResult GetAllfiles()
        {

            IEnumerable<Files> fileses = _repository.AllFile();

            return Ok(fileses);
        }

        [HttpGet("getbyidfiles/{id}")]
        public IActionResult GetByIdfiles(int id)
        {

            Files files = _repository.GetFilesById(id);

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
        public IActionResult Updatefiles(Files files, int id)
        {
            bool check = _repository.UpdateFiles(id, files);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }







        //filesTranslation CRUD
        [HttpPost("createfilestranslation")]
        public IActionResult CreatefilesTranslation(FilesTranslation filestranslation)
        {

            bool check = _repository.CreateFilesTranslation(filestranslation);

            if (!check)
            {
                return BadRequest();
            }

            return Created("", filestranslation);
        }

        [HttpGet("getallfilestranslation")]
        public IActionResult GetAllfilesTranslation()
        {

            IEnumerable<FilesTranslation> filestranslationes = _repository.AllFilesTranslation();

            return Ok(filestranslationes);
        }

        [HttpGet("getbyidfilestranslation/{id}")]
        public IActionResult GetByIdfilesTranslation(int id)
        {

            FilesTranslation filestranslation = _repository.GetFilesTranslationById(id);

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
        public IActionResult UpdatefilesTranslation(FilesTranslation filestranslation, int id)
        {
            bool check = _repository.UpdateFilesTranslation(id, filestranslation);
            if (!check)
            {
                return BadRequest();
            }
            return Ok("Updated");

        }
    }
}
