using Contracts.AllRepository.StatisticalNumbersRepository;
using Entities.Model.StatisticalNumbersModel;
using Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Model.SitesModel;

namespace Repository.AllSqlRepository.StatisticalsNumbersSqlRepository
{
    public class StatisticalNumbersSqlRepository : IStatisticalNumbersRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<StatisticalNumbersSqlRepository> _logger;
        public StatisticalNumbersSqlRepository(RepositoryContext repositoryContext, ILogger<StatisticalNumbersSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        #region StatisticalNumbers CRUD
        public IEnumerable<StatisticalNumbers> AllStatisticalNumbers(int queryNum, int pageNum)
        {
            try
            {
                var StatisticalNumberss = new List<StatisticalNumbers>();
                if (queryNum == 0 && pageNum != 0)
                {
                    StatisticalNumberss = _context.statistical_numbers_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.icon_)


                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    StatisticalNumberss = _context.statistical_numbers_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.icon_)

                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    StatisticalNumberss = _context.statistical_numbers_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.icon_)

                       .ToList();

                }
                return StatisticalNumberss;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public IEnumerable<StatisticalNumbers> AllStatisticalNumbersSite(int queryNum, int pageNum)
        {
            try
            {
                var StatisticalNumberss = new List<StatisticalNumbers>();
                if (queryNum == 0 && pageNum != 0)
                {
                    StatisticalNumberss = _context.statistical_numbers_20ts24tu
                        .Include(x => x.icon_)

                        .Where(x => x.status_.status != "Deleted")

                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    StatisticalNumberss = _context.statistical_numbers_20ts24tu
                        .Include(x => x.icon_)

                        .Where(x => x.status_.status != "Deleted")
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    StatisticalNumberss = _context.statistical_numbers_20ts24tu
                        .Include(x => x.icon_)

                        .Where(x => x.status_.status != "Deleted")
                       .ToList();

                }
                return StatisticalNumberss;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public int CreateStatisticalNumbers(StatisticalNumbers StatisticalNumbers)
        {
            try
            {
                if (StatisticalNumbers == null)
                {
                    return 0;
                }
                _context.statistical_numbers_20ts24tu.Add(StatisticalNumbers);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                int id = StatisticalNumbers.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(StatisticalNumbers));

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeleteStatisticalNumbers(int id)
        {
            try
            {
                var emp = GetStatisticalNumbersById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.statistical_numbers_20ts24tu.Update(emp);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public StatisticalNumbers GetStatisticalNumbersById(int id)
        {
            try
            {
                var StatisticalNumbers = _context.statistical_numbers_20ts24tu
                    .Include(x => x.status_)
                        .Include(x => x.icon_)

                        .FirstOrDefault(x => x.id.Equals(id));

                return StatisticalNumbers;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public StatisticalNumbers GetStatisticalNumbersByIdSite(int id)
        {
            try
            {
                var StatisticalNumbers = _context.statistical_numbers_20ts24tu
                    .Include(x => x.icon_)

                        .Where(x => x.status_.status != "Deleted")
                        .FirstOrDefault(x => x.id.Equals(id));

                return StatisticalNumbers;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdateStatisticalNumbers(int id, StatisticalNumbers StatisticalNumbers)
        {

            try
            {
                var dbcheck = GetStatisticalNumbersById(id);
                if (dbcheck is null)
                {
                    return false;
                }

                dbcheck.title = StatisticalNumbers.title;
                dbcheck.description = StatisticalNumbers.description;
                dbcheck.numbers = StatisticalNumbers.numbers;
                if (StatisticalNumbers.icon_ != null)
                {
                    dbcheck.icon_ = StatisticalNumbers.icon_;
                }

                dbcheck.status_id = StatisticalNumbers.status_id;

                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }


        #endregion




        #region StatisticalNumbersTranslation CRUD
        public IEnumerable<StatisticalNumbersTranslation> AllStatisticalNumbersTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var StatisticalNumbersTranslations = new List<StatisticalNumbersTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    StatisticalNumbersTranslations = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    StatisticalNumbersTranslations = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    StatisticalNumbersTranslations = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)
                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return StatisticalNumbersTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public IEnumerable<StatisticalNumbersTranslation> AllStatisticalNumbersTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var StatisticalNumbersTranslations = new List<StatisticalNumbersTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    StatisticalNumbersTranslations = _context.statistical_numbers_translations_20ts24tu
                       .Include(x => x.statistical_numbers_)

                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    StatisticalNumbersTranslations = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)

                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    StatisticalNumbersTranslations = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)

                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return StatisticalNumbersTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public int CreateStatisticalNumbersTranslation(StatisticalNumbersTranslation StatisticalNumbersTranslation)
        {
            try
            {
                if (StatisticalNumbersTranslation == null)
                {
                    return 0;
                }
                _context.statistical_numbers_translations_20ts24tu.Add(StatisticalNumbersTranslation);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                var id = StatisticalNumbersTranslation.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(StatisticalNumbersTranslation));
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeleteStatisticalNumbersTranslation(int id)
        {
            try
            {
                var emp = GetStatisticalNumbersTranslationById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_translation_id = (_context.statuses_translations_20ts24tu
                    .FirstOrDefault(x => x.status == "Deleted" && x.language_id == emp.language_id)).id;
                _context.statistical_numbers_translations_20ts24tu.Update(emp);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationById(int id)
        {
            try
            {
                var StatisticalNumbersTranslation = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)

                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .FirstOrDefault(x => x.id.Equals(id));
                return StatisticalNumbersTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationById(int uz_id, string language_code)
        {
            try
            {
                var StatisticalNumbersTranslation = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)

                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .FirstOrDefault(x => x.statistical_numbers_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return StatisticalNumbersTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var StatisticalNumbersTranslation = _context.statistical_numbers_translations_20ts24tu
                        .Include(x => x.statistical_numbers_)

                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.statistical_numbers_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return StatisticalNumbersTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public StatisticalNumbersTranslation GetStatisticalNumbersTranslationByIdSite(int id)
        {
            try
            {
                var StatisticalNumbersTranslation = _context.statistical_numbers_translations_20ts24tu
                    .Include(x => x.statistical_numbers_)

                        .Include(x => x.icon_)
                        .Include(x => x.language_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.id.Equals(id));
                return StatisticalNumbersTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdateStatisticalNumbersTranslation(int id, StatisticalNumbersTranslation StatisticalNumbers)
        {

            try
            {
                var dbcheck = GetStatisticalNumbersTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }

                dbcheck.title = StatisticalNumbers.title;
                dbcheck.description = StatisticalNumbers.description;
                dbcheck.numbers = StatisticalNumbers.numbers;
                if (StatisticalNumbers.icon_ != null)
                {
                    dbcheck.icon_ = StatisticalNumbers.icon_;
                }
                dbcheck.statistical_numbers_id = StatisticalNumbers.statistical_numbers_id;
                dbcheck.language_id = StatisticalNumbers.language_id;
                dbcheck.status_translation_id = StatisticalNumbers.status_translation_id;

                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
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
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }
    }
}
