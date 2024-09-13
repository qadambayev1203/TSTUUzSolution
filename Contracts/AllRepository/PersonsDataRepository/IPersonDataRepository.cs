using Entities.Model;
using Entities.Model.PersonDataModel;

namespace Contracts.AllRepository.PersonsDataRepository;

public interface IPersonDataRepository
{
    //PersonData CRUD
    public IEnumerable<PersonData> AllPersonData(int queryNum, int pageNum);
    public IEnumerable<PersonData> AllPersonDataDepId(int department_id);
    public IEnumerable<PersonData> AllPersonDataSite(int queryNum, int pageNum);
    public IEnumerable<PersonData> AllPersonDataEmployeeType(int queryNum, int pageNum, string employee_type);
    public IEnumerable<PersonData> AllPersonDataEmployeeTypeSite(int queryNum, int pageNum, string employee_type);
    public PersonData GetPersonDataById(int id, bool profile);
    public PersonData GetPersonDataByIdSite(int id);
    public PersonData GetPersonDataByPersonId(int person_id);
    public PersonData GetPersonDataByPersonIdSite(int person_id);
    public int CreatePersonData(PersonData personData, User user);
    public bool UpdatePersonData(int id, PersonData personData, User user, bool profile);
    public bool DeletePersonData(int id);

    public User GetPersonUserById(int? person_id);




    //PersonDataTranslation CRUD
    public IEnumerable<PersonDataTranslation> AllPersonDataTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<PersonDataTranslation> AllPersonDataTranslationDepId(int department_uz_id, string language_code);
    public IEnumerable<PersonDataTranslation> AllPersonDataTranslationSite(int queryNum, int pageNum, string language_code);
    public IEnumerable<PersonDataTranslation> AllPersonDataTranslationEmployeeType(int queryNum, int pageNum, string language_code, string employee_type);
    public IEnumerable<PersonDataTranslation> AllPersonDataTranslationEmployeeTypeSite(int queryNum, int pageNum, string language_code, string employee_type);
    public PersonDataTranslation GetPersonDataTranslationById(int id, bool profile, string language_code);
    public PersonDataTranslation GetPersonDataTranslationByIdSite(int id);
    public PersonDataTranslation GetPersonDataTranslationByPersonId(int person_id, string language_code);
    public PersonDataTranslation GetPersonDataTranslationByPersonIdSite(int person_id, string language_code);
    public PersonDataTranslation GetPersonDataTranslationById(int uz_id, string language_code);
    public PersonDataTranslation GetPersonDataTranslationByIdSite(int uz_id, string language_code);
    public int CreatePersonDataTranslation(PersonDataTranslation personDataTranslation);
    public bool UpdatePersonDataTranslation(int id, PersonDataTranslation personData, bool profile, string language_code);
    public bool DeletePersonDataTranslation(int id);
    public bool SaveChanges();
}
