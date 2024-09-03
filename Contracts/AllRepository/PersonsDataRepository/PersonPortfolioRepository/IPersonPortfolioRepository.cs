using Entities.Model.PersonDataModel.PersonPortfolioModel;

namespace Contracts.AllRepository.PersonsDataRepository.PersonPortfolioRepository;

public interface IPersonPortfolioRepository
{
    // PersonPortfolio CRUD
    public int CreatePersonPortfolio(PersonPortfolio personPortfolio);
    public IEnumerable<PersonPortfolio> AllPersonPortfolio(int queryNum, int pageNum, int person_data_id, bool isAdmin);
    public PersonPortfolio GetByIdPersonPortfolio(int id, bool isAdmin);
    public bool DeletePersonPortfolio(int id);
    public bool UpdatePersonPortfolio(int id, PersonPortfolio personPortfolio, bool isAdmin);

    // PersonPortfolioTranslation CRUD
    public int CreatePersonPortfolioTranslation(PersonPortfolioTranslation personPortfolio);
    public IEnumerable<PersonPortfolioTranslation> AllPersonPortfolioTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code);
    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslation(int id, bool isAdmin);
    public PersonPortfolioTranslation GetByIdPersonPortfolioTranslation(int uz_id, string language_code, bool isAdmin);
    public bool DeletePersonPortfolioTranslation(int id);
    public bool UpdatePersonPortfolioTranslation(int id, PersonPortfolioTranslation personPortfolio, bool isAdmin);
}
