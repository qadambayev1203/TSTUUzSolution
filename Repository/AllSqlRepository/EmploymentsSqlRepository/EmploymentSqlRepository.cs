using Contracts.AllRepository.EmploymentsRepsitory;
using Entities.Model.EmploymentModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.EmploymentsSqlRepository;

public class EmploymentSqlRepository : IEmploymentRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<EmploymentSqlRepository> _logger;
    public EmploymentSqlRepository(RepositoryContext repositoryContext, ILogger<EmploymentSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    #region Employment CRUD
    public IEnumerable<Employment> AllEmployment(int queryNum, int pageNum)
    {
        try
        {
            var Employments = new List<Employment>();
            if (queryNum == 0 && pageNum != 0)
            {
                Employments = _context.employments_20ts24tu.Include(x => x.status_)

                    .Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                Employments = _context.employments_20ts24tu.Include(x => x.status_)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                Employments = _context.employments_20ts24tu.Include(x => x.status_)
                   .ToList();

            }
            return Employments;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Employment> AllEmploymentSite(int queryNum, int pageNum)
    {
        try
        {
            var Employments = new List<Employment>();
            if (queryNum == 0 && pageNum != 0)
            {
                Employments = _context.employments_20ts24tu.Where(x => x.status_.status != "Deleted")

                    .Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                Employments = _context.employments_20ts24tu.Where(x => x.status_.status != "Deleted")
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                Employments = _context.employments_20ts24tu.Where(x => x.status_.status != "Deleted")
                   .ToList();

            }
            return Employments;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateEmployment(Employment Employment)
    {
        try
        {
            if (Employment == null)
            {
                return 0;
            }
            _context.employments_20ts24tu.Add(Employment);
            bool check = SaveChanges();
            if (!check)
            {
                return 0;
            }
            int id = Employment.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(Employment));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteEmployment(int id)
    {
        try
        {
            var emp = GetEmploymentById(id);
            if (emp == null)
            {
                return false;
            }
            emp.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.employments_20ts24tu.Update(emp);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Employment GetEmploymentById(int id)
    {
        try
        {
            var Employment = _context.employments_20ts24tu.Include(x => x.status_)
                    .FirstOrDefault(x => x.id.Equals(id));

            return Employment;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public Employment GetEmploymentByIdSite(int id)
    {
        try
        {
            var Employment = _context.employments_20ts24tu.Where(x => x.status_.status != "Deleted")
                    .FirstOrDefault(x => x.id.Equals(id));

            return Employment;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateEmployment(int id, Employment employment)
    {

        try
        {
            var dbcheck = GetEmploymentById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title = employment.title;
            dbcheck.status_id = employment.status_id;
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




    #region EmploymentTranslation CRUD
    public IEnumerable<EmploymentTranslation> AllEmploymentTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var EmploymentTranslations = new List<EmploymentTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                EmploymentTranslations = _context.employments_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.employment_)
                    .Include(x => x.status_translation_)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            if (queryNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                EmploymentTranslations = _context.employments_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.employment_)
                    .Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1))
                    .Take(queryNum)
                    .ToList();

            }
            else
            {
                EmploymentTranslations = _context.employments_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.employment_)
                    .Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return EmploymentTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<EmploymentTranslation> AllEmploymentTranslationSite(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var EmploymentTranslations = new List<EmploymentTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                EmploymentTranslations = _context.employments_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.employment_)
                    .Skip(10 * (pageNum - 1))
                    .Take(10).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            if (queryNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                EmploymentTranslations = _context.employments_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.employment_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1))
                    .Take(queryNum)
                    .ToList();

            }
            else
            {
                EmploymentTranslations = _context.employments_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.employment_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return EmploymentTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }


    public int CreateEmploymentTranslation(EmploymentTranslation EmploymentTranslation)
    {
        try
        {
            if (EmploymentTranslation == null)
            {
                return 0;
            }
            _context.employments_translations_20ts24tu.Add(EmploymentTranslation);
            bool check = SaveChanges();
            if (!check)
            {
                return 0;
            }
            var id = EmploymentTranslation.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(EmploymentTranslation));
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteEmploymentTranslation(int id)
    {
        try
        {
            var emp = GetEmploymentTranslationById(id);
            if (emp == null)
            {
                return false;
            }
            emp.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == emp.language_id)).id;
            _context.employments_translations_20ts24tu.Update(emp);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(emp));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public EmploymentTranslation GetEmploymentTranslationById(int id)
    {
        try
        {
            var EmploymentTranslation = _context.employments_translations_20ts24tu
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Include(x => x.employment_).FirstOrDefault(x => x.id.Equals(id));
            return EmploymentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public EmploymentTranslation GetEmploymentTranslationById(int uz_id, string language_code)
    {
        try
        {
            var EmploymentTranslation = _context.employments_translations_20ts24tu
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Include(x => x.employment_).FirstOrDefault(x => x.employment_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return EmploymentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public EmploymentTranslation GetEmploymentTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var EmploymentTranslation = _context.employments_translations_20ts24tu
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Include(x => x.employment_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.employment_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return EmploymentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public EmploymentTranslation GetEmploymentTranslationByIdSite(int id)
    {
        try
        {
            var EmploymentTranslation = _context.employments_translations_20ts24tu
                    .Include(x => x.language_).Where(x => x.status_translation_.status != "Deleted")
                    .Include(x => x.employment_).FirstOrDefault(x => x.id.Equals(id));
            return EmploymentTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateEmploymentTranslation(int id, EmploymentTranslation employment)
    {

        try
        {
            var dbcheck = GetEmploymentTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.employment_id = employment.employment_id;
            dbcheck.title = employment.title;
            dbcheck.language_id = employment.language_id;
            dbcheck.status_translation_id = employment.status_translation_id;
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
