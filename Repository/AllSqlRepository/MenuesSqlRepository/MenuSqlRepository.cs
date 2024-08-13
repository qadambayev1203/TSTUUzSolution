using Contracts.AllRepository.MenuesRepository;
using Entities;
using Entities.Model.MenuModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace Repository.AllSqlRepository.MenuesSqlRepository;

public class MenuSqlRepository : IMenuRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<MenuSqlRepository> _logger;
    public MenuSqlRepository(RepositoryContext repositoryContext, ILogger<MenuSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    #region Menu CRUD
    public IEnumerable<Menu> AllMenu(int queryNum, int pageNum, bool? top_menu)
    {
        try
        {
            var menues = new List<Menu>();
            if (queryNum == 0 && pageNum != 0)
            {
                if (top_menu == null)
                {
                    menues = _context.menu_20ts24tu
                    .Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Include(x => x.user_)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();
                }
                else
                {
                    menues = _context.menu_20ts24tu
                    .Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Include(x => x.user_)
                    .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();
                }

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                if (top_menu == null)
                {
                    menues = _context.menu_20ts24tu
                    .Include(x => x.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.status_)
                   .Include(x => x.user_)
                   .Include(x => x.page_)
                   .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                   .Include(x => x.blog_)
                   .Include(x => x.user_)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                   .ToList();
                }
                else
                {
                    menues = _context.menu_20ts24tu
                    .Include(x => x.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.status_)
                   .Include(x => x.user_)
                   .Include(x => x.page_)
                   .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                   .Include(x => x.blog_)
                   .Include(x => x.user_)
                   .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                   .ToList();
                }

            }
            else
            {
                if (top_menu == null)
                {
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Include(x => x.user_)
                    .ToList();
                }
                else
                {
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Include(x => x.user_)
                    .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                    .ToList();
                }

            }
            return menues;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Menu> AllMenuSite(int queryNum, int pageNum, bool? top_menu)
    {
        try
        {
            var menues = new List<Menu>();
            if (queryNum == 0 && pageNum != 0)
            {
                if (top_menu == null)
                {
                    menues = _context.menu_20ts24tu
                     .Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_).Where(x => x.status_.status != "Deleted")
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();
                }
                else
                {
                    menues = _context.menu_20ts24tu
                     .Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_).Where(x => x.status_.status != "Deleted")
                    .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();
                }


            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                if (top_menu == null)
                {
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Where(x => x.status_.status != "Deleted")
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();
                }
                else
                {
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                    .Where(x => x.status_.status != "Deleted")
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();
                }


            }
            else
            {
                if (top_menu == null)
                {
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Where(x => x.status_.status != "Deleted")

                    .ToList();
                }
                else
                {
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                    .Where(x => x.status_.status != "Deleted")

                    .ToList();
                }


            }
            return menues;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateMenu(Menu Menu)
    {
        try
        {
            if (Menu == null)
            {
                return 0;
            }
            _context.menu_20ts24tu.Add(Menu);
            bool check = SaveChanges();
            if (!check)
            {
                return 0;
            }
            int id = Menu.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(Menu));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteMenu(int id)
    {
        try
        {
            var emp = GetMenuById(id);
            if (emp == null)
            {
                return false;
            }
            emp.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.menu_20ts24tu.Update(emp);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Menu GetMenuById(int id)
    {
        try
        {
            var Menu = _context.menu_20ts24tu
                .Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_)
                    .Include(x => x.user_)
                    .FirstOrDefault(x => x.id.Equals(id));

            return Menu;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public Menu GetMenuByIdSite(int id)
    {
        try
        {
            var Menu = _context.menu_20ts24tu
                 .Include(x => x.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.status_)
                    .Include(x => x.user_)
                    .Include(x => x.page_)
                    .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                    .Include(x => x.blog_).Where(x => x.status_.status != "Deleted")
                    .FirstOrDefault(x => x.id.Equals(id));

            return Menu;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateMenu(int id, Menu menu)
    {

        try
        {
            var dbcheck = GetMenuById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.parent_id = menu.parent_id;
            dbcheck.position = menu.position;
            dbcheck.high_menu = menu.high_menu;
            dbcheck.menu_type_id = menu.menu_type_id;
            dbcheck.title = menu.title;
            dbcheck.description = menu.description;
            dbcheck.link_ = menu.link_;
            dbcheck.top_menu = menu.top_menu;
            dbcheck.status_id = menu.status_id;
            dbcheck.blog_id = menu.blog_id;
            dbcheck.departament_id = menu.departament_id;
            dbcheck.page_id = menu.page_id;
            if (menu.icon_ != null)
            {
                dbcheck.icon_ = menu.icon_;
            }

            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }


    #endregion




    #region MenuTranslation CRUD
    public IEnumerable<MenuTranslation> AllMenuTranslation(int queryNum, int pageNum, string language_code, bool? top_menu)
    {
        try
        {
            var menues = new List<MenuTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                if (top_menu == null)
                {
                    menues = _context.menu_translations_20ts24tu
                     .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Include(x => x.user_)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Skip(10 * (pageNum - 1))
                   .Take(10)
                   .ToList();
                }
                else
                {
                    menues = _context.menu_translations_20ts24tu
                     .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Include(x => x.user_)
                   .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Skip(10 * (pageNum - 1))
                   .Take(10)
                   .ToList();
                }


            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                if (top_menu == null)
                {
                    menues = _context.menu_translations_20ts24tu
                      .Include(x => x.menu_)
                    .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.blog_translation_)
                    .Include(x => x.page_translation_)
                    .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.status_)
                    .Include(x => x.language_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Include(x => x.user_)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();
                }
                else
                {
                    menues = _context.menu_translations_20ts24tu
                      .Include(x => x.menu_)
                    .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.blog_translation_)
                    .Include(x => x.page_translation_)
                    .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.status_)
                    .Include(x => x.language_)
                    .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Include(x => x.user_)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();
                }


            }
            else
            {
                if (top_menu == null)
                {
                    menues = _context.menu_translations_20ts24tu
                    .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Include(x => x.user_)
                   .ToList();
                }
                else
                {
                    menues = _context.menu_translations_20ts24tu
                    .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Include(x => x.user_)
                   .ToList();
                }


            }
            return menues;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<MenuTranslation> AllMenuTranslationSite(int queryNum, int pageNum, string language_code, bool? top_menu)
    {
        try
        {
            var menues = new List<MenuTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                if (top_menu == null)
                {
                    menues = _context.menu_translations_20ts24tu
                  .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where(x => x.status_.status != "Deleted")
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Skip(10 * (pageNum - 1))
                   .Take(10)
                   .ToList();
                }
                else
                {
                    menues = _context.menu_translations_20ts24tu
                  .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                   .Where(x => x.status_.status != "Deleted")
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Skip(10 * (pageNum - 1))
                   .Take(10)
                   .ToList();
                }


            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                if (top_menu == null)
                {
                    menues = _context.menu_translations_20ts24tu
                    .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Where(x => x.status_.status != "Deleted")
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                   .ToList();
                }
                else
                {
                    menues = _context.menu_translations_20ts24tu
                    .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Where(x => x.status_.status != "Deleted")
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                   .ToList();
                }


            }
            else
            {
                if (top_menu == null)
                {
                    menues = _context.menu_translations_20ts24tu
                     .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Where(x => x.status_.status != "Deleted")
                   .ToList();

                }
                else
                {
                    menues = _context.menu_translations_20ts24tu
                     .Include(x => x.menu_)
                   .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                   .Include(x => x.icon_)
                   .Include(x => x.blog_translation_)
                   .Include(x => x.page_translation_)
                   .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                   .Include(x => x.status_)
                   .Include(x => x.language_)
                   .Where((top_menu == true) ? x => x.top_menu.Equals(true) : x => x.top_menu != true)
                   .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                   .Where(x => x.status_.status != "Deleted")
                   .ToList();

                }

            }
            return menues;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateMenuTranslation(MenuTranslation MenuTranslation)
    {
        try
        {
            if (MenuTranslation == null)
            {
                return 0;
            }
            _context.menu_translations_20ts24tu.Add(MenuTranslation);
            bool check = SaveChanges();
            if (!check)
            {
                return 0;
            }
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(MenuTranslation));

            var id = MenuTranslation.id;
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteMenuTranslation(int id)
    {
        try
        {
            var emp = GetMenuTranslationById(id);
            if (emp == null)
            {
                return false;
            }
            emp.status_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == emp.language_id)).id;
            _context.menu_translations_20ts24tu.Update(emp);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public MenuTranslation GetMenuTranslationById(int id)
    {
        try
        {
            var MenuTranslation = _context.menu_translations_20ts24tu
                 .Include(x => x.menu_)
                    .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.blog_translation_)
                    .Include(x => x.page_translation_)
                    .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.status_)
                    .Include(x => x.language_)
                .Include(x => x.user_)
                    .FirstOrDefault(x => x.id.Equals(id));
            return MenuTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public MenuTranslation GetMenuTranslationById(int uz_id, string language_code)
    {
        try
        {
            var MenuTranslation = _context.menu_translations_20ts24tu
                 .Include(x => x.menu_)
                    .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.blog_translation_)
                    .Include(x => x.page_translation_)
                    .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.status_)
                    .Include(x => x.language_)
                .Include(x => x.user_)
                .FirstOrDefault(x => x.menu_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return MenuTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public MenuTranslation GetMenuTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var MenuTranslation = _context.menu_translations_20ts24tu
                 .Include(x => x.menu_)
                    .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.blog_translation_)
                    .Include(x => x.page_translation_)
                    .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.status_)
                    .Include(x => x.language_)
                .Include(x => x.user_)
                    .Where(x => x.status_.status != "Deleted")
                .FirstOrDefault(x => x.menu_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return MenuTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public MenuTranslation GetMenuTranslationByIdSite(int id)
    {
        try
        {
            var MenuTranslation = _context.menu_translations_20ts24tu
                .Include(x => x.menu_)
                    .Include(x => x.menu_type_translation_).ThenInclude(y => y.menu_type_)
                    .Include(x => x.icon_)
                    .Include(x => x.blog_translation_)
                    .Include(x => x.page_translation_)
                    .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                    .Include(x => x.status_)
                    .Include(x => x.language_)
                .Where(x => x.status_.status != "Deleted")
                    .FirstOrDefault(x => x.id.Equals(id));
            return MenuTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateMenuTranslation(int id, MenuTranslation menu)
    {

        try
        {
            var dbcheck = GetMenuTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }

            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.menu_id = menu.menu_id;
            dbcheck.parent_id = menu.parent_id;
            dbcheck.position = menu.position;
            dbcheck.high_menu = menu.high_menu;
            dbcheck.menu_type_translation_id = menu.menu_type_translation_id;
            dbcheck.title = menu.title;
            dbcheck.description = menu.description;
            dbcheck.link_ = menu.link_;
            dbcheck.status_id = menu.status_id;
            dbcheck.language_id = menu.language_id;
            dbcheck.top_menu = menu.top_menu;
            dbcheck.blog_translation_id = menu.blog_translation_id;
            dbcheck.page_translation_id = menu.page_translation_id;
            dbcheck.departament_translation_id = menu.departament_translation_id;
            if (menu.icon_ != null)
            {
                dbcheck.icon_ = menu.icon_;
            }

            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }
    #endregion


    public bool SaveChanges()
    {
        try
        {
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }


}
