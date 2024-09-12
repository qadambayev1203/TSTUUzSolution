using Contracts.AllRepository.UserTypesRepository;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.UserTypesSqlRepository;

public class UserTypeSqlRepository : IUserTypeRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<UserTypeSqlRepository> _logger;
    public UserTypeSqlRepository(RepositoryContext repositoryContext, ILogger<UserTypeSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }


    //UserType CRUD
    public IEnumerable<UserType> AllUserTypeSelect(int queryNum, int pageNum)
    {
        try
        {
            var userTypes = new List<UserType>();
            if (queryNum == 0 && pageNum != 0)
            {
                userTypes = _context.user_types_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                userTypes = _context.user_types_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                userTypes = _context.user_types_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).ToList();

            }
            return userTypes;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public IEnumerable<UserType> AllUserType(int queryNum, int pageNum)
    {
        try
        {
            var userTypes = new List<UserType>();
            if (queryNum == 0 && pageNum != 0)
            {
                userTypes = _context.user_types_20ts24tu.Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                userTypes = _context.user_types_20ts24tu.Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                userTypes = _context.user_types_20ts24tu.Include(x => x.status_).ToList();

            }
            return userTypes;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateUserType(UserType userType)
    {
        try
        {
            if (userType == null)
            {
                return 0;
            }
            _context.user_types_20ts24tu.Add(userType);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(userType));

            return userType.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteUserType(int id)
    {
        try
        {
            var userType = GetUserTypeById(id);
            if (userType == null)
            {
                return false;
            }
            userType.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.user_types_20ts24tu.Update(userType);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(userType));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public UserType GetUserTypeByIdSelect(int id)
    {
        try
        {
            var userType = _context.user_types_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
            return userType;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public UserType GetUserTypeById(int id)
    {
        try
        {
            var userType = _context.user_types_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
            return userType;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateUserType(int id, UserType user)
    {
        try
        {
            var dbcheck = GetUserTypeById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.type = user.type;
            dbcheck.status_id = user.status_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }






    //UserTypeTranslation CRUD
    public IEnumerable<UserTypeTranslation> AllUserTypeTranslationSelect(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var userTypesTranslation = new List<UserTypeTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                    .Include(x => x.language_).Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (queryNum - 1))
                    .Take(10)
                    .ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                    .Include(x => x.language_).Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                    .Include(x => x.language_).Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return userTypesTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public IEnumerable<UserTypeTranslation> AllUserTypeTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var userTypesTranslation = new List<UserTypeTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                     .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                userTypesTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_)
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return userTypesTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateUserTypeTranslation(UserTypeTranslation userTypeTranslation)
    {
        try
        {
            if (userTypeTranslation == null)
            {
                return 0;
            }
            _context.user_types_translations_20ts24tu.Add(userTypeTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(userTypeTranslation));

            return userTypeTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteUserTypeTranslation(int id)
    {
        try
        {
            var userTypeTranslation = GetUserTypeTranslationById(id);
            if (userTypeTranslation == null)
            {
                return false;
            }
            userTypeTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == userTypeTranslation.language_id)).id;
            _context.user_types_translations_20ts24tu.Update(userTypeTranslation);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(userTypeTranslation));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public UserTypeTranslation GetUserTypeTranslationByIdSelect(int id)
    {
        try
        {
            var userTypeTranslation = _context.user_types_translations_20ts24tu.Where(x => x.status_translation_.status != "Deleted").Include(x => x.user_types_).Include(x => x.language_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
            return userTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public UserTypeTranslation GetUserTypeTranslationById(int id)
    {
        try
        {
            var userTypeTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_).Include(x => x.language_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
            return userTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public UserTypeTranslation GetUserTypeTranslationById(int uz_id, string language_code)
    {
        try
        {
            var userTypeTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_).Include(x => x.language_).Include(x => x.status_translation_)
                .FirstOrDefault(x => x.user_types_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return userTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public UserTypeTranslation GetUserTypeTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var userTypeTranslation = _context.user_types_translations_20ts24tu.Include(x => x.user_types_).Include(x => x.language_).Include(x => x.status_translation_)
                .Where(x => x.status_translation_.status != "Deleted")
                .FirstOrDefault(x => x.user_types_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return userTypeTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateUserTypeTranslation(int id, UserTypeTranslation userType)
    {
        try
        {
            var dbcheck = GetUserTypeTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.type = userType.type;
            dbcheck.user_types_id = userType.user_types_id;
            dbcheck.language_id = userType.language_id;
            dbcheck.status_translation_id = userType.status_translation_id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(dbcheck));
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
