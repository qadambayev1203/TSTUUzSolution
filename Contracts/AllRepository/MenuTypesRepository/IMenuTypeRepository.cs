
using Entities.Model.MenuTypesModel;

namespace Contracts.AllRepository.MenuTypesRepository
{
    public interface IMenuTypeRepository
    {
        //MenuType CRUD
        public IEnumerable<MenuType> AllMenuType(int queryNum, int pageNum);
        public MenuType GetMenuTypeById(int id);
        public int CreateMenuType(MenuType MenuType);
        public bool UpdateMenuType();
        public bool DeleteMenuType(int id);



        //MenuTypeTranslation CRUD
        public IEnumerable<MenuTypeTranslation> AllMenuTypeTranslation(int queryNum, int pageNum, string language_code);
        public MenuTypeTranslation GetMenuTypeTranslationById(int id);
        public int CreateMenuTypeTranslation(MenuTypeTranslation MenuTypeTranslation);
        public bool UpdateMenuTypeTranslation();
        public bool DeleteMenuTypeTranslation(int id);

        public bool SaveChanges();
    }
}
