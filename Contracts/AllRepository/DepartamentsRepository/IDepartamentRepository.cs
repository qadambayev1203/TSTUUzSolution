using Entities.Model.AnyClasses;
using Entities.Model.DepartamentsModel;

namespace Contracts.AllRepository.DepartamentsRepository;

public interface IDepartamentRepository
{
    //Departament CRUD
    public QueryList<Departament> AllDepartament(int queryNum, int pageNum);
    public QueryList<Departament> AllDepartamentSite(int queryNum, int pageNum);
    public IEnumerable<Departament> AllDepartamentStructure();
    public IEnumerable<Departament> AllDepartamentChild(int parent_id);
    public IEnumerable<Departament> AllDepartamentFacultyDirection(int faculty_id);
    public QueryList<Departament> AllDepartamentType(string dep_type, int queryNum, int pageNum);
    public QueryList<Departament> AllDepartamentTypeSite(string dep_type, int queryNum, int pageNum, bool? favorite);
    public IEnumerable<Departament> SelectDepartaments();
    public Departament GetDepartamentById(int id);
    public Departament GetDepartamentByIdSite(int id);
    public int CreateDepartament(Departament departament);
    public bool UpdateDepartament(int id, Departament departament);
    public bool DeleteDepartament(int id);

    public IEnumerable<Departament> SelectFaculty();
    public IEnumerable<Departament> SelectFacultyDepartament(int? faculty_id);


    //DepartamentTranslation CRUD
    public QueryList<DepartamentTranslation> AllDepartamentTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<DepartamentTranslation> SelectDepartamentsTranslation(string language_code);
    public QueryList<DepartamentTranslation> AllDepartamentTranslationSite(int queryNum, int pageNum, string language_code);
    public IEnumerable<DepartamentTranslation> AllDepartamentTranslationStructure(string language_code);
    public IEnumerable<DepartamentTranslation> AllDepartamentTranslationChild(int parent_id, string language_code);
    public IEnumerable<DepartamentTranslation> AllDepartamentTranslationFacultyDirection(int faculty_id, string language_code);
    public QueryList<DepartamentTranslation> AllDepartamentTranslationType(string dep_type, string language_code, int queryNum, int pageNum);
    public QueryList<DepartamentTranslation> AllDepartamentTranslationTypeSite(string dep_type, string language_code, int queryNum, int pageNum, bool? favorite);
    public DepartamentTranslation GetDepartamentTranslationById(int id);
    public DepartamentTranslation GetDepartamentTranslationById(int uz_id, string language_code);
    public DepartamentTranslation GetDepartamentTranslationByIdSite(int uz_id, string language_code);
    public DepartamentTranslation GetDepartamentTranslationByIdSite(int id);
    public int CreateDepartamentTranslation(DepartamentTranslation departamentTranslation);
    public bool UpdateDepartamentTranslation(int id, DepartamentTranslation departament);
    public bool DeleteDepartamentTranslation(int id);
    public bool SaveChanges();




    // Departament Head
    public Departament GetDepartamentByHeadDep();
    public bool UpdateDepartamentHeadDep(Departament departament);


    public DepartamentTranslation GetDepartamentTranslationByHeadDep(string language_code);
    public bool UpdateDepartamentTranslationHeadDep(string language_code, DepartamentTranslation departament);

}
