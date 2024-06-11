using Entities.Model.MenuTypesModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.MenuTypesRepository;
using Serilog;
using Entities.Model.MenuModel;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;


namespace Repository.AllSqlRepository.MenuTypesSqlRepository
{
    public class MenuTypeSqlRepository : IMenuTypeRepository
    {

        private readonly RepositoryContext _context;
        private readonly ILogger<MenuTypeSqlRepository> _logger;
        public MenuTypeSqlRepository(RepositoryContext repositoryContext, ILogger<MenuTypeSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        #region MenuType CRUD
        public IEnumerable<MenuType> AllMenuType(int queryNum, int pageNum)
        {
            try
            {
                var MenuTypes = new List<MenuType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    MenuTypes = _context.menu_types_20ts24tu
                        .Include(x => x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    MenuTypes = _context.menu_types_20ts24tu
                        .Include(x => x.status_)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    MenuTypes = _context.menu_types_20ts24tu.Include(x => x.status_)
                       .ToList();
                }
                return MenuTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public IEnumerable<MenuType> AllMenuTypeSite(int queryNum, int pageNum)
        {
            try
            {
                var MenuTypes = new List<MenuType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    MenuTypes = _context.menu_types_20ts24tu
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    MenuTypes = _context.menu_types_20ts24tu
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    MenuTypes = _context.menu_types_20ts24tu.Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                       .ToList();
                }
                return MenuTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public int CreateMenuType(MenuType MenuType)
        {
            try
            {
                if (MenuType == null)
                {
                    return 0;
                }
                _context.menu_types_20ts24tu.Add(MenuType);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                int id = MenuType.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(MenuType));

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeleteMenuType(int id)
        {
            try
            {
                var emp = GetMenuTypeById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.menu_types_20ts24tu.Update(emp);

                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public MenuType GetMenuTypeById(int id)
        {
            try
            {
                var MenuType = _context.menu_types_20ts24tu
                        .Include(x => x.status_)
                        .FirstOrDefault(x => x.id.Equals(id));

                return MenuType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public MenuType GetMenuTypeByIdSite(int id)
        {
            try
            {
                var MenuType = _context.menu_types_20ts24tu
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                        .FirstOrDefault(x => x.id.Equals(id));

                return MenuType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdateMenuType(int id, MenuType menuType)
        {

            try
            {
                var dbcheck = GetMenuTypeById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.title = menuType.title;
                dbcheck.status_id = menuType.status_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }

        }


        #endregion




        #region MenuTypeTranslation CRUD
        public IEnumerable<MenuTypeTranslation> AllMenuTypeTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var MenuTypeTranslations = new List<MenuTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    MenuTypeTranslations = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    MenuTypeTranslations = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    MenuTypeTranslations = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return MenuTypeTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public IEnumerable<MenuTypeTranslation> AllMenuTypeTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var MenuTypeTranslations = new List<MenuTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    MenuTypeTranslations = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    MenuTypeTranslations = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    MenuTypeTranslations = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return MenuTypeTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public int CreateMenuTypeTranslation(MenuTypeTranslation MenuTypeTranslation)
        {
            try
            {
                if (MenuTypeTranslation == null)
                {
                    return 0;
                }
                _context.menu_types_translations_20ts24tu.Add(MenuTypeTranslation);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(MenuTypeTranslation));
                var id = MenuTypeTranslation.id;
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeleteMenuTypeTranslation(int id)
        {
            try
            {
                var emp = GetMenuTypeTranslationById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == emp.language_id)).id;
                _context.menu_types_translations_20ts24tu.Update(emp);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public MenuTypeTranslation GetMenuTypeTranslationById(int id)
        {
            try
            {
                var MenuTypeTranslation = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return MenuTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public MenuTypeTranslation GetMenuTypeTranslationById(int uz_id, string language_code)
        {
            try
            {
                var MenuTypeTranslation = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.menu_type_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return MenuTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public MenuTypeTranslation GetMenuTypeTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var MenuTypeTranslation = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.menu_type_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return MenuTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public MenuTypeTranslation GetMenuTypeTranslationByIdSite(int id)
        {
            try
            {
                var MenuTypeTranslation = _context.menu_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.menu_type_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));
                return MenuTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdateMenuTypeTranslation(int id, MenuTypeTranslation menuType)
        {

            try
            {
                var dbcheck = GetMenuTypeTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.title = menuType.title;
                dbcheck.menu_type_id = menuType.menu_type_id;
                dbcheck.language_id = menuType.language_id;
                dbcheck.status_translation_id = menuType.status_translation_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
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
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }


    }
}
