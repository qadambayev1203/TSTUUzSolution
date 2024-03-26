using AutoMapper;
using Contracts.AllRepository.MenuesRepository;
using Entities.DTO.MenuDTOS;
using Entities.Model.AnyClasses;
using Entities.Model.MenuModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TSTUWebAPI.Controllers.MenuControllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _repository;
        private readonly IMapper _mapper;
        public MenuController(IMenuRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // Menu CRUD

        [Authorize(Roles = "Admin")]
        [HttpPost("createmenu")]
        public IActionResult CreateMenu(MenuCreatedDTO Menu1)
        {
            var Menu = _mapper.Map<Menu>(Menu1);
            Menu.status_id = 1;
            Menu.user_id = UserCreatedId.id;
            int check = _repository.CreateMenu(Menu);

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

        [HttpGet("getallmenu")]
        public IActionResult GetAllMenu(int queryNum, int pageNum)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<Menu> Menues1 = _repository.AllMenu(queryNum, pageNum);
            var Menues = _mapper.Map<IEnumerable<MenuReadedDTO>>(Menues1);
            if (Menues == null || Menues.Count() == 0) { return NotFound(); }
            return Ok(Menues);
        }

        [HttpGet("getbyidmenu/{id}")]
        public IActionResult GetByIdMenu(int id)
        {

            Menu Menu1 = _repository.GetMenuById(id);
            if (Menu1 == null)
            {
                return NotFound();
            }
            var Menu = _mapper.Map<MenuReadedDTO>(Menu1);
            if (Menu == null) { return NotFound(); }
            return Ok(Menu);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deletemenu/{id}")]
        public IActionResult DeleteMenu(int id)
        {
            bool check = _repository.DeleteMenu(id);
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
        [HttpPut("updatemenu/{id}")]
        public IActionResult UpdateMenu(MenuUpdatedDTO Menu1, int id)
        {

            try
            {
                Menu Menu = _repository.GetMenuById(id);
                if (Menu == null || Menu1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Menu1, Menu);
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







        //MenuTranslation CRUD
        [Authorize(Roles = "Admin")]
        [HttpPost("createmenutranslation")]
        public IActionResult CreateMenuTranslation(MenuTranslationCreatedDTO Menutranslation1)
        {
            var Menutranslation = _mapper.Map<MenuTranslation>(Menutranslation1);
            Menutranslation.status_id = 1;
            Menutranslation.user_id = UserCreatedId.id;
            int check = _repository.CreateMenuTranslation(Menutranslation);

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

        [HttpGet("getallmenutranslation")]
        public IActionResult GetAllMenuTranslation(int queryNum, int pageNum, string? language_code)
        {
            queryNum = Math.Abs(queryNum);
            pageNum = Math.Abs(pageNum);
            IEnumerable<MenuTranslation> Menutranslationes1 = _repository.AllMenuTranslation(queryNum, pageNum, language_code);
            var Menutranslationes = _mapper.Map<IEnumerable<MenuTranslationReadedDTO>>(Menutranslationes1);
            if (Menutranslationes == null || Menutranslationes.Count() == 0) { return NotFound(); }
            return Ok(Menutranslationes);
        }

        [HttpGet("getbyidmenutranslation/{id}")]
        public IActionResult GetByIdMenuTranslation(int id)
        {

            MenuTranslation Menutranslation1 = _repository.GetMenuTranslationById(id);
            if (Menutranslation1 == null)
            {
                return NotFound();
            }
            var Menutranslation = _mapper.Map<MenuTranslationReadedDTO>(Menutranslation1);
            if (Menutranslation == null) { return NotFound(); }
            return Ok(Menutranslation);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("deletemenutranslation/{id}")]
        public IActionResult DeleteMenuTranslation(int id)
        {
            bool check = _repository.DeleteMenuTranslation(id);
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
        [HttpPut("updatemenutranslation/{id}")]
        public IActionResult UpdateMenuTranslation(MenuTranslationUpdatedDTO Menutranslation1, int id)
        {
            try
            {
                var Menu = _repository.GetMenuTranslationById(id);
                if (Menu == null || Menutranslation1 == null)
                {
                    return NotFound();
                }
                _mapper.Map(Menutranslation1, Menu);
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
