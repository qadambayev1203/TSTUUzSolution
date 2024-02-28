using Contracts.AllRepository.SiteDetailsRepository;
using Entities.Model.SiteDetailsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.SiteDetailsSqlRepository
{
    public class SiteDetailSqlRepository : ISiteDetailRepository
    {
        private readonly RepositoryContext _context;
        public SiteDetailSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        //SiteDetail CRUD
        public IEnumerable<SiteDetail> AllSiteDetail(int queryNum, int pageNum)
        {
            try
            {
                var siteDetailes = new List<SiteDetail>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x=>x.logo_w_)
                        .Include(x=>x.logo_b_)
                        .Include(x=>x.favicon_)
                        .Include(x=>x.site_)
                        .Include(x=>x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_)
                        .Take(queryNum).ToList();

                }
                else
                {
                    siteDetailes = _context.site_details_20ts24tu
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_)
                        .Include(x => x.status_).Take(200).ToList();

                }
                return siteDetailes;

            }
            catch
            {
                return null;
            }
        }

        public bool CreateSiteDetail(SiteDetail siteDetail)
        {
            try
            {
                if (siteDetail == null)
                {
                    return false;
                }
                siteDetail.created_at = DateTime.UtcNow;
                _context.site_details_20ts24tu.Add(siteDetail);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                _context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
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
            catch
            {
                return null;
            }
        }

        public bool UpdateSiteDetail(SiteDetail siteDetail, int id)
        {
            try
            {
                var siteDetailcheck = GetSiteDetailById(id);
                if (siteDetailcheck == null)
                {
                    return false;
                }
                siteDetail.id = siteDetailcheck.id;
                siteDetail.update_at = DateTime.UtcNow;
                _context.site_details_20ts24tu.Update(siteDetail);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }






        //SiteDetailTranslation CRUD
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
                        .Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteDetailesTranslation = _context.site_details_translations_20ts24tu
                        .Include(x => x.site_detail_)
                        .Include(x => x.language_)
                        .Include(x => x.logo_w_)
                        .Include(x => x.logo_b_)
                        .Include(x => x.favicon_)
                        .Include(x => x.site_translation_)
                        .Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Take(queryNum)
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
                        .Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Take(200)
                        .ToList();

                }
                return siteDetailesTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateSiteDetailTranslation(SiteDetailTranslation siteDetailTranslation)
        {
            try
            {
                if (siteDetailTranslation == null)
                {
                    return false;
                }
                siteDetailTranslation.created_at = DateTime.UtcNow;
                _context.site_details_translations_20ts24tu.Add(siteDetailTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                siteDetailTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.site_details_translations_20ts24tu.Update(siteDetailTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
            catch
            {
                return null;
            }
        }

        public bool UpdateSiteDetailTranslation(SiteDetailTranslation siteDetailTranslation, int id)
        {
            try
            {
                var siteDetailTranslationCheck = GetSiteDetailTranslationById(id);
                if (siteDetailTranslationCheck == null)
                {
                    return false;
                }
                siteDetailTranslation.id = siteDetailTranslationCheck.id;
                siteDetailTranslation.update_at = DateTime.UtcNow;
                _context.site_details_translations_20ts24tu.Update(siteDetailTranslation);
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
