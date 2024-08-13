using Entities.Model.DepartamentsTypeModel;

namespace Contracts.AllRepository.DepartamentsTypeRepository;

public interface IDepartamentTypeRepository
{
    //DepartamentType CRUD
    public IEnumerable<DepartamentType> AllDepartamentType(int queryNum, int pageNum);
    public IEnumerable<DepartamentType> AllDepartamentTypeSite(int queryNum, int pageNum);
    public DepartamentType GetDepartamentTypeById(int id);
    public DepartamentType GetDepartamentTypeByIdSite(int id);
    public int CreateDepartamentType(DepartamentType departamentType);
    public bool UpdateDepartamentType(int id, DepartamentType departamentType);
    public bool DeleteDepartamentType(int id);



    //DepartamentTypeTranslation CRUD
    public IEnumerable<DepartamentTypeTranslation> AllDepartamentTypeTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<DepartamentTypeTranslation> AllDepartamentTypeTranslationSite(int queryNum, int pageNum, string language_code);
    public DepartamentTypeTranslation GetDepartamentTypeTranslationById(int id);
    public DepartamentTypeTranslation GetDepartamentTypeTranslationById(int uz_id, string language_code);
    public DepartamentTypeTranslation GetDepartamentTypeTranslationByIdSite(int uz_id, string language_code);
    public DepartamentTypeTranslation GetDepartamentTypeTranslationByIdSite(int id);
    public int CreateDepartamentTypeTranslation(DepartamentTypeTranslation departamentTypeTranslation);
    public bool UpdateDepartamentTypeTranslation(int id, DepartamentTypeTranslation departamentType);
    public bool DeleteDepartamentTypeTranslation(int id);

    public bool SaveChanges();

}
