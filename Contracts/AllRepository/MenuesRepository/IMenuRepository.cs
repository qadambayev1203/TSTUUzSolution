using Entities.Model.MenuModel;


namespace Contracts.AllRepository.MenuesRepository;

public interface IMenuRepository
{
    //Menu CRUD
    public IEnumerable<Menu> AllMenu(int queryNum, int pageNum, bool? top_menu);
    public IEnumerable<Menu> AllMenuSite(int queryNum, int pageNum, bool? top_menu);
    public Menu GetMenuById(int id);
    public Menu GetMenuByIdSite(int id);
    public int CreateMenu(Menu Menu);
    public bool UpdateMenu(int id, Menu menu);
    public bool DeleteMenu(int id);



    //MenuTranslation CRUD
    public IEnumerable<MenuTranslation> AllMenuTranslation(int queryNum, int pageNum, string language_code, bool? top_menu);
    public IEnumerable<MenuTranslation> AllMenuTranslationSite(int queryNum, int pageNum, string language_code, bool? top_menu);
    public MenuTranslation GetMenuTranslationById(int id);
    public MenuTranslation GetMenuTranslationById(int uz_id, string language_code);
    public MenuTranslation GetMenuTranslationByIdSite(int uz_id, string language_code);
    public MenuTranslation GetMenuTranslationByIdSite(int id);
    public int CreateMenuTranslation(MenuTranslation MenuTranslation);
    public bool UpdateMenuTranslation(int id, MenuTranslation menu);
    public bool DeleteMenuTranslation(int id);

    public bool SaveChanges();
}
