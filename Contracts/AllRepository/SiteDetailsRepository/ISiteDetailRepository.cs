using Entities.Model.SiteDetailsModel;

namespace Contracts.AllRepository.SiteDetailsRepository;

public interface ISiteDetailRepository
{
    //SiteDetail CRUD
    public IEnumerable<SiteDetail> AllSiteDetail(int queryNum, int pageNum);
    public IEnumerable<SiteDetail> AllSiteDetailSite(int queryNum, int pageNum);
    public SiteDetail GetSiteDetailById(int id);
    public SiteDetail GetSiteDetailByIdSite(int id);
    public int CreateSiteDetail(SiteDetail siteDetail);
    public bool UpdateSiteDetail(int id, SiteDetail site);
    public bool DeleteSiteDetail(int id);



    //SiteDetailTranslation CRUD
    public IEnumerable<SiteDetailTranslation> AllSiteDetailTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<SiteDetailTranslation> AllSiteDetailTranslationSite(int queryNum, int pageNum, string language_code);
    public SiteDetailTranslation GetSiteDetailTranslationById(int id);
    public SiteDetailTranslation GetSiteDetailTranslationById(int uz_id, string language_code);
    public SiteDetailTranslation GetSiteDetailTranslationByIdSite(int uz_id, string language_code);
    public SiteDetailTranslation GetSiteDetailTranslationByIdSite(int id);
    public int CreateSiteDetailTranslation(SiteDetailTranslation siteDetailTranslation);
    public bool UpdateSiteDetailTranslation(int id, SiteDetailTranslation site);
    public bool DeleteSiteDetailTranslation(int id);
    public bool SaveChanges();

}
