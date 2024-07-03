using Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Repository.AllSqlRepository.EmployeeTypesSqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.EmployeeTypesModel;
using Contracts.AllRepository.EmployeesRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.EmployeeTypesSqlRepository
{
    public class EmployeeTypeSqlRepository : IEmployeeTypeRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<EmployeeTypeSqlRepository> _logger;
        public EmployeeTypeSqlRepository(RepositoryContext repositoryContext, ILogger<EmployeeTypeSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        #region EmployeeType CRUD
        public IEnumerable<EmployeeType> AllEmployeeType(int queryNum, int pageNum)
        {
            try
            {
                var EmployeeTypes = new List<EmployeeType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    EmployeeTypes = _context.employee_types_20ts24tu.Include(x => x.status_)

                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    EmployeeTypes = _context.employee_types_20ts24tu.Include(x => x.status_)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    EmployeeTypes = _context.employee_types_20ts24tu.Include(x => x.status_)
                       .ToList();

                }
                return EmployeeTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public IEnumerable<EmployeeType> AllEmployeeTypeSite(int queryNum, int pageNum)
        {
            try
            {
                var EmployeeTypes = new List<EmployeeType>();
                if (queryNum == 0 && pageNum != 0)
                {
                    EmployeeTypes = _context.employee_types_20ts24tu.Where(x => x.status_.status != "Deleted")

                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    EmployeeTypes = _context.employee_types_20ts24tu.Where(x => x.status_.status != "Deleted")
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    EmployeeTypes = _context.employee_types_20ts24tu.Where(x => x.status_.status != "Deleted")
                       .ToList();

                }
                return EmployeeTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public int CreateEmployeeType(EmployeeType EmployeeType)
        {
            try
            {
                if (EmployeeType == null)
                {
                    return 0;
                }
                _context.employee_types_20ts24tu.Add(EmployeeType);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                int id = EmployeeType.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(EmployeeType));

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeleteEmployeeType(int id)
        {
            try
            {
                var emp = GetEmployeeTypeById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.employee_types_20ts24tu.Update(emp);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public EmployeeType GetEmployeeTypeById(int id)
        {
            try
            {
                var EmployeeType = _context.employee_types_20ts24tu.Include(x => x.status_)
                        .FirstOrDefault(x => x.id.Equals(id));

                return EmployeeType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public EmployeeType GetEmployeeTypeByIdSite(int id)
        {
            try
            {
                var EmployeeType = _context.employee_types_20ts24tu.Where(x => x.status_.status != "Deleted")
                        .FirstOrDefault(x => x.id.Equals(id));

                return EmployeeType;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdateEmployeeType(int id, EmployeeType employeeType)
        {

            try
            {
                var dbcheck = GetEmployeeTypeById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.title = employeeType.title;
                dbcheck.status_id = employeeType.status_id;
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




        #region EmployeeTypeTranslation CRUD
        public IEnumerable<EmployeeTypeTranslation> AllEmployeeTypeTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var EmployeeTypeTranslations = new List<EmployeeTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    EmployeeTypeTranslations = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employee_)
                        .Include(x => x.status_translation_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    EmployeeTypeTranslations = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employee_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    EmployeeTypeTranslations = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employee_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return EmployeeTypeTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public IEnumerable<EmployeeTypeTranslation> AllEmployeeTypeTranslationSite(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var EmployeeTypeTranslations = new List<EmployeeTypeTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    EmployeeTypeTranslations = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employee_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    EmployeeTypeTranslations = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employee_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    EmployeeTypeTranslations = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.employee_).Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return EmployeeTypeTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }


        public int CreateEmployeeTypeTranslation(EmployeeTypeTranslation EmployeeTypeTranslation)
        {
            try
            {
                if (EmployeeTypeTranslation == null)
                {
                    return 0;
                }
                _context.employee_types_translations_20ts24tu.Add(EmployeeTypeTranslation);
                bool check = SaveChanges();
                if (!check)
                {
                    return 0;
                }
                var id = EmployeeTypeTranslation.id;
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(EmployeeTypeTranslation));
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return 0;
            }
        }

        public bool DeleteEmployeeTypeTranslation(int id)
        {
            try
            {
                var emp = GetEmployeeTypeTranslationById(id);
                if (emp == null)
                {
                    return false;
                }
                emp.status_translation_id = (_context.statuses_translations_20ts24tu
                    .FirstOrDefault(x => x.status == "Deleted" && x.language_id == emp.language_id)).id;
                _context.employee_types_translations_20ts24tu.Update(emp);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return false;
            }
        }

        public EmployeeTypeTranslation GetEmployeeTypeTranslationById(int id)
        {
            try
            {
                var EmployeeTypeTranslation = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_).Include(x => x.status_translation_)
                        .Include(x => x.employee_).FirstOrDefault(x => x.id.Equals(id));
                return EmployeeTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }
        public EmployeeTypeTranslation GetEmployeeTypeTranslationById(int uz_id, string language_code)
        {
            try
            {
                var EmployeeTypeTranslation = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_).Include(x => x.status_translation_)
                        .Include(x => x.employee_).FirstOrDefault(x => x.employee_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return EmployeeTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public EmployeeTypeTranslation GetEmployeeTypeTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var EmployeeTypeTranslation = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_).Include(x => x.status_translation_)
                        .Include(x => x.employee_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.employee_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return EmployeeTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public EmployeeTypeTranslation GetEmployeeTypeTranslationByIdSite(int id)
        {
            try
            {
                var EmployeeTypeTranslation = _context.employee_types_translations_20ts24tu
                        .Include(x => x.language_).Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.employee_).FirstOrDefault(x => x.id.Equals(id));
                return EmployeeTypeTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error " + ex.ToString());
                return null;
            }
        }

        public bool UpdateEmployeeTypeTranslation(int id, EmployeeTypeTranslation employeeType)
        {

            try
            {
                var dbcheck = GetEmployeeTypeTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.employee_id = employeeType.employee_id;
                dbcheck.title = employeeType.title;
                dbcheck.language_id = employeeType.language_id;
                dbcheck.status_translation_id = employeeType.status_translation_id;
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
