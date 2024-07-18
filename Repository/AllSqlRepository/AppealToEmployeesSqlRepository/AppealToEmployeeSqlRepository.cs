using Contracts.AllRepository.AppealToEmployeesRepository;
using Entities;
using Entities.DTO.UserCrudDTOS;
using Entities.Model;
using Entities.Model.AnyClasses;
using Entities.Model.AppealToEmployeeModel;
using Entities.Model.LanguagesModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.AppealToEmployeesSqlRepository
{
    public class AppealToEmployeeSqlRepository : IAppealToEmployeeRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<AppealToEmployeeSqlRepository> _logger;
        public AppealToEmployeeSqlRepository(RepositoryContext repositoryContext, ILogger<AppealToEmployeeSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        #region AppealToEmployee CRUD
        public IEnumerable<AppealToEmployee> AllAppealToEmployee(int queryNum, int pageNum)
        {
            try
            {
                IQueryable<AppealToEmployee> query = _context.appeal_to_employee_20ts24tu
                    .Where(x => x.user_id == SessionClass.id)
                    .Where(x => x.status_.status != "Deleted")
                    .Include(x => x.status_);

                if (pageNum != 0)
                {
                    int takeCount = queryNum != 0 ? Math.Min(queryNum, 200) : 10;
                    query = query.Skip(takeCount * (pageNum - 1)).Take(takeCount);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Enumerable.Empty<AppealToEmployee>();
            }
        }

        public IEnumerable<AppealToEmployee> AllAppealToEmployeeAdmin(int queryNum, int pageNum)
        {
            try
            {
                IQueryable<AppealToEmployee> query = _context.appeal_to_employee_20ts24tu
                    .Include(x => x.status_)
                    .Include(x => x.user_).ThenInclude(y=>y.person_)
                    .Include(x => x.user_).ThenInclude(y=>y.user_type_);

                if (pageNum != 0)
                {
                    int takeCount = queryNum != 0 ? Math.Min(queryNum, 200) : 10;
                    query = query.Skip(takeCount * (pageNum - 1)).Take(takeCount);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Enumerable.Empty<AppealToEmployee>();
            }
        }

        public int CreateAppealToEmployee(AppealToEmployee appealToEmployee, int person_id)
        {
            try
            {
                if (appealToEmployee == null)
                {
                    return 0;
                }

                var user = _context.users_20ts24tu.FirstOrDefault(x => x.person_id == person_id);
                if (user == null)
                {
                    return 0;
                }

                appealToEmployee.user_id = user.id;
                _context.appeal_to_employee_20ts24tu.Add(appealToEmployee);
                _context.SaveChanges();

                _logger.LogInformation($"Created {JsonConvert.SerializeObject(appealToEmployee)}");
                return appealToEmployee.id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return 0;
            }
        }


        public bool DeleteAppealToEmployee(int id)
        {
            try
            {
                var appealToEmployee = GetAppealToEmployeeById(id);
                if (appealToEmployee == null)
                {
                    return false;
                }

                var deletedStatus = _context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted");
                if (deletedStatus == null)
                {
                    _logger.LogError("Status 'Deleted' not found.");
                    return false;
                }

                appealToEmployee.status_id = deletedStatus.id;
                _context.appeal_to_employee_20ts24tu.Update(appealToEmployee);
                _context.SaveChanges();
                _logger.LogInformation($"Deleted {JsonConvert.SerializeObject(appealToEmployee)}");
                return true;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return false;
            }
        }

        public AppealToEmployee GetAppealToEmployeeById(int id)
        {
            try
            {
                var user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
                var appealToEmployee = _context.appeal_to_employee_20ts24tu
                    .Where(x => x.id == id)
                    .Where(x => x.user_id == SessionClass.id || user.user_type_.type == "Admin")
                    .Where(x => x.status_.status != "Deleted" || user.user_type_.type == "Admin")
                    .Include(x => x.status_).FirstOrDefault();

                return appealToEmployee ??= new AppealToEmployee();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return new AppealToEmployee();
            }
        }

        public AppealToEmployee GetAppealToEmployeeByIdAdmin(int id)
        {
            try
            {
                var appealToEmployee = _context.appeal_to_employee_20ts24tu
                    .Where(x => x.id == id)
                    .Include(x => x.status_)
                    .Include(x => x.user_).ThenInclude(y => y.person_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .FirstOrDefault();

                return appealToEmployee ??= new AppealToEmployee();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return new AppealToEmployee();
            }
        }

        public bool UpdateAppealToEmployee(int id, AppealToEmployee appealToEmployee)
        {
            try
            {
                var existingAppealToEmployee = GetAppealToEmployeeById(id);

                if (existingAppealToEmployee == null)
                {
                    return false;
                }


                existingAppealToEmployee.status_id = appealToEmployee.status_id;

                _context.appeal_to_employee_20ts24tu.Update(existingAppealToEmployee);
                _context.SaveChanges();

                _logger.LogInformation($"Updated {JsonConvert.SerializeObject(existingAppealToEmployee)}");
                return true;



            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return false;
            }
        }


        #endregion




        #region AppealToEmployeeTranslation CRUD
        public IEnumerable<AppealToEmployeeTranslation> AllAppealToEmployeeTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                IQueryable<AppealToEmployeeTranslation> query = _context.appeal_to_employee_translation_20ts24tu
                    .Where(x => language_code == null || x.language_.code.Equals(language_code))
                    .Where(x => x.user_id == SessionClass.id)
                    .Where(x => x.status_.status != "Deleted")
                    .Include(x => x.status_)
                    .Include(x => x.language_);

                if (pageNum != 0)
                {
                    int takeCount = queryNum != 0 ? Math.Min(queryNum, 200) : 10;
                    query = query.Skip(takeCount * (pageNum - 1)).Take(takeCount);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Enumerable.Empty<AppealToEmployeeTranslation>();
            }
        }

        public IEnumerable<AppealToEmployeeTranslation> AllAppealToEmployeeTranslationAdmin(int queryNum, int pageNum, string language_code)
        {
            try
            {
                IQueryable<AppealToEmployeeTranslation> query = _context.appeal_to_employee_translation_20ts24tu
                    .Where(x => language_code == null || x.language_.code.Equals(language_code))
                    .Include(x => x.status_)
                    .Include(x => x.user_).ThenInclude(y => y.person_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.language_);

                if (pageNum != 0)
                {
                    int takeCount = queryNum != 0 ? Math.Min(queryNum, 200) : 10;
                    query = query.Skip(takeCount * (pageNum - 1)).Take(takeCount);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Enumerable.Empty<AppealToEmployeeTranslation>();
            }
        }

        public int CreateAppealToEmployeeTranslation(AppealToEmployeeTranslation appealToEmployeeTranslation, int person_id)
        {
            try
            {
                if (appealToEmployeeTranslation == null)
                {
                    return 0;
                }

                var status = _context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Active");
                if (status == null)
                {
                    _logger.LogError("Status 'Active' not found.");
                    return 0;
                }

                appealToEmployeeTranslation.status_id = status.id;

                var user = _context.users_20ts24tu.FirstOrDefault(x => x.person_id == person_id);
                if (user == null)
                {
                    return 0;
                }

                appealToEmployeeTranslation.user_id = user.id;

                _context.appeal_to_employee_translation_20ts24tu.Add(appealToEmployeeTranslation);
                _context.SaveChanges();

                _logger.LogInformation($"Created {JsonConvert.SerializeObject(appealToEmployeeTranslation)}");
                return appealToEmployeeTranslation.id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return 0;
            }
        }

        public bool DeleteAppealToEmployeeTranslation(int id)
        {
            try
            {
                var appealToEmployeeTranslation = GetAppealToEmployeeTranslationById(id);
                ;
                if (appealToEmployeeTranslation == null)
                {
                    return false;
                }

                var deletedStatus = _context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted");
                if (deletedStatus == null)
                {
                    _logger.LogError("Status 'Deleted' not found.");
                    return false;
                }

                appealToEmployeeTranslation.status_id = deletedStatus.id;

                _context.appeal_to_employee_translation_20ts24tu.Update(appealToEmployeeTranslation);
                _context.SaveChanges();

                _logger.LogInformation($"Deleted {JsonConvert.SerializeObject(appealToEmployeeTranslation)}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return false;
            }
        }

        public AppealToEmployeeTranslation GetAppealToEmployeeTranslationById(int id)
        {
            try
            {
                var user = _context.users_20ts24tu.Include(x => x.user_type_).FirstOrDefault(x => x.id == SessionClass.id);
                var appealToEmployeeTranslation = _context.appeal_to_employee_translation_20ts24tu
                    .Where(x => x.id == id)
                    .Where(x => x.user_id == SessionClass.id || user.user_type_.type == "Admin")
                    .Where(x => x.status_.status != "Deleted" || user.user_type_.type == "Admin")
                    .Include(x => x.status_)
                    .Include(x => x.language_)
                    .FirstOrDefault();

                return appealToEmployeeTranslation ??= new AppealToEmployeeTranslation();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return new AppealToEmployeeTranslation();
            }
        }

        public AppealToEmployeeTranslation GetAppealToEmployeeTranslationByIdAdmin(int id)
        {
            try
            {
                var appealToEmployeeTranslation = _context.appeal_to_employee_translation_20ts24tu
                    .Where(x => x.id == id)
                    .Include(x => x.status_)
                    .Include(x => x.user_).ThenInclude(y => y.person_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Include(x => x.language_)
                    .FirstOrDefault();

                return appealToEmployeeTranslation ??= new AppealToEmployeeTranslation();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return new AppealToEmployeeTranslation();
            }
        }

        public bool UpdateAppealToEmployeeTranslation(int id, AppealToEmployeeTranslation appealToEmployeeTranslation)
        {
            try
            {
                var existingAppealToEmployeeTranslation = GetAppealToEmployeeTranslationById(id);
                if (existingAppealToEmployeeTranslation == null)
                {
                    return false;
                }

                existingAppealToEmployeeTranslation.status_id = appealToEmployeeTranslation.status_id;
                _context.appeal_to_employee_translation_20ts24tu.Update(existingAppealToEmployeeTranslation);
                _context.SaveChanges();

                _logger.LogInformation($"Updated {JsonConvert.SerializeObject(existingAppealToEmployeeTranslation)}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
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
                _logger.LogError($"Error" + ex.Message); return false;
            }
        }
                
    }
}
