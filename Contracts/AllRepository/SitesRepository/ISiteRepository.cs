using Entities.Model.SitesModel;

namespace Contracts.AllRepository.SitesRepository;

public interface ISiteRepository
{
    //Site CRUD
    public IEnumerable<Site> AllSite(int queryNum, int pageNum);
    public IEnumerable<Site> AllSiteSite(int queryNum, int pageNum);
    public Site GetSiteById(int id);
    public Site GetSiteByIdSite(int id);
    public int CreateSite(Site site);
    public bool UpdateSite(int id, Site site);
    public bool DeleteSite(int id);



    //SiteTranslation CRUD
    public IEnumerable<SiteTranslation> AllSiteTranslation(int queryNum, int pageNum, string language_code);
    public IEnumerable<SiteTranslation> AllSiteTranslationSite(int queryNum, int pageNum, string language_code);
    public SiteTranslation GetSiteTranslationById(int id);
    public SiteTranslation GetSiteTranslationById(int uz_id, string language_code);
    public SiteTranslation GetSiteTranslationByIdSite(int uz_id, string language_code);
    public SiteTranslation GetSiteTranslationByIdSite(int id);
    public int CreateSiteTranslation(SiteTranslation siteTranslation);
    public bool UpdateSiteTranslation(int id, SiteTranslation site);
    public bool DeleteSiteTranslation(int id);
    public bool SaveChanges();

}
