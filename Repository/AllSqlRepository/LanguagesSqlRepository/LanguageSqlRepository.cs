using Contracts.AllRepository.LanguagesRepository;
using Contracts.AllRepository.StatusesRepository;
using Entities;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.LanguagesSqlRepository;

public class LanguageSqlRepository : ILanguageRepository
{

    private readonly RepositoryContext _context;
    private readonly IStatusRepositoryStatic _status;
    private readonly ILogger<LanguageSqlRepository> _logger;
    public LanguageSqlRepository(RepositoryContext repositoryContext, ILogger<LanguageSqlRepository> logger, IStatusRepositoryStatic _status1)
    {
        _context = repositoryContext;
        _logger = logger;
        _status = _status1;
    }


    public IEnumerable<Language> AllLanguage(int queryNum, int pageNum)
    {
        try
        {
            var languages = new List<Language>();
            if (queryNum == 0 && pageNum != 0)
            {
                languages = _context.languages_20ts24tu.Include(x => x.status_).Include(x => x.img_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                languages = _context.languages_20ts24tu.Include(x => x.status_).Include(x => x.img_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                languages = _context.languages_20ts24tu.Include(x => x.status_).Include(x => x.img_).ToList();

            }
            return languages;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Language> AllLanguageSite(int queryNum, int pageNum)
    {
        try
        {
            var languages = new List<Language>();
            if (queryNum == 0 && pageNum != 0)
            {
                languages = _context.languages_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.img_).Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            else if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                languages = _context.languages_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.img_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                languages = _context.languages_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.img_).ToList();

            }
            return languages;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateLanguage(Language language)
    {
        try
        {
            if (language == null)
            {
                return 0;
            }
            _context.languages_20ts24tu.Add(language);
            _context.SaveChanges();

            try
            {
                StatusTranslation statusTranslation = new StatusTranslation()
                {
                    status = "Active",
                    name = "Active",
                    is_deleted = false,
                    status_id = _status.GetStatusId("Active"),
                    language_id = language.id,
                };
                _context.statuses_translations_20ts24tu.Add(statusTranslation);

                StatusTranslation statusTranslation1 = new StatusTranslation()
                {
                    status = "Deleted",
                    name = "Deleted",
                    is_deleted = false,
                    status_id = _status.GetStatusId("Deleted"),
                    language_id = language.id,
                };
                _context.statuses_translations_20ts24tu.Add(statusTranslation1);
                _context.SaveChanges();
            }
            catch
            {

                return 0;
            }


            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(language));

            return language.id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteLanguage(int id)
    {
        try
        {
            var language = GetLanguageById(id);
            if (language == null)
            {
                return false;
            }
            language.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.languages_20ts24tu.Update(language);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(language));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Language GetLanguageById(int id)
    {
        try
        {
            var language = _context.languages_20ts24tu.Include(x => x.status_).Include(x => x.img_).FirstOrDefault(x => x.id.Equals(id));
            return language;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public Language GetLanguageByIdSite(int id)
    {
        try
        {
            var language = _context.languages_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Include(x => x.img_).FirstOrDefault(x => x.id.Equals(id));
            return language;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateLanguage(int id, Language language)
    {

        try
        {
            var dbcheck = GetLanguageById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title = language.title;
            dbcheck.title_short = language.title_short;
            dbcheck.description = language.description;
            dbcheck.code = language.code;
            dbcheck.details = language.details;
            if (language.img_ != null)
            {
                dbcheck.img_ = language.img_;
            }
            
            dbcheck.status_id = language.status_id;
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
