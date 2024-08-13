using Entities.Model.LanguagesModel;

namespace Contracts.AllRepository.LanguagesRepository;

public interface ILanguageRepository
{
    //Language CRUD
    public IEnumerable<Language> AllLanguage(int queryNum, int pageNum);
    public IEnumerable<Language> AllLanguageSite(int queryNum, int pageNum);
    public Language GetLanguageById(int id);
    public Language GetLanguageByIdSite(int id);
    public int CreateLanguage(Language language);
    public bool UpdateLanguage(int id, Language language);
    public bool DeleteLanguage(int id);

    public bool SaveChanges();



}
