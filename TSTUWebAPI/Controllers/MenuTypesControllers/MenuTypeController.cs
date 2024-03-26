using AutoMapper;
using Contracts.AllRepository.MenuTypesRepository;
using Entities.DTO.MenuTypesDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.MenuTypesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.MenuTypesControllers
{
    [Route("api/menutype")]
    [ApiController]
    public class MenuTypeController : ControllerBase
    {
        private readonly IMenuTypeRepository _repository;
        private readonly IMapper _mapper;
        public MenuTypeController(IMenuTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // MenuType CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createmenutype")]
        public IActionResult CreateMenuType(MenuTypeCreatedDTO MenuType1)
        {
            var MenuType = _mapper.Map<MenuType>(MenuType1);
            MenuType.status_id = 1;
            int check = _repository.CreateMenuType(MenuType);

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

        [HttpGet("getallmenutype")]
        public IActionResult GetAllMenuType(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<MenuType> MenuTypees1 = _repository.AllMenuType(queryNum, pageNum);
            var MenuTypees = _mapper.Map<IEnumerable<MenuTypeReadedDTO>>(MenuTypees1);
            if (MenuTypees == null || MenuTypees.Count() == 0) { return NotFound(); }
            return Ok(MenuTypees);
        }

        [HttpGet("getbyidmenutype/{id}")]
        public IActionResult GetByIdMenuType(int id)
        {

            MenuType MenuType1 = _repository.GetMenuTypeById(id);
            if (MenuType1 == null)
            {
                return NotFound();
            }
            var MenuType = _mapper.Map<MenuTypeReadedDTO>(MenuType1);
            if (MenuType == null) { return NotFound(); }
            return Ok(MenuType);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deletemenutype/{id}")]
        public IActionResult DeleteMenuType(int id)
        {
            bool check = _repository.DeleteMenuType(id);
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
        [HttpPut("updatemenutype/{id}")]
        public IActionResult UpdateMenuType(MenuTypeUpdatedDTO MenuType1, int id)
        {

            try
            {
                MenuType MenuType = _repository.GetMenuTypeById(id);
                if (MenuType == null || MenuType1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(MenuType1, MenuType);
                var a = _repository.SaveChanges();
                if (a)
                {
                    return BadRequest(a);
                }
                return Ok("Updated");
            }
            catch
            {
                return BadRequest();
            }

        }







        //MenuTypeTranslation CRUD
        [Authorize(Roles = "Admin")]
        [HttpPost("createmenutypetranslation")]
        public IActionResult CreateMenuTypeTranslation(MenuTypeTranslationCreatedDTO MenuTypetranslation1)
        {
            var MenuTypetranslation = _mapper.Map<MenuTypeTranslation>(MenuTypetranslation1);
            MenuTypetranslation.status_translation_id = 1;
            int check = _repository.CreateMenuTypeTranslation(MenuTypetranslation);

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

        [HttpGet("getallmenutypetranslation")]
        public IActionResult GetAllMenuTypeTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<MenuTypeTranslation> MenuTypetranslationes1 = _repository.AllMenuTypeTranslation(queryNum, pageNum, language_code);
            var MenuTypetranslationes = _mapper.Map<IEnumerable<MenuTypeTranslationReadedDTO>>(MenuTypetranslationes1);
            if (MenuTypetranslationes == null || MenuTypetranslationes.Count() == 0) { return NotFound(); }
            return Ok(MenuTypetranslationes);
        }

        [HttpGet("getbyidmenutypetranslation/{id}")]
        public IActionResult GetByIdMenuTypeTranslation(int id)
        {

            MenuTypeTranslation MenuTypetranslation1 = _repository.GetMenuTypeTranslationById(id);
            if (MenuTypetranslation1 == null)
            {
                return NotFound();
            }
            var MenuTypetranslation = _mapper.Map<MenuTypeTranslationReadedDTO>(MenuTypetranslation1);
            if (MenuTypetranslation == null) { return NotFound(); }
            return Ok(MenuTypetranslation);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deletemenutypetranslation/{id}")]
        public IActionResult DeleteMenuTypeTranslation(int id)
        {
            bool check = _repository.DeleteMenuTypeTranslation(id);
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
        [HttpPut("updatemenutypetranslation/{id}")]
        public IActionResult UpdateMenuTypeTranslation(MenuTypeTranslationUpdatedDTO MenuTypetranslation1, int id)
        {
            try
            {
                var MenuType = _repository.GetMenuTypeTranslationById(id);
                if (MenuType == null || MenuTypetranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(MenuTypetranslation1, MenuType);
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
