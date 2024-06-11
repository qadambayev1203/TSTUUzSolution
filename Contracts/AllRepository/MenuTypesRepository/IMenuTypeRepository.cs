
using Entities.Model.MenuTypesModel;

namespace Contracts.AllRepository.MenuTypesRepository
{
    public interface IMenuTypeRepository
    {
        //MenuType CRUD
        public IEnumerable<MenuType> AllMenuType(int queryNum, int pageNum);
        public IEnumerable<MenuType> AllMenuTypeSite(int queryNum, int pageNum);
        public MenuType GetMenuTypeById(int id);
        public MenuType GetMenuTypeByIdSite(int id);
        public int CreateMenuType(MenuType MenuType);
        public bool UpdateMenuType(int id, MenuType menuType);
        public bool DeleteMenuType(int id);



        //MenuTypeTranslation CRUD
        public IEnumerable<MenuTypeTranslation> AllMenuTypeTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<MenuTypeTranslation> AllMenuTypeTranslationSite(int queryNum, int pageNum, string language_code);
        public MenuTypeTranslation GetMenuTypeTranslationById(int id);
        public MenuTypeTranslation GetMenuTypeTranslationById(int uz_id, string language_code);
        public MenuTypeTranslation GetMenuTypeTranslationByIdSite(int uz_id, string language_code);
        public MenuTypeTranslation GetMenuTypeTranslationByIdSite(int id);
        public int CreateMenuTypeTranslation(MenuTypeTranslation MenuTypeTranslation);
        public bool UpdateMenuTypeTranslation(int id, MenuTypeTranslation menuType);
        public bool DeleteMenuTypeTranslation(int id);

        public bool SaveChanges();
    }
}
