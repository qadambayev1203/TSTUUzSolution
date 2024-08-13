using Contracts.AllRepository.CountriesRepository;
using Entities.Model.CountrysModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Repository.AllSqlRepository.CountriesSqlRepository;

public class CountrySqlRepository : ICountryRepository
{
    private readonly RepositoryContext _context;
    private readonly ILogger<CountrySqlRepository> _logger;
    public CountrySqlRepository(RepositoryContext repositoryContext, ILogger<CountrySqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    #region Country CRUD
    public IEnumerable<Country> AllCountry()
    {
        try
        {
            var Countrys = new List<Country>();

            Countrys = _context.countries_20ts24tu.Include(x => x.status_).ToList();

            return Countrys;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<Country> AllCountrySite()
    {
        try
        {
            var Countrys = new List<Country>();

            Countrys = _context.countries_20ts24tu.Where(x => x.status_.status != "Deleted").ToList();

            return Countrys;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public int CreateCountry(Country Country)
    {
        try
        {
            if (Country == null)
            {
                return 0;
            }
            _context.countries_20ts24tu.Add(Country);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(Country));
            var id = Country.id;

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return 0;
        }
    }

    public bool DeleteCountry(int id)
    {
        try
        {
            var count = GetCountryById(id);
            if (count == null)
            {
                return false;
            }
            count.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.countries_20ts24tu.Update(count);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(count));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }

    public Country GetCountryById(int id)
    {
        try
        {
            var Country = _context.countries_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return Country;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public Country GetCountryByIdSite(int id)
    {
        try
        {
            var Country = _context.countries_20ts24tu.Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));

            return Country;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public bool UpdateCountry(int id, Country Country)
    {

        try
        {
            var dbcheck = GetCountryById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title = Country.title;
            dbcheck.status_id = Country.status_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }

    }


    #endregion




    #region CountryTranslation CRUD
    public IEnumerable<CountryTranslation> AllCountryTranslation(string language_code)
    {
        try
        {
            var CountryTranslations = new List<CountryTranslation>();

            CountryTranslations = _context.countries_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.country_).Include(x => x.status_translation_)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


            return CountryTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public IEnumerable<CountryTranslation> AllCountryTranslationSite(string language_code)
    {
        try
        {
            var CountryTranslations = new List<CountryTranslation>();

            CountryTranslations = _context.countries_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.country_)
                .Where(x => x.status_translation_.status != "Deleted")
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


            return CountryTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public int CreateCountryTranslation(CountryTranslation CountryTranslation)
    {
        try
        {
            if (CountryTranslation == null)
            {
                return 0;
            }
            _context.countries_translations_20ts24tu.Add(CountryTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(CountryTranslation));
            int id = CountryTranslation.id;

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return 0;
        }
    }

    public bool DeleteCountryTranslation(int id)
    {

        try
        {
            var count = GetCountryTranslationById(id);
            if (count == null)
            {
                return false;
            }
            count.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == count.language_id)).id;
            _context.countries_translations_20ts24tu.Update(count);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(count));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }

    }

    public CountryTranslation GetCountryTranslationById(int id)
    {
        try
        {
            var CountryTranslation = _context.countries_translations_20ts24tu
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Include(x => x.country_).FirstOrDefault(x => x.id.Equals(id));
            return CountryTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public CountryTranslation GetCountryTranslationById(int uz_id, string language_code)
    {
        try
        {
            var CountryTranslation = _context.countries_translations_20ts24tu
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Include(x => x.country_).FirstOrDefault(x => x.country_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return CountryTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public CountryTranslation GetCountryTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var CountryTranslation = _context.countries_translations_20ts24tu
                    .Include(x => x.language_).Include(x => x.status_translation_)
                    .Include(x => x.country_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.country_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return CountryTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public CountryTranslation GetCountryTranslationByIdSite(int id)
    {
        try
        {
            var CountryTranslation = _context.countries_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.country_).Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.id.Equals(id));
            return CountryTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }


    public bool UpdateCountryTranslation(int id, CountryTranslation CountryTranslation)
    {

        try
        {
            var dbcheck = GetCountryTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title = CountryTranslation.title;
            dbcheck.language_id = CountryTranslation.language_id;
            dbcheck.country_id = CountryTranslation.country_id;
            dbcheck.status_translation_id = CountryTranslation.status_translation_id;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }
}
