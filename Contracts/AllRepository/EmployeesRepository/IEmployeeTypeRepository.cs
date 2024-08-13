using Entities.Model.EmployeeTypesModel;

namespace Contracts.AllRepository.EmployeesRepository;

public interface IEmployeeTypeRepository
{
    //EmployeeType CRUD
    public IEnumerable<EmployeeType> AllEmployeeType(int queryNum, int pageNum);
    public IEnumerable<EmployeeType> AllEmployeeTypeSite(int queryNum, int pageNum);
    public EmployeeType GetEmployeeTypeById(int id);
    public EmployeeType GetEmployeeTypeByIdSite(int id);
    public int CreateEmployeeType(EmployeeType employeeType);
    public bool UpdateEmployeeType(int id, EmployeeType employeeType);
    public bool DeleteEmployeeType(int id);



    //EmployeeTypeTranslation CRUD
    public IEnumerable<EmployeeTypeTranslation> AllEmployeeTypeTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<EmployeeTypeTranslation> AllEmployeeTypeTranslationSite(int queryNum, int pageNum, string language_code);
    public EmployeeTypeTranslation GetEmployeeTypeTranslationById(int id);
    public EmployeeTypeTranslation GetEmployeeTypeTranslationById(int uz_id, string language_code);
    public EmployeeTypeTranslation GetEmployeeTypeTranslationByIdSite(int uz_id, string language_code);
    public EmployeeTypeTranslation GetEmployeeTypeTranslationByIdSite(int id);
    public int CreateEmployeeTypeTranslation(EmployeeTypeTranslation employeeTypeTranslation);
    public bool UpdateEmployeeTypeTranslation(int id, EmployeeTypeTranslation employeeType);
    public bool DeleteEmployeeTypeTranslation(int id);


    public bool SaveChanges();
}
