using Contracts.AllRepository.SitesRepository;
using Entities.Model.SitesModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.SitesSqlRepository
{
    public class SiteSqlRepository : ISiteRepository
    {
        private readonly RepositoryContext _context;
        public SiteSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        //Site CRUD
        public IEnumerable<Site> AllSite(int queryNum, int pageNum)
        {
            try
            {
                var sitees = new List<Site>();
                if (queryNum == 0 && pageNum != 0)
                {
                    sitees = _context.sites_20ts24tu.Include(x=>x.status_).Include(x=>x.site_type_).Include(x=>x.user_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    sitees = _context.sites_20ts24tu.Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_)
                        .Take(queryNum).ToList();

                }
                else
                {
                    sitees = _context.sites_20ts24tu.Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).Take(200).ToList();

                }
                return sitees;

            }
            catch
            {
                return null;
            }
        }

        public bool CreateSite(Site site)
        {
            try
            {
                if (site == null)
                {
                    return false;
                }
                site.created_at = DateTime.UtcNow;
                _context.sites_20ts24tu.Add(site);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                _context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }

        public Site GetSiteById(int id)
        {
            try
            {
                var site = _context.sites_20ts24tu.Include(x => x.status_).Include(x => x.site_type_).Include(x => x.user_).FirstOrDefault(x => x.id.Equals(id));
                return site;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateSite(Site site, int id)
        {
            try
            {
                var sitecheck=GetSiteById(id);
                if (sitecheck == null)
                {
                    return false;
                }
                site.id= sitecheck.id;
                site.updated_at = DateTime.UtcNow;
                _context.sites_20ts24tu.Update(site);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }






        //SiteTranslation CRUD
        public IEnumerable<SiteTranslation> AllSiteTranslation(int queryNum, int pageNum)
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
                        .Include(x => x.user_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteesTranslation = _context.sites_translations_20ts24tu
                        .Include(x => x.site_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.site_type_translation_)
                        .Include(x => x.user_)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    siteesTranslation = _context.sites_translations_20ts24tu.Include(x => x.site_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.site_type_translation_)
                        .Include(x => x.user_)
                        .Take(200)
                        .ToList();

                }
                return siteesTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateSiteTranslation(SiteTranslation siteTranslation)
        {
            try
            {
                if (siteTranslation == null)
                {
                    return false;
                }
                siteTranslation.created_at = DateTime.UtcNow;
                _context.sites_translations_20ts24tu.Add(siteTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                siteTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.sites_translations_20ts24tu.Update(siteTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                        .Include(x => x.user_).FirstOrDefault(x => x.id.Equals(id));
                return site;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateSiteTranslation(SiteTranslation siteTranslation, int id)
        {
            try
            {
                var siteTranslationCheck = GetSiteTranslationById(id);
                if (siteTranslationCheck == null)
                {
                    return false;
                }
                siteTranslation.id = siteTranslationCheck.id;
                siteTranslation.updated_at = DateTime.UtcNow;
                _context.sites_translations_20ts24tu.Update(siteTranslation );
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
