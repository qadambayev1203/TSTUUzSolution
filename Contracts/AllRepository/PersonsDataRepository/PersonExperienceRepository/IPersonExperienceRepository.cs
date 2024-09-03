using Entities.Model.PersonDataModel.PersonExperienceModel;

namespace Contracts.AllRepository.PersonsDataRepository.PersonExperienceRepository;

public interface IPersonExperienceRepository
{
    // PersonExperience CRUD
    public int CreatePersonExperience(PersonExperience personExperience);
    public IEnumerable<PersonExperience> AllPersonExperience(int queryNum, int pageNum, int person_data_id, bool isAdmin);
    public PersonExperience GetByIdPersonExperience(int id, bool isAdmin);
    public bool DeletePersonExperience(int id);
    public bool UpdatePersonExperience(int id, PersonExperience personExperience, bool isAdmin);

    // PersonExperienceTranslation CRUD
    public int CreatePersonExperienceTranslation(PersonExperienceTranslation personExperience);
    public IEnumerable<PersonExperienceTranslation> AllPersonExperienceTranslation(int queryNum, int pageNum, int person_data_id, bool isAdmin, string language_code);
    public PersonExperienceTranslation GetByIdPersonExperienceTranslation(int id, bool isAdmin);
    public PersonExperienceTranslation GetByIdPersonExperienceTranslation(int uz_id, string language_code, bool isAdmin);
    public bool DeletePersonExperienceTranslation(int id);
    public bool UpdatePersonExperienceTranslation(int id, PersonExperienceTranslation personExperience, bool isAdmin);
}
