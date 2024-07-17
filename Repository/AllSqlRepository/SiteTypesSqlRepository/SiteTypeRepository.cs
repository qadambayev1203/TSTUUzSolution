using Contracts.AllRepository.SiteTypesRepository;
using Entities.Model.SiteTypesModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Entities.Model.TerritoriesModel;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.SiteTypesSqlRepository
{
    public class SiteTypeRepository : ISiteTypeRepository
    {

        private readonly RepositoryContext _context;
        private readonly ILogger<SiteTypeRepository> _logger;
        public SiteTypeRepository(RepositoryContext repositoryContext, ILogger<SiteTypeRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }


        //SiteType CRUD
        public IEnumerable<SiteType> AllSiteTypeSite(int queryNum, int pageNum)
        {
            try
            {
                var siteTypees = new List<SiteType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted").ToList();

                }
                return siteTypees;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
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
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    siteTypees = _context.site_types_20ts24tu
                        .Include(x => x.status_).ToList();

                }
                return siteTypees;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public int CreateSiteType(SiteType siteType)
        {
            try
            {
                if (siteType == null)
                {
                    return 0;
                }
                _context.site_types_20ts24tu.Add(siteType);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(siteType));

                return siteType.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
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
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(siteType));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);

                return false;
            }
        }

        public SiteType GetSiteTypeByIdSite(int id)
        {
            try
            {
                var siteType = _context.site_types_20ts24tu
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));
                return siteType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
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
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateSiteType(int id, SiteType siteType)
        {
            try
            {
                var dbcheck = GetSiteTypeById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.type = siteType.type;
                dbcheck.status_id = siteType.status_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }

        }






        //SiteTypeTranslation CRUD
        public IEnumerable<SiteTypeTranslation> AllSiteTypeTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var siteTypeesTranslation = new List<SiteTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                        .ToList();

                }
                return siteTypeesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
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
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    siteTypeesTranslation = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)

                        .ToList();

                }
                return siteTypeesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public int CreateSiteTypeTranslation(SiteTypeTranslation siteTypeTranslation)
        {
            try
            {
                if (siteTypeTranslation == null)
                {
                    return 0;
                }
                _context.site_types_translations_20ts24tu.Add(siteTypeTranslation);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(siteTypeTranslation));

                return siteTypeTranslation.id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
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
                siteTypeTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                    .FirstOrDefault(x => x.status == "Deleted" && x.language_id == siteTypeTranslation.language_id)).id;
                _context.site_types_translations_20ts24tu.Update(siteTypeTranslation);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(siteTypeTranslation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }

        public SiteTypeTranslation GetSiteTypeTranslationByIdSite(int id)
        {
            try
            {
                var siteType = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));
                return siteType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
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
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public SiteTypeTranslation GetSiteTypeTranslationById(int uz_id, string language_code)
        {
            try
            {
                var siteType = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.site_type_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return siteType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public SiteTypeTranslation GetSiteTypeTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var siteType = _context.site_types_translations_20ts24tu
                        .Include(x => x.site_type_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.site_type_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return siteType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateSiteTypeTranslation(int id, SiteTypeTranslation siteType)
        {
            try
            {
                var dbcheck = GetSiteTypeTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.site_type_id = siteType.site_type_id;
                dbcheck.language_id = siteType.language_id;
                dbcheck.status_translation_id = siteType.status_translation_id;
                dbcheck.type = siteType.type;
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
