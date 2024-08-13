using Contracts.AllRepository.DistrictsRepository;
using Entities.Model.DistrictsModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.DistrictsSqlRepository;

public class DistrictSqlRepository : IDistrictRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<DistrictSqlRepository> _logger;
    public DistrictSqlRepository(RepositoryContext repositoryContext, ILogger<DistrictSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    #region District CRUD
    public IEnumerable<District> AllDistrict(int? territorie_id)
    {
        try
        {
            var Districts = new List<District>();
            if (territorie_id == null || territorie_id == 0)
            {

                Districts = _context.districts_20ts24tu.Include(x => x.territorie_).Include(x => x.status_).ToList();

                return Districts;
            }
            else
            {

                Districts = _context.districts_20ts24tu.Include(x => x.territorie_).Include(x => x.status_).Where(x => x.territorie_.id == territorie_id).ToList();

                return Districts;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<District> AllDistrictSite(int territorie_id)
    {
        try
        {
            var Districts = new List<District>();

            Districts = _context.districts_20ts24tu.Include(x => x.territorie_).Include(x => x.status_).Where(x => x.status_.status != "Deleted").Where(x => x.territorie_.id == territorie_id).ToList();

            return Districts;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateDistrict(District District)
    {
        try
        {
            if (District == null)
            {
                return 0;
            }
            _context.districts_20ts24tu.Add(District);
            _context.SaveChanges();
            int id = District.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(District));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteDistrict(int id)
    {
        try
        {
            var district = GetDistrictById(id);
            if (district == null)
            {
                return false;
            }
            district.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.districts_20ts24tu.Update(district);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(district));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public District GetDistrictById(int id)
    {
        try
        {
            var District = _context.districts_20ts24tu.Include(x => x.status_).Include(x => x.territorie_).FirstOrDefault(x => x.id.Equals(id));

            return District;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public District GetDistrictByIdSite(int id)
    {
        try
        {
            var District = _context.districts_20ts24tu.Include(x => x.territorie_).Include(x => x.status_).Where(x => x.status_.status != "Deleted").FirstOrDefault(x => x.id.Equals(id));

            return District;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateDistrict(int id, District District)
    {

        try
        {
            var dbcheck = GetDistrictById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.territorie_ = District.territorie_;
            dbcheck.title = District.title;
            dbcheck.status_id = District.status_id;
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




    #region DistrictTranslation CRUD
    public IEnumerable<DistrictTranslation> AllDistrictTranslation(int? territorie_translation_id, string language_code)
    {
        try
        {
            var DistrictTranslations = new List<DistrictTranslation>();

            if (territorie_translation_id == null || territorie_translation_id == 0)
            {
                DistrictTranslations = _context.districts_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.district_)
                .Include(x => x.territorie_translation_)
                .Include(x => x.status_translation_)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


                return DistrictTranslations;
            }
            else
            {
                DistrictTranslations = _context.districts_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.district_)
                .Include(x => x.territorie_translation_)
                .Include(x => x.status_translation_)
                .Where(x => x.territorie_translation_.id == territorie_translation_id)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


                return DistrictTranslations;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<DistrictTranslation> AllDistrictTranslationSite(int territorie_translation_id, string language_code)
    {
        try
        {
            var DistrictTranslations = new List<DistrictTranslation>();

            DistrictTranslations = _context.districts_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.district_)
                .Include(x => x.territorie_translation_)
                .Include(x => x.status_translation_).Where(x => x.status_translation_.status != "Deleted")
                .Where(x => x.territorie_translation_.id == territorie_translation_id)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


            return DistrictTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateDistrictTranslation(DistrictTranslation DistrictTranslation)
    {
        try
        {
            if (DistrictTranslation == null)
            {
                return 0;
            }
            _context.districts_translations_20ts24tu.Add(DistrictTranslation);
            _context.SaveChanges();
            int id = DistrictTranslation.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(DistrictTranslation));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteDistrictTranslation(int id)
    {

        try
        {
            var district = GetDistrictTranslationById(id);
            if (district == null)
            {
                return false;
            }
            district.status_translation_id = (_context.statuses_translations_20ts24tu
                .FirstOrDefault(x => x.status == "Deleted" && x.language_id == district.language_id)).id;
            _context.districts_translations_20ts24tu.Update(district);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(district));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }

    public DistrictTranslation GetDistrictTranslationById(int id)
    {
        try
        {
            var DistrictTranslation = _context.districts_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_translation_)
                .Include(x => x.status_translation_)
                .Include(x => x.district_).FirstOrDefault(x => x.id.Equals(id));
            return DistrictTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public DistrictTranslation GetDistrictTranslationById(int uz_id, string language_code)
    {
        try
        {
            var DistrictTranslation = _context.districts_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_translation_)
                .Include(x => x.status_translation_)
                .Include(x => x.district_).FirstOrDefault(x => x.district_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return DistrictTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public DistrictTranslation GetDistrictTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var DistrictTranslation = _context.districts_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_translation_)
                .Include(x => x.status_translation_)
                .Include(x => x.district_)
                    .Where(x => x.status_translation_.status != "Deleted")
                .FirstOrDefault(x => x.district_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return DistrictTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public DistrictTranslation GetDistrictTranslationByIdSite(int id)
    {
        try
        {
            var DistrictTranslation = _context.districts_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_translation_)
                .Include(x => x.status_translation_)
                .Include(x => x.district_)
                .Where(x => x.status_translation_.status != "Deleted")
                .FirstOrDefault(x => x.id.Equals(id));
            return DistrictTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateDistrictTranslation(int id, DistrictTranslation DistrictTranslation)
    {

        try
        {
            var dbcheck = GetDistrictTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.territorie_translation_id = DistrictTranslation.territorie_translation_id;
            dbcheck.district_id = DistrictTranslation.district_id;
            dbcheck.title = DistrictTranslation.title;
            dbcheck.language_id = DistrictTranslation.language_id;
            dbcheck.status_translation_id = DistrictTranslation.status_translation_id;
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
