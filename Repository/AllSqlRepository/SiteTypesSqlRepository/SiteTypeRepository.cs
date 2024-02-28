using Contracts.AllRepository.SiteTypesRepository;
using Entities.Model.SiteTypesModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.SiteTypesSqlRepository
{
    public class SiteTypeRepository : ISiteTypeRepository
    {
        private readonly RepositoryContext _context;
        public SiteTypeRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        //SiteType CRUD
        public IEnumerable<SiteType> AllSiteType(int queryNum, int pageNum)
        {
            try
            {
                var siteTypees = new List<SiteType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_)
                        .Take(queryNum).ToList();

                }
                else
                {
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_).Take(200).ToList();

                }
                return siteTypees;

            }
            catch
            {
                return null;
            }
        }

        public bool CreateSiteType(SiteType siteType)
        {
            try
            {
                if (siteType == null)
                {
                    return false;
                }
                _context.site_types_20ts24tu.Add(siteType);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSiteType(int id)
        {
            try
            {
                var siteType = GetSiteTypeById(id);
                if (siteType == null)
                {
                    return false;
                }
                siteType.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.site_types_20ts24tu.Update(siteType);
                _context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }

        public SiteType GetSiteTypeById(int id)
        {
            try
            {
                var siteType = _context.site_types_20ts24tu
                        .Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return siteType;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateSiteType(SiteType siteType, int id)
        {
            try
            {
                var siteTypecheck = GetSiteTypeById(id);
                if (siteTypecheck == null)
                {
                    return false;
                }
                siteType.id = siteTypecheck.id;
                _context.site_types_20ts24tu.Update(siteType);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }






        //SiteTypeTranslation CRUD
        public IEnumerable<SiteTypeTranslation> AllSiteTypeTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var siteTypeesTranslation = new List<SiteTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).Where(x => x.language_.code.Equals(language_code))
                        .Take(200)
                        .ToList();

                }
                return siteTypeesTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateSiteTypeTranslation(SiteTypeTranslation siteTypeTranslation)
        {
            try
            {
                if (siteTypeTranslation == null)
                {
                    return false;
                }
                _context.site_types_translations_20ts24tu.Add(siteTypeTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSiteTypeTranslation(int id)
        {
            try
            {
                var siteTypeTranslation = GetSiteTypeTranslationById(id);
                if (siteTypeTranslation == null)
                {
                    return false;
                }
                siteTypeTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.site_types_translations_20ts24tu.Update(siteTypeTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public SiteTypeTranslation GetSiteTypeTranslationById(int id)
        {
            try
            {
                var siteType = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return siteType;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateSiteTypeTranslation(SiteTypeTranslation siteTypeTranslation, int id)
        {
            try
            {
                var siteTypeTranslationCheck = GetSiteTypeTranslationById(id);
                if (siteTypeTranslationCheck == null)
                {
                    return false;
                }
                siteTypeTranslation.id = siteTypeTranslationCheck.id;
                _context.site_types_translations_20ts24tu.Update(siteTypeTranslation);
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
