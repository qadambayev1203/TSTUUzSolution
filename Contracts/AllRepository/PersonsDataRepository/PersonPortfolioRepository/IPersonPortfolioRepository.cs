using Entities.Model.PersonDataModel;
using Entities.Model.PersonDataModel.PersonPortfolioModel;

namespace Contracts.AllRepository.PersonsDataRepository.PersonPortfolioRepository;

public interface IPersonPortfolioRepository
{
    // PersonPortfolio CRUD
    public int CreatePersonPortfolio(PersonPortfolio PersonPortfolio);
    public IEnumerable<PersonPortfolio> AllPersonPortfolio(int queryNum, int pageNum, int person_data_id, bool isAdmin);
    public IEnumerable<PersonPortfolio> AllPersonPortfolioSite(int queryNum, int pageNum, int person_data_id);
    public PersonPortfolio GetByIdPersonPortfolioSite(int id);
    public PersonPortfolio GetByIdPersonPortfolio(int id, bool isAdmin);
    public bool DeletePersonPortfolio(int id);
    public bool UpdatePersonPortfolio(int id, PersonPortfolio PersonPortfolio, bool isAdmin);

    // PersonPortfolioTranslation CRUD
    public int CreatePersonPortfolioTranslation(PersonPortfolioTranslation PersonPortfolio);
    public IEnumerable<PersonPortfolioTranslation> AllPersonPortfolioTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code);
    public IEnumerable<PersonPortfolioTranslation> AllPersonPortfolioTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code);
    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslation(int id, bool isAdmin);
    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslationSite(int id);
    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslation(int uz_id, string language_code, bool isAdmin);
    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslationSite(int uz_id, string language_code);
    public bool DeletePersonPortfolioTranslation(int id);
    public bool UpdatePersonPortfolioTranslation(int id, PersonPortfolioTranslation PersonPortfolio, bool isAdmin);


    //Confirm
    public IEnumerable<PersonData> AllPersonPortfolioCreated();
    public IEnumerable<PersonPortfolio> AllPersonPortfolioDep(int queryNum, int pageNum, int person_data_id);
    public bool ConfirmDocumentTeacher110Set(int id, bool confirm);

}
