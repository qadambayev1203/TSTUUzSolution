using Entities.Model.DepartamentDetailsModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.DepartamentDetailsRepository;
using Microsoft.Extensions.Logging;
using Entities.Model.StatusModel;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.DepartamentsDetailSqlRepository
{
    public class DepartamentDetailSqlRepository : IDepartamentDetailRepository
    {


        private readonly RepositoryContext _context;
        private readonly ILogger<DepartamentDetailSqlRepository> _logger;
        public DepartamentDetailSqlRepository(RepositoryContext repositoryContext, ILogger<DepartamentDetailSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        //DepartamentDetail CRUD
        public IEnumerable<DepartamentDetail> AllDepartamentDetail(int queryNum, int pageNum)
        {
            try
            {
                var departamentDetails = new List<DepartamentDetail>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).ToList();

                }
                return departamentDetails;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public IEnumerable<DepartamentDetail> AllDepartamentDetailSite(int queryNum, int pageNum)
        {
            try
            {
                var departamentDetails = new List<DepartamentDetail>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted")
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted").Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    departamentDetails = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted").ToList();

                }
                return departamentDetails;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public int CreateDepartamentDetail(DepartamentDetail departamentDetail)
        {
            try
            {
                if (departamentDetail == null)
                {
                    return 0;
                }
                _context.departament_details_20ts24tu.Add(departamentDetail);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(departamentDetail));

                return departamentDetail.id;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return 0;
            }
        }

        public bool DeleteDepartamentDetail(int id)
        {
            try
            {
                var departamentDetail = GetDepartamentDetailById(id);
                if (departamentDetail == null)
                {
                    return false;
                }
                departamentDetail.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.departament_details_20ts24tu.Update(departamentDetail);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(departamentDetail));

                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return false;
            }
        }

        public DepartamentDetail GetDepartamentDetailById(int id)
        {
            try
            {
                var departamentDetail = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return departamentDetail;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public DepartamentDetail GetDepartamentDetailByIdSite(int id)
        {
            try
            {
                var departamentDetail = _context.departament_details_20ts24tu
                        .Include(x => x.departament_).ThenInclude(y => y.departament_type_)
                        .Include(x => x.status_).Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));

                return departamentDetail;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public bool UpdateDepartamentDetail(int id, DepartamentDetail departamentDetail)
        {

            try
            {
                var dbcheck = GetDepartamentDetailById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.text_json = departamentDetail.text_json;
                dbcheck.departament_id = departamentDetail.departament_id;
                dbcheck.status_id = departamentDetail.status_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(departamentDetail));
                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return false;
            }

        }







        //DepartamentDetailTranslation CRUD
        public IEnumerable<DepartamentDetailTranslation> AllDepartamentDetailTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var departamentDetailTranslations = new List<DepartamentDetailTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                        .Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (queryNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null).ToList();

                }
                return departamentDetailTranslations;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public IEnumerable<DepartamentDetailTranslation> AllDepartamentDetailTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var departamentDetailTranslations = new List<DepartamentDetailTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_)
                        .Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                                            .Where(x => x.status_translation_.status != "Deleted")

                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                                            .Where(x => x.status_translation_.status != "Deleted")

                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (queryNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    departamentDetailTranslations = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                                            .Where(x => x.status_translation_.status != "Deleted")

                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null).ToList();

                }
                return departamentDetailTranslations;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public int CreateDepartamentDetailTranslation(DepartamentDetailTranslation departamentDetailTranslation)
        {
            try
            {
                if (departamentDetailTranslation == null)
                {
                    return 0;
                }
                _context.departament_details_translations_20ts24tu.Add(departamentDetailTranslation);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(departamentDetailTranslation));

                return departamentDetailTranslation.id;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return 0;
            }
        }

        public bool DeleteDepartamentDetailTranslation(int id)
        {
            try
            {
                var departamentDetailTranslation = GetDepartamentDetailTranslationById(id);
                if (departamentDetailTranslation == null)
                {
                    return false;
                }
                departamentDetailTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == departamentDetailTranslation.language_id)).id;
                _context.departament_details_translations_20ts24tu.Update(departamentDetailTranslation);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(departamentDetailTranslation));

                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return false;
            }
        }

        public DepartamentDetailTranslation GetDepartamentDetailTranslationById(int id)
        {
            try
            {
                var departamentDetailTranslation = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return departamentDetailTranslation;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public DepartamentDetailTranslation GetDepartamentDetailTranslationById(int uz_id, string language_code)
        {
            try
            {
                var departamentDetailTranslation = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_).FirstOrDefault(x => x.departament_detail_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return departamentDetailTranslation;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public DepartamentDetailTranslation GetDepartamentDetailTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var departamentDetailTranslation = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.departament_detail_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return departamentDetailTranslation;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public DepartamentDetailTranslation GetDepartamentDetailTranslationByIdSite(int id)
        {
            try
            {
                var departamentDetailTranslation = _context.departament_details_translations_20ts24tu.Include(x => x.language_)
                        .Include(x => x.departament_translation_).ThenInclude(y => y.departament_type_translation_).Include(x => x.departament_detail_)
                        .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.id.Equals(id));
                return departamentDetailTranslation;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return null;
            }
        }

        public bool UpdateDepartamentDetailTranslation(int id, DepartamentDetailTranslation departamentDetailTranslation)
        {

            try
            {
                var dbcheck = GetDepartamentDetailTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.text_json = departamentDetailTranslation.text_json;
                dbcheck.language_id = departamentDetailTranslation.language_id;
                dbcheck.departament_translation_id = departamentDetailTranslation.departament_translation_id;
                dbcheck.departament_detail_id = departamentDetailTranslation.departament_detail_id;
                dbcheck.status_translation_id = departamentDetailTranslation.status_translation_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);

                return false;
            }

        }
        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return false;
            }
        }

    }

}
