using Entities.Model.PersonDataModel;
using Entities.Model.PersonDataModel.PersonExperienceModel;

namespace Contracts.AllRepository.PersonsDataRepository.PersonExperienceRepository;

public interface IPersonExperienceRepository
{
    // PersonExperience CRUD
    public int CreatePersonExperience(PersonExperience PersonExperience);
    public IEnumerable<PersonExperience> AllPersonExperience(int queryNum, int pageNum, int person_data_id, bool isAdmin);
    public IEnumerable<PersonExperience> AllPersonExperienceSite(int queryNum, int pageNum, int person_data_id);
    public PersonExperience GetByIdPersonExperienceSite(int id);
    public PersonExperience GetByIdPersonExperience(int id, bool isAdmin);
    public bool DeletePersonExperience(int id);
    public bool UpdatePersonExperience(int id, PersonExperience PersonExperience, bool isAdmin);

    // PersonExperienceTranslation CRUD
    public int CreatePersonExperienceTranslation(PersonExperienceTranslation PersonExperience);
    public IEnumerable<PersonExperienceTranslation> AllPersonExperienceTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code);
    public IEnumerable<PersonExperienceTranslation> AllPersonExperienceTranslationSite(int queryNum, int pageNum, int person_data_id, string language_code);
    public PersonExperienceTranslation GetByIdPersonExperienceTranslation(int id, bool isAdmin);
    public PersonExperienceTranslation GetByIdPersonExperienceTranslationSite(int id);
    public PersonExperienceTranslation GetByIdPersonExperienceTranslation(int uz_id, string language_code, bool isAdmin);
    public PersonExperienceTranslation GetByIdPersonExperienceTranslationSite(int uz_id, string language_code);
    public bool DeletePersonExperienceTranslation(int id);
    public bool UpdatePersonExperienceTranslation(int id, PersonExperienceTranslation PersonExperience, bool isAdmin);


    //Confirm
    public IEnumerable<PersonData> AllPersonExperienceCreated();
    public IEnumerable<PersonExperience> AllPersonExperienceDep(int queryNum, int pageNum, int person_data_id);
    public bool ConfirmDocumentTeacher110Set(int id, bool confirm);

}
