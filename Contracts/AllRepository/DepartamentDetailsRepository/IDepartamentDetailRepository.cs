using Entities.Model.DepartamentDetailsModel;

namespace Contracts.AllRepository.DepartamentDetailsRepository;

public interface IDepartamentDetailRepository
{
    //departamentDetail CRUD
    public IEnumerable<DepartamentDetail> AllDepartamentDetail(int queryNum, int pageNum);
    public IEnumerable<DepartamentDetail> AllDepartamentDetailSite(int queryNum, int pageNum);
    public DepartamentDetail GetDepartamentDetailById(int id);
    public DepartamentDetail GetDepartamentDetailByIdSite(int id);
    public int CreateDepartamentDetail(DepartamentDetail departamentDetail);
    public bool UpdateDepartamentDetail(int id, DepartamentDetail departamentDetail);
    public bool DeleteDepartamentDetail(int id);



    //departamentDetailTranslation CRUD
    public IEnumerable<DepartamentDetailTranslation> AllDepartamentDetailTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<DepartamentDetailTranslation> AllDepartamentDetailTranslationSite(int queryNum, int pageNum, string language_code);
    public DepartamentDetailTranslation GetDepartamentDetailTranslationById(int id);
    public DepartamentDetailTranslation GetDepartamentDetailTranslationById(int uz_id, string language_code);
    public DepartamentDetailTranslation GetDepartamentDetailTranslationByIdSite(int uz_id, string language_code);
    public DepartamentDetailTranslation GetDepartamentDetailTranslationByIdSite(int id);
    public int CreateDepartamentDetailTranslation(DepartamentDetailTranslation departamentDetailTranslation);
    public bool UpdateDepartamentDetailTranslation(int id, DepartamentDetailTranslation departamentDetail);
    public bool DeleteDepartamentDetailTranslation(int id);
    public bool SaveChanges();

}
