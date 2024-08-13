using Contracts.AllRepository.SitesRepository;
using Entities.Model.SitesModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.SitesSqlRepository;

public class SiteSqlRepository : ISiteRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<SiteSqlRepository> _logger;
    public SiteSqlRepository(RepositoryContext repositoryContext, ILogger<SiteSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }


    //Site CRUD
    public IEnumerable<Site> AllSiteSite(int queryNum, int pageNum)
    {
        try
        {
            var sitees = new List<Site>();
            if (queryNum == 0 && pageNum != 0)
            {
                sitees = _context.sites_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                sitees = _context.sites_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                sitees = _context.sites_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_).ToList();

            }
            return sitees;

        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public IEnumerable<Site> AllSite(int queryNum, int pageNum)
    {
        try
        {
            var sitees = new List<Site>();
            if (queryNum == 0 && pageNum != 0)
            {
                sitees = _context.sites_20ts24tu.Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                sitees = _context.sites_20ts24tu.Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                sitees = _context.sites_20ts24tu.Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_).ToList();

            }
            return sitees;

        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateSite(Site site)
    {
        try
        {
            if (site == null)
            {
                return 0;
            }
            site.created_at = DateTime.UtcNow;
            _context.sites_20ts24tu.Add(site);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(site));

            return site.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteSite(int id)
    {
        try
        {
            var site = GetSiteById(id);
            if (site == null)
            {
                return false;
            }
            site.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.sites_20ts24tu.Update(site);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(site));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);

            return false;
        }
    }

    public Site GetSiteByIdSite(int id)
    {
        try
        {
            var site = _context.sites_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.id.Equals(id));
            return site;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public Site GetSiteById(int id)
    {
        try
        {
            var site = _context.sites_20ts24tu.Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.id.Equals(id));
            return site;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateSite(int id, Site site)
    {
        try
        {
            var dbcheck = GetSiteById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.title = site.title;
            dbcheck.description = site.description;
            dbcheck.status_id = site.status_id;
            dbcheck.site_type_id = site.site_type_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }






    //SiteTranslation CRUD
    public IEnumerable<SiteTranslation> AllSiteTranslationSite(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var siteesTranslation = new List<SiteTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                siteesTranslation = _context.sites_translations_20ts24tu
                    .Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                siteesTranslation = _context.sites_translations_20ts24tu
                    .Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                siteesTranslation = _context.sites_translations_20ts24tu.Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                    .ToList();

            }
            return siteesTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);

            return null;

        }
    }
    public IEnumerable<SiteTranslation> AllSiteTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var siteesTranslation = new List<SiteTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                siteesTranslation = _context.sites_translations_20ts24tu
                    .Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                siteesTranslation = _context.sites_translations_20ts24tu
                    .Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                siteesTranslation = _context.sites_translations_20ts24tu.Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                    .ToList();

            }
            return siteesTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);

            return null;

        }
    }

    public int CreateSiteTranslation(SiteTranslation siteTranslation)
    {
        try
        {
            if (siteTranslation == null)
            {
                return 0;
            }
            siteTranslation.created_at = DateTime.UtcNow;
            _context.sites_translations_20ts24tu.Add(siteTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(siteTranslation));

            return siteTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteSiteTranslation(int id)
    {
        try
        {
            var siteTranslation = GetSiteTranslationById(id);
            if (siteTranslation == null)
            {
                return false;
            }
            siteTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == siteTranslation.language_id)).id;
            _context.sites_translations_20ts24tu.Update(siteTranslation);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(siteTranslation));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public SiteTranslation GetSiteTranslationByIdSite(int id)
    {
        try
        {
            var site = _context.sites_translations_20ts24tu.Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Where(x => x.status_translation_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));
            return site;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public SiteTranslation GetSiteTranslationById(int id)
    {
        try
        {
            var site = _context.sites_translations_20ts24tu.Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.id.Equals(id));
            return site;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public SiteTranslation GetSiteTranslationById(int uz_id, string language_code)
    {
        try
        {
            var site = _context.sites_translations_20ts24tu.Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .FirstOrDefault(x => x.site_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return site;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public SiteTranslation GetSiteTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var site = _context.sites_translations_20ts24tu.Include(x => x.site_)
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.site_type_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.site_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return site;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateSiteTranslation(int id, SiteTranslation site)
    {
        try
        {
            var dbcheck = GetSiteTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.site_id = site.site_id;
            dbcheck.language_id = site.language_id;
            dbcheck.title = site.title;
            dbcheck.description = site.description;
            dbcheck.status_translation_id = site.status_translation_id;
            dbcheck.site_type_translation_id = site.site_type_translation_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }

    public bool SaveChanges()
    {
        try
        {
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }
}
