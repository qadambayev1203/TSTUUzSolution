using Entities.Model.MenuTypesModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.MenuTypesRepository;


namespace Repository.AllSqlRepository.MenuTypesSqlRepository
{
    public class MenuTypeSqlRepository : IMenuTypeRepository
    {
        private readonly RepositoryContext _context;
        public MenuTypeSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
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
                        .Include(x=>x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    MenuTypes = _context.menu_types_20ts24tu
                        .Include(x=>x.status_)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    MenuTypes = _context.menu_types_20ts24tu.Include(x => x.status_)
                       .ToList();
                }
                return MenuTypes;
            }
            catch
            {
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

                return id;
            }
            catch
            {
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

                return true;
            }
            catch
            {
                return false;
            }
        }

        public MenuType GetMenuTypeById(int id)
        {
            try
            {
                var MenuType = _context.menu_types_20ts24tu
                        .Include(x=>x.status_)
                        .FirstOrDefault(x => x.id.Equals(id));

                return MenuType;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateMenuType()
        {

            try
            {
                return true;
            }
            catch
            {
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
            catch
            {
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
                var id = MenuTypeTranslation.id;
                return id;
            }
            catch
            {
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
                emp.status_translation_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.menu_types_translations_20ts24tu.Update(emp);

                return true;
            }
            catch
            {
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
            catch
            {
                return null;
            }
        }

        public bool UpdateMenuTypeTranslation()
        {

            try
            {
                return true;
            }
            catch
            {
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
            catch
            {
                return false;
            }
        }

       
    }
}
