using Contracts.AllRepository.GendersRepository;
using Entities;
using Entities.Model.GenderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.GendersSqlRepository;

public class GenderSqlRepository : IGenderRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<GenderSqlRepository> _logger;
    public GenderSqlRepository(RepositoryContext repositoryContext, ILogger<GenderSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    //Gender CRUD
    public IEnumerable<Gender> AllGender(int queryNum, int pageNum)
    {
        try
        {
            var genders = new List<Gender>();
            if (queryNum == 0 && pageNum != 0)
            {
                genders = _context.genders_20ts24tu.Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                genders = _context.genders_20ts24tu.Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                genders = _context.genders_20ts24tu.Include(x => x.status_).ToList();

            }
            return genders;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Gender> AllGenderSite(int queryNum, int pageNum)
    {
        try
        {
            var genders = new List<Gender>();
            if (queryNum == 0 && pageNum != 0)
            {
                genders = _context.genders_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                genders = _context.genders_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                genders = _context.genders_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).ToList();

            }
            return genders;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateGender(Gender gender)
    {
        try
        {
            if (gender == null)
            {
                return 0;
            }
            _context.genders_20ts24tu.Add(gender);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(gender));

            return gender.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteGender(int id)
    {
        try
        {
            var gender = GetGenderById(id);
            if (gender == null)
            {
                return false;
            }
            gender.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.Update(gender);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(gender));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Gender GetGenderById(int id)
    {
        try
        {
            var gender = _context.genders_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return gender;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public Gender GetGenderByIdSite(int id)
    {
        try
        {
            var gender = _context.genders_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return gender;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateGender(int id, Gender gender)
    {

        try
        {
            var dbcheck = GetGenderById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.gender = gender.gender;
            dbcheck.status_id = gender.status_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }







    //GenderTranslation CRUD
    public IEnumerable<GenderTranslation> AllGenderTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var genderTranslations = new List<GenderTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.gender_).
                    Include(x => x.status_translation_).Include(x => x.language_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (queryNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.gender_).
                    Include(x => x.status_translation_).Include(x => x.language_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.gender_).
                    Include(x => x.status_translation_).Include(x => x.language_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return genderTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<GenderTranslation> AllGenderTranslationSite(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var genderTranslations = new List<GenderTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.gender_).
                    Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted").Include(x => x.language_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(10 * (queryNum - 1))
                    .Take(10)
                    .ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.gender_).
                    Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted").Include(x => x.language_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                    .ToList();

            }
            else
            {
                genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.gender_).
                    Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted").Include(x => x.language_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();

            }
            return genderTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateGenderTranslation(GenderTranslation genderTranslation)
    {
        try
        {
            if (genderTranslation == null)
            {
                return 0;
            }
            _context.genders_translations_20ts24tu.Add(genderTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(genderTranslation));

            return genderTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteGenderTranslation(int id)
    {
        try
        {
            var genderTranslation = GetGenderTranslationById(id);
            if (genderTranslation == null)
            {
                return false;
            }
            genderTranslation.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == genderTranslation.language_id)).id;
            _context.genders_translations_20ts24tu.Update(genderTranslation);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(genderTranslation));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public GenderTranslation GetGenderTranslationById(int id)
    {
        try
        {
            var genderTranslation = _context.genders_translations_20ts24tu.Include(x => x.gender_).Include(x => x.status_translation_).Include(x => x.language_).FirstOrDefault(x => x.id.Equals(id));
            return genderTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public GenderTranslation GetGenderTranslationById(int uz_id, string language_code)
    {
        try
        {
            var genderTranslation = _context.genders_translations_20ts24tu.Include(x => x.gender_).Include(x => x.status_translation_).Include(x => x.language_).FirstOrDefault(x => x.gender_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return genderTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public GenderTranslation GetGenderTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var genderTranslation = _context.genders_translations_20ts24tu.Include(x => x.gender_).Include(x => x.status_translation_).Include(x => x.language_)
                    .Where(x => x.status_translation_.status != "Deleted")
                .FirstOrDefault(x => x.gender_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return genderTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public GenderTranslation GetGenderTranslationByIdSite(int id)
    {
        try
        {
            var genderTranslation = _context.genders_translations_20ts24tu.Where(x => x.status_translation_.status != "Deleted").Include(x => x.gender_).Include(x => x.status_translation_).Include(x => x.language_).FirstOrDefault(x => x.id.Equals(id));
            return genderTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateGenderTranslation(int id, GenderTranslation gender)
    {

        try
        {
            var dbcheck = GetGenderTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.gender = gender.gender;
            dbcheck.gender_id = gender.gender_id;
            dbcheck.language_id = gender.language_id;
            dbcheck.status_translation_id = gender.status_translation_id;
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
