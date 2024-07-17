using Contracts.AllRepository.InteractiveServicesRepository;
using Entities;
using Entities.Model.DepartamentsModel;
using Entities.Model.InteractiveServicesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AllSqlRepository.InteractivesServicesSqlRepository
{
    public class InteractiveServicesSqlRepository : IInteractiveServicesRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<InteractiveServicesSqlRepository> _logger;
        public InteractiveServicesSqlRepository(RepositoryContext repositoryContext, ILogger<InteractiveServicesSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        #region InteractiveServices CRUD
        public IEnumerable<InteractiveServices> AllInteractiveServices(int queryNum, int pageNum, bool? favorite)
        {
            try
            {
                var InteractiveServicess = new List<InteractiveServices>();
                if (queryNum == 0 && pageNum != 0)
                {
                    InteractiveServicess = _context.interactive_services_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.icon_)
                        .Include(x => x.img_)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)

                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    InteractiveServicess = _context.interactive_services_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.icon_)
                        .Include(x => x.img_)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    InteractiveServicess = _context.interactive_services_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.icon_)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Include(x => x.img_)
                       .ToList();

                }
                return InteractiveServicess;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public IEnumerable<InteractiveServices> AllInteractiveServicesSite(int queryNum, int pageNum, bool? favorite)
        {
            try
            {
                var InteractiveServicess = new List<InteractiveServices>();
                if (queryNum == 0 && pageNum != 0)
                {
                    InteractiveServicess = _context.interactive_services_20ts24tu
                        .Include(x => x.icon_)
                        .Include(x => x.img_)
                        .Where(x => x.status_.status != "Deleted")
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)

                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    InteractiveServicess = _context.interactive_services_20ts24tu
                        .Include(x => x.icon_)
                        .Include(x => x.img_)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where(x => x.status_.status != "Deleted")
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    InteractiveServicess = _context.interactive_services_20ts24tu
                        .Include(x => x.icon_)
                        .Include(x => x.img_)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where(x => x.status_.status != "Deleted")
                       .ToList();

                }
                return InteractiveServicess;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public int CreateInteractiveServices(InteractiveServices InteractiveServices)
        {
            try
            {
                if (InteractiveServices == null)
                {
                    return 0;
                }
                _context.interactive_services_20ts24tu.Add(InteractiveServices);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                int id = InteractiveServices.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(InteractiveServices));

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
            }
        }

        public bool DeleteInteractiveServices(int id)
        {
            try
            {
                var emp = GetInteractiveServicesById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.interactive_services_20ts24tu.Update(emp);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }

        public InteractiveServices GetInteractiveServicesById(int id)
        {
            try
            {
                var InteractiveServices = _context.interactive_services_20ts24tu
                    .Include(x => x.status_)
                        .Include(x => x.icon_)
                        .Include(x => x.img_)
                        .FirstOrDefault(x => x.id.Equals(id));

                return InteractiveServices;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }
        public InteractiveServices GetInteractiveServicesByIdSite(int id)
        {
            try
            {
                var InteractiveServices = _context.interactive_services_20ts24tu
                    .Include(x => x.icon_)
                        .Include(x => x.img_)
                        .Where(x => x.status_.status != "Deleted")
                        .FirstOrDefault(x => x.id.Equals(id));

                return InteractiveServices;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateInteractiveServices(int id, InteractiveServices InteractiveServices)
        {

            try
            {
                var dbcheck = GetInteractiveServicesById(id);
                if (dbcheck is null)
                {
                    return false;
                }

                dbcheck.title = InteractiveServices.title;
                dbcheck.description = InteractiveServices.description;
                dbcheck.url_ = InteractiveServices.url_;
                if (InteractiveServices.img_ != null)
                {
                    dbcheck.img_ = InteractiveServices.img_;
                }
                if (InteractiveServices.icon_ != null)
                {
                    dbcheck.icon_ = InteractiveServices.icon_;
                }


                dbcheck.status_id = InteractiveServices.status_id;
                dbcheck.favorite = InteractiveServices.favorite;

                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }


        #endregion




        #region InteractiveServicesTranslation CRUD
        public IEnumerable<InteractiveServicesTranslation> AllInteractiveServicesTranslation(int queryNum, int pageNum, string language_code, bool? favorite)
        {
            try
            {
                var InteractiveServicesTranslations = new List<InteractiveServicesTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    InteractiveServicesTranslations = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    InteractiveServicesTranslations = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    InteractiveServicesTranslations = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return InteractiveServicesTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public IEnumerable<InteractiveServicesTranslation> AllInteractiveServicesTranslationSite(int queryNum, int pageNum, string language_code, bool? favorite)
        {
            try
            {
                var InteractiveServicesTranslations = new List<InteractiveServicesTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    InteractiveServicesTranslations = _context.interactive_services_translations_20ts24tu
                       .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10).Where(x => x.status_translation_.status != "Deleted")
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    InteractiveServicesTranslations = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    InteractiveServicesTranslations = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return InteractiveServicesTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public int CreateInteractiveServicesTranslation(InteractiveServicesTranslation InteractiveServicesTranslation)
        {
            try
            {
                if (InteractiveServicesTranslation == null)
                {
                    return 0;
                }
                _context.interactive_services_translations_20ts24tu.Add(InteractiveServicesTranslation);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                var id = InteractiveServicesTranslation.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(InteractiveServicesTranslation));
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return 0;
            }
        }

        public bool DeleteInteractiveServicesTranslation(int id)
        {
            try
            {
                var emp = GetInteractiveServicesTranslationById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_translation_id = (_context.statuses_translations_20ts24tu
                    .FirstOrDefault(x => x.status == "Deleted" && x.language_id == emp.language_id)).id;
                _context.interactive_services_translations_20ts24tu.Update(emp);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }

        public InteractiveServicesTranslation GetInteractiveServicesTranslationById(int id)
        {
            try
            {
                var InteractiveServicesTranslation = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .FirstOrDefault(x => x.id.Equals(id));
                return InteractiveServicesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public InteractiveServicesTranslation GetInteractiveServicesTranslationById(int uz_id, string language_code)
        {
            try
            {
                var InteractiveServicesTranslation = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .FirstOrDefault(x => x.interactive_services_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return InteractiveServicesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public InteractiveServicesTranslation GetInteractiveServicesTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var InteractiveServicesTranslation = _context.interactive_services_translations_20ts24tu
                        .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.interactive_services_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return InteractiveServicesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public InteractiveServicesTranslation GetInteractiveServicesTranslationByIdSite(int id)
        {
            try
            {
                var InteractiveServicesTranslation = _context.interactive_services_translations_20ts24tu
                    .Include(x => x.interactive_services_)
                        .Include(x => x.img_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.id.Equals(id));
                return InteractiveServicesTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return null;
            }
        }

        public bool UpdateInteractiveServicesTranslation(int id, InteractiveServicesTranslation interactiveservices)
        {

            try
            {
                var dbcheck = GetInteractiveServicesTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }

                dbcheck.title = interactiveservices.title;
                dbcheck.description = interactiveservices.description;
                dbcheck.url_ = interactiveservices.url_;
                dbcheck.interactive_services_id = interactiveservices.interactive_services_id;
                if (interactiveservices.img_ != null)
                {
                    dbcheck.img_ = interactiveservices.img_;
                }
                if (interactiveservices.icon_ != null)
                {
                    dbcheck.icon_ = interactiveservices.icon_;
                }

                dbcheck.language_id = interactiveservices.language_id;
                dbcheck.status_translation_id = interactiveservices.status_translation_id;
                dbcheck.favorite = interactiveservices.favorite;

                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.Message);
                return false;
            }
        }
        #endregion


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
}
