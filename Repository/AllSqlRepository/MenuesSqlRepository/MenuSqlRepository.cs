using Contracts.AllRepository.MenuesRepository;
using Entities;
using Entities.Model.MenuModel;
using Microsoft.EntityFrameworkCore;


namespace Repository.AllSqlRepository.MenuesSqlRepository
{
    public class MenuSqlRepository : IMenuRepository
    {
        private readonly RepositoryContext _context;
        public MenuSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        #region Menu CRUD
        public IEnumerable<Menu> AllMenu(int queryNum, int pageNum)
        {
            try
            {
                var menues = new List<Menu>();
                if (queryNum == 0 && pageNum != 0)
                {
                    menues = _context.menu_20ts24tu
                        .Include(x=>x.menu_type_)
                        .Include(x=>x.icon_)
                        .Include(x=>x.status_)
                        .Include(x=>x.user_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                        .Include(x => x.icon_)
                        .Include(x => x.status_)
                        .Include(x => x.user_)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    menues = _context.menu_20ts24tu.Include(x => x.menu_type_)
                        .Include(x => x.icon_)
                        .Include(x => x.status_)
                        .Include(x => x.user_)

                        .ToList();

                }
                return menues;
            }
            catch
            {
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

                return id;
            }
            catch
            {
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

                return true;
            }
            catch
            {
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
                        .FirstOrDefault(x => x.id.Equals(id));

                return Menu;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateMenu()
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




        #region MenuTranslation CRUD
        public IEnumerable<MenuTranslation> AllMenuTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var menues = new List<MenuTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    menues = _context.menu_translations_20ts24tu
                        .Include(x => x.menu_)
                        .Include(x => x.menu_type_translation_)
                        .Include(x => x.icon_)
                        .Include(x => x.status_)
                        .Include(x => x.language_)
                        .Include(x => x.user_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    menues = _context.menu_translations_20ts24tu
                        .Include(x => x.menu_)
                        .Include(x => x.menu_type_translation_)
                        .Include(x => x.icon_)
                        .Include(x => x.status_)
                        .Include(x => x.language_)
                        .Include(x => x.user_)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    menues = _context.menu_translations_20ts24tu
                        .Include(x => x.menu_)
                        .Include(x => x.menu_type_translation_)
                        .Include(x => x.icon_)
                        .Include(x => x.status_)
                        .Include(x => x.language_)
                        .Include(x => x.user_)
                        .ToList();

                }
                return menues;
            }
            catch
            {
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
                var id = MenuTranslation.id;
                return id;
            }
            catch
            {
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
                emp.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.menu_translations_20ts24tu.Update(emp);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public MenuTranslation GetMenuTranslationById(int id)
        {
            try
            {
                var MenuTranslation = _context.menu_translations_20ts24tu
                    .Include(x=>x.menu_)
                    .Include(x=>x.menu_type_translation_)
                    .Include(x=>x.icon_)
                    .Include(x=>x.status_)
                    .Include(x=>x.language_)
                        .FirstOrDefault(x => x.id.Equals(id));
                return MenuTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateMenuTranslation()
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
