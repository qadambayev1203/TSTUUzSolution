using Contracts.AllRepository.SiteDetailsRepository;
using Entities.Model.SiteDetailsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Entities.Model.SitesModel;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Entities.Model.PersonModel;

namespace Repository.AllSqlRepository.SiteDetailsSqlRepository
{
    public class SiteDetailSqlRepository : ISiteDetailRepository
    {

        private readonly RepositoryContext _context;
        private readonly ILogger<SiteDetailSqlRepository> _logger;
        public SiteDetailSqlRepository(RepositoryContext repositoryContext, ILogger<SiteDetailSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }


        //SiteDetail CRUD
        public IEnumerable<SiteDetail> AllSiteDetailSite(int queryNum, int pageNum)
        {
            try
            {
                var siteDetailes = new List<SiteDetail>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted").ToList();

                }
                return siteDetailes;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public IEnumerable<SiteDetail> AllSiteDetail(int queryNum, int pageNum)
        {
            try
            {
                var siteDetailes = new List<SiteDetail>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_).ToList();

                }
                return siteDetailes;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public int CreateSiteDetail(SiteDetail siteDetail)
        {
            try
            {
                if (siteDetail == null)
                {
                    return 0;
                }
                siteDetail.created_at = DateTime.UtcNow;
                _context.site_details_20ts24tu.Add(siteDetail);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(siteDetail));

                return siteDetail.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
            }
        }

        public bool DeleteSiteDetail(int id)
        {
            try
            {
                var siteDetail = GetSiteDetailById(id);
                if (siteDetail == null)
                {
                    return false;
                }
                siteDetail.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.site_details_20ts24tu.Update(siteDetail);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(siteDetail));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);

                return false;
            }
        }

        public SiteDetail GetSiteDetailByIdSite(int id)
        {
            try
            {
                var siteDetail = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));
                return siteDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public SiteDetail GetSiteDetailById(int id)
        {
            try
            {
                var siteDetail = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return siteDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateSiteDetail(int id, SiteDetail site)
        {
            try
            {
                var dbcheck = GetSiteDetailById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.title = site.title;
                dbcheck.description = site.description;
                if (site.logo_w_ != null)
                {
                    dbcheck.logo_w_ = site.logo_w_;
                }
                if (site.logo_b_ != null)
                {
                    dbcheck.logo_b_ = site.logo_b_;
                }
                if (site.favicon_ != null)
                {
                    dbcheck.favicon_ = site.favicon_;
                }


                dbcheck.update_at = DateTime.UtcNow;
                dbcheck.socials = site.socials;
                dbcheck.details = site.details;
                dbcheck.site_id = site.site_id;
                dbcheck.status_id = site.status_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }

        }






        //SiteDetailTranslation CRUD
        public IEnumerable<SiteDetailTranslation> AllSiteDetailTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var siteDetailesTranslation = new List<SiteDetailTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteDetailesTranslation = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteDetailesTranslation = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    siteDetailesTranslation = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                        .ToList();

                }
                return siteDetailesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public IEnumerable<SiteDetailTranslation> AllSiteDetailTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var siteDetailesTranslation = new List<SiteDetailTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteDetailesTranslation = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteDetailesTranslation = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    siteDetailesTranslation = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                        .ToList();

                }
                return siteDetailesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public int CreateSiteDetailTranslation(SiteDetailTranslation siteDetailTranslation)
        {
            try
            {
                if (siteDetailTranslation == null)
                {
                    return 0;
                }
                siteDetailTranslation.created_at = DateTime.UtcNow;
                _context.site_details_translations_20ts24tu.Add(siteDetailTranslation);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(siteDetailTranslation));

                return siteDetailTranslation.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
            }
        }

        public bool DeleteSiteDetailTranslation(int id)
        {
            try
            {
                var siteDetailTranslation = GetSiteDetailTranslationById(id);
                if (siteDetailTranslation == null)
                {
                    return false;
                }
                siteDetailTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                    .FirstOrDefault(x => x.status == "Deleted" && x.language_id == siteDetailTranslation.language_id)).id;
                _context.site_details_translations_20ts24tu.Update(siteDetailTranslation);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(siteDetailTranslation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }

        public SiteDetailTranslation GetSiteDetailTranslationByIdSite(int id)
        {
            try
            {
                var siteDetail = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return siteDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public SiteDetailTranslation GetSiteDetailTranslationById(int id)
        {
            try
            {
                var siteDetail = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return siteDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public SiteDetailTranslation GetSiteDetailTranslationById(int uz_id, string language_code)
        {
            try
            {
                var siteDetail = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_)
                        .FirstOrDefault(x => x.site_detail_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return siteDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public SiteDetailTranslation GetSiteDetailTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var siteDetail = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.site_detail_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return siteDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateSiteDetailTranslation(int id, SiteDetailTranslation site)
        {
            try
            {
                var dbcheck = GetSiteDetailTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.site_detail_id = site.site_detail_id;
                dbcheck.language_id = site.language_id;
                dbcheck.title = site.title;
                dbcheck.description = site.description;
                if (site.logo_w_ != null)
                {
                    dbcheck.logo_w_ = site.logo_w_;
                }
                if (site.logo_b_ != null)
                {
                    dbcheck.logo_b_ = site.logo_b_;
                }
                if (site.favicon_ != null)
                {
                    dbcheck.favicon_ = site.favicon_;
                }
                dbcheck.update_at = DateTime.UtcNow;
                dbcheck.socials = site.socials;
                dbcheck.details = site.details;
                dbcheck.site_translation_id = site.site_translation_id;
                dbcheck.status_translation_id = site.status_translation_id;
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
            try { _context.SaveChanges(); return true; }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message); return false;
            }
        }
    }
}
