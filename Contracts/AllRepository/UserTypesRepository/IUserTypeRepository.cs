using Entities.Model;

namespace Contracts.AllRepository.UserTypesRepository;

public interface IUserTypeRepository
{
    //UserType CRUD
    public IEnumerable<UserType> AllUserType(int queryNum,int pageNum);
    public IEnumerable<UserType> AllUserTypeSelect(int queryNum,int pageNum);
    public UserType GetUserTypeById(int id);
    public UserType GetUserTypeByIdSelect(int id);
    public int CreateUserType(UserType userType);
    public bool UpdateUserType(int id, UserType userType);
    public bool DeleteUserType(int id);


    //UserTypeTranslation CRUD
    public IEnumerable<UserTypeTranslation> AllUserTypeTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<UserTypeTranslation> AllUserTypeTranslationSelect(int queryNum, int pageNum, string language_code);
    public UserTypeTranslation GetUserTypeTranslationById(int id);
    public UserTypeTranslation GetUserTypeTranslationById(int uz_id, string language_code);
    public UserTypeTranslation GetUserTypeTranslationByIdSite(int uz_id, string language_code);
    public UserTypeTranslation GetUserTypeTranslationByIdSelect(int id);
    public int CreateUserTypeTranslation(UserTypeTranslation userTypeTranslation);
    public bool UpdateUserTypeTranslation(int id, UserTypeTranslation userType);
    public bool DeleteUserTypeTranslation(int id);
    public bool SaveChanges();



}
