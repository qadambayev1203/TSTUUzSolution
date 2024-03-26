using Entities.Model.MenuModel;


namespace Contracts.AllRepository.MenuesRepository
{
    public interface IMenuRepository
    {
        //Menu CRUD
        public IEnumerable<Menu> AllMenu(int queryNum, int pageNum);
        public Menu GetMenuById(int id);
        public int CreateMenu(Menu Menu);
        public bool UpdateMenu();
        public bool DeleteMenu(int id);



        //MenuTranslation CRUD
        public IEnumerable<MenuTranslation> AllMenuTranslation(int queryNum, int pageNum, string language_code);
        public MenuTranslation GetMenuTranslationById(int id);
        public int CreateMenuTranslation(MenuTranslation MenuTranslation);
        public bool UpdateMenuTranslation();
        public bool DeleteMenuTranslation(int id);

        public bool SaveChanges();
    }
}
