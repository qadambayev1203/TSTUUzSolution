using Contracts.AllRepository.DepartamentsTypeRepository;
using Entities.Model.DepartamentsTypeModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.DepartamentsTypeSqlRepository;

public class DepartamentTypeSqlRepository : IDepartamentTypeRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<DepartamentTypeSqlRepository> _logger;
    public DepartamentTypeSqlRepository(RepositoryContext repositoryContext, ILogger<DepartamentTypeSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    //DepartamentType CRUD
    public IEnumerable<DepartamentType> AllDepartamentType(int queryNum, int pageNum)
    {
        try
        {
            var departamentTypes = new List<DepartamentType>();
            if (queryNum == 0 && pageNum != 0)
            {
                departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).ToList();

            }
            return departamentTypes;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<DepartamentType> AllDepartamentTypeSite(int queryNum, int pageNum)
    {
        try
        {
            var departamentTypes = new List<DepartamentType>();
            if (queryNum == 0 && pageNum != 0)
            {
                departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Where(x => x.status_.status != "Deleted").Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Where(x => x.status_.status != "Deleted").Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                departamentTypes = _context.departament_types_20ts24tu.Include(x => x.status_).Where(x => x.status_.status != "Deleted").ToList();

            }
            return departamentTypes;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateDepartamentType(DepartamentType departamentType)
    {
        try
        {
            if (departamentType == null)
            {
                return 0;
            }
            _context.departament_types_20ts24tu.Add(departamentType);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(departamentType));

            return departamentType.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteDepartamentType(int id)
    {
        try
        {
            var departamentType = GetDepartamentTypeById(id);
            if (departamentType == null)
            {
                return false;
            }
            departamentType.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.departament_types_20ts24tu.Update(departamentType);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(departamentType));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public DepartamentType GetDepartamentTypeById(int id)
    {
        try
        {
            var departamentType = _context.departament_types_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return departamentType;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public DepartamentType GetDepartamentTypeByIdSite(int id)
    {
        try
        {
            var departamentType = _context.departament_types_20ts24tu.Include(x => x.status_).Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));

            return departamentType;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateDepartamentType(int id, DepartamentType departamentType)
    {

        try
        {
            var dbcheck = GetDepartamentTypeById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.type = departamentType.type;
            dbcheck.status_id = departamentType.status_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(departamentType));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }







    //DepartamentTypeTranslation CRUD
    public IEnumerable<DepartamentTypeTranslation> AllDepartamentTypeTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var departamentTypeTranslations = new List<DepartamentTypeTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (queryNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (queryNum - 1))
                    .Take(queryNum)
                    .ToList();

            }
            else
            {
                departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null).ToList();

            }
            return departamentTypeTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<DepartamentTypeTranslation> AllDepartamentTypeTranslationSite(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var departamentTypeTranslations = new List<DepartamentTypeTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (queryNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (queryNum - 1))
                    .Take(queryNum)
                    .ToList();

            }
            else
            {
                departamentTypeTranslations = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null).ToList();

            }
            return departamentTypeTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateDepartamentTypeTranslation(DepartamentTypeTranslation departamentTypeTranslation)
    {
        try
        {
            if (departamentTypeTranslation == null)
            {
                return 0;
            }
            _context.departament_types_translations_20ts24tu.Add(departamentTypeTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(departamentTypeTranslation));

            return departamentTypeTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteDepartamentTypeTranslation(int id)
    {
        try
        {
            var departamentTypeTranslation = GetDepartamentTypeTranslationById(id);
            if (departamentTypeTranslation == null)
            {
                return false;
            }
            departamentTypeTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == departamentTypeTranslation.language_id)).id;
            _context.departament_types_translations_20ts24tu.Update(departamentTypeTranslation);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(departamentTypeTranslation));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public DepartamentTypeTranslation GetDepartamentTypeTranslationById(int id)
    {
        try
        {
            var departamentTypeTranslation = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
            return departamentTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public DepartamentTypeTranslation GetDepartamentTypeTranslationById(int uz_id, string language_code)
    {
        try
        {
            var departamentTypeTranslation = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_).FirstOrDefault(x => x.departament_type_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return departamentTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public DepartamentTypeTranslation GetDepartamentTypeTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var departamentTypeTranslation = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.departament_type_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return departamentTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public DepartamentTypeTranslation GetDepartamentTypeTranslationByIdSite(int id)
    {
        try
        {
            var departamentTypeTranslation = _context.departament_types_translations_20ts24tu.Include(x => x.language_)
                    .Include(x => x.departament_type_).Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));
            return departamentTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateDepartamentTypeTranslation(int id, DepartamentTypeTranslation departamentType)
    {

        try
        {
            var dbcheck = GetDepartamentTypeTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.type = departamentType.type;
            dbcheck.language_id = departamentType.language_id;
            dbcheck.departament_type_id = departamentType.departament_type_id;
            dbcheck.status_translation_id = departamentType.status_translation_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message); return false;
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
