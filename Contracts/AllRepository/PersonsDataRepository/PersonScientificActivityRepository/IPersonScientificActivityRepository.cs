using Entities.Model.PersonDataModel.PersonPortfolioModel;
using Entities.Model.PersonDataModel;
using Entities.Model.PersonDataModel.PersonScientificActivityModel;

namespace Contracts.AllRepository.PersonsDataRepository.PersonScientificActivityRepository;

public interface IPersonScientificActivityRepository
{
    // PersonScientificActivity CRUD
    public int CreatePersonScientificActivity(PersonScientificActivity personScientificActivity);
    public IEnumerable<PersonScientificActivity> AllPersonScientificActivity(int queryNum, int pageNum, int person_data_id, bool isAdmin);
    public IEnumerable<PersonScientificActivity> AllPersonScientificActivitySite(int queryNum, int pageNum, int person_data_id);
    public PersonScientificActivity GetByIdPersonScientificActivity(int id, bool isAdmin);
    public PersonScientificActivity GetByIdPersonScientificActivitySite(int id);
    public bool DeletePersonScientificActivity(int id);
    public bool UpdatePersonScientificActivity(int id, PersonScientificActivity personScientificActivity, bool isAdmin);

    // PersonScientificActivityTranslation CRUD
    public int CreatePersonScientificActivityTranslation(PersonScientificActivityTranslation personScientificActivity);
    public IEnumerable<PersonScientificActivityTranslation> AllPersonScientificActivityTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code);
    public IEnumerable<PersonScientificActivityTranslation> AllPersonScientificActivityTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code);
    public PersonScientificActivityTranslation GetByIdPersonScientificActivityTranslation(int id, bool isAdmin);
    public PersonScientificActivityTranslation GetByIdPersonScientificActivityTranslationSite(int id);
    public PersonScientificActivityTranslation GetByIdPersonScientificActivityTranslation(int uz_id, string language_code, bool isAdmin);
    public PersonScientificActivityTranslation GetByIdPersonScientificActivityTranslationSite(int uz_id, string language_code);
    public bool DeletePersonScientificActivityTranslation(int id);
    public bool UpdatePersonScientificActivityTranslation(int id, PersonScientificActivityTranslation personScientificActivity, bool isAdmin);



    //Confirm
    public IEnumerable<PersonData> AllPersonScientificActivityCreated();
    public IEnumerable<PersonScientificActivity> AllPersonScientificActivityDep(int queryNum, int pageNum, int person_data_id);
    public bool ConfirmDocumentTeacher110Set(int id, bool confirm);
}
