using Entities.Model.AppealsToTheRectorsModel;

namespace Contracts.AllRepository.AppealsToRectorRepository;

public interface IAppealToRectorRepository
{
    //AppealToRector CRUD
    public IEnumerable<AppealToRector> AllAppealToRector(int queryNum, int pageNum, DateTime? start_time, DateTime? end_time);
    public AppealToRector GetAppealToRectorById(int id);
    public int CreateAppealToRector(AppealToRector appealToRector);
    public bool UpdateAppealToRector(int id, AppealToRector appealToRector);
    public IEnumerable<AppealToRector> GetByAppealStatus(string email);



    //AppealToRectorTranslation CRUD
    public IEnumerable<AppealToRectorTranslation> AllAppealToRectorTranslation(int queryNum, int pageNum, string language_code, DateTime? start_time, DateTime? end_time);
    public AppealToRectorTranslation GetAppealToRectorTranslationById(int id);
    public int CreateAppealToRectorTranslation(AppealToRectorTranslation appealToRectorTranslation);
    public bool UpdateAppealToRectorTranslation(int id, AppealToRectorTranslation appealToRectorTranslation);
    public IEnumerable<AppealToRectorTranslation> GetByAppealStatusTranslation(string email, string language_code);


    public bool SaveChanges();
}
