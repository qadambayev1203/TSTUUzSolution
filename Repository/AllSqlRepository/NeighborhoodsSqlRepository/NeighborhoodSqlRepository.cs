using Contracts.AllRepository.NeighborhoodsRepository;
using Entities.Model.NeighborhoodsModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.NeighborhoodsSqlRepository;

public class NeighborhoodSqlRepository : INeighborhoodRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<NeighborhoodSqlRepository> _logger;
    public NeighborhoodSqlRepository(RepositoryContext repositoryContext, ILogger<NeighborhoodSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    #region Neighborhood CRUD
    public IEnumerable<Neighborhood> AllNeighborhood(int? district_id)
    {
        try
        {
            var Neighborhoods = new List<Neighborhood>();

            Neighborhoods = _context.neighborhoods_20ts24tu.Include(x => x.district_).Include(x => x.status_).Where(x => x.district_.id == district_id).ToList();

            return Neighborhoods;

        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Neighborhood> AllNeighborhood(int queryNum, int pageNum)
    {
        try
        {
            var Neighborhoods = new List<Neighborhood>();
            if (queryNum == 0 && pageNum != 0)
            {
                Neighborhoods = _context.neighborhoods_20ts24tu
                    .Include(x => x.status_)
                    .Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                Neighborhoods = _context.neighborhoods_20ts24tu
                    .Include(x => x.status_)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                Neighborhoods = _context.neighborhoods_20ts24tu.Include(x => x.status_)
                   .ToList();
            }
            return Neighborhoods;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<Neighborhood> AllNeighborhoodSite(int district_id)
    {
        try
        {
            var Neighborhoods = new List<Neighborhood>();

            Neighborhoods = _context.neighborhoods_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.district_).Where(x => x.district_.id == district_id).ToList();

            return Neighborhoods;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateNeighborhood(Neighborhood Neighborhood)
    {
        try
        {
            if (Neighborhood == null)
            {
                return 0;
            }
            _context.neighborhoods_20ts24tu.Add(Neighborhood);
            _context.SaveChanges();
            int id = Neighborhood.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(Neighborhood));
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteNeighborhood(int id)
    {
        try
        {
            var neig = GetNeighborhoodById(id);
            if (neig == null)
            {
                return false;
            }
            neig.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.neighborhoods_20ts24tu.Update(neig);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(neig));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Neighborhood GetNeighborhoodById(int id)
    {
        try
        {
            var Neighborhood = _context.neighborhoods_20ts24tu.Include(x => x.district_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return Neighborhood;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public Neighborhood GetNeighborhoodByIdSite(int id)
    {
        try
        {
            var Neighborhood = _context.neighborhoods_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.district_).FirstOrDefault(x => x.id.Equals(id));

            return Neighborhood;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateNeighborhood(int id, Neighborhood Neighborhood)
    {

        try
        {
            var dbcheck = GetNeighborhoodById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.district_id = Neighborhood.district_id;
            dbcheck.title = Neighborhood.title;
            dbcheck.status_id = Neighborhood.status_id;
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




    #region NeighborhoodTranslation CRUD
    public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslation(int? district_translation_id, string language_code)
    {
        try
        {
            var NeighborhoodTranslations = new List<NeighborhoodTranslation>();

            NeighborhoodTranslations = _context.neighborhoods_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.neighborhood_)
                .Include(x => x.district_translation_)
                .Include(x => x.status_translation_)
                .Where(x => x.district_translation_.id == district_translation_id)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


            return NeighborhoodTranslations;

        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslation(int queryNum, int pageNum, string language_code)
    {
        try
        {
            var Neighborhoods = new List<NeighborhoodTranslation>();
            if (queryNum == 0 && pageNum != 0)
            {
                Neighborhoods = _context.neighborhoods_translations_20ts24tu
                    .Include(x => x.status_translation_)
                    .Skip(10 * (pageNum - 1)).Take(10).ToList();

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                Neighborhoods = _context.neighborhoods_translations_20ts24tu
                    .Include(x => x.status_translation_)
                    .Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

            }
            else
            {
                Neighborhoods = _context.neighborhoods_translations_20ts24tu.Include(x => x.status_translation_)
                   .ToList();
            }
            return Neighborhoods;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslationSite(int district_translation_id, string language_code)
    {
        try
        {
            var NeighborhoodTranslations = new List<NeighborhoodTranslation>();

            NeighborhoodTranslations = _context.neighborhoods_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.neighborhood_)
                .Include(x => x.district_translation_).Where(x => x.status_translation_.status != "Deleted")
                .Where(x => x.district_translation_.id == district_translation_id)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


            return NeighborhoodTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateNeighborhoodTranslation(NeighborhoodTranslation NeighborhoodTranslation)
    {
        try
        {
            if (NeighborhoodTranslation == null)
            {
                return 0;
            }
            _context.neighborhoods_translations_20ts24tu.Add(NeighborhoodTranslation);
            _context.SaveChanges();
            int id = NeighborhoodTranslation.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(NeighborhoodTranslation));
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteNeighborhoodTranslation(int id)
    {

        try
        {
            var neig = GetNeighborhoodTranslationById(id);
            if (neig == null)
            {
                return false;
            }
            neig.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == neig.language_id)).id;
            _context.neighborhoods_translations_20ts24tu.Update(neig);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(neig));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }

    public NeighborhoodTranslation GetNeighborhoodTranslationById(int id)
    {
        try
        {
            var NeighborhoodTranslation = _context.neighborhoods_translations_20ts24tu.
                    Include(x => x.language_)
                .Include(x => x.neighborhood_)
                .Include(x => x.status_translation_)
                .Include(x => x.district_translation_).FirstOrDefault(x => x.id.Equals(id));
            return NeighborhoodTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public NeighborhoodTranslation GetNeighborhoodTranslationById(int uz_id, string language_code)
    {
        try
        {
            var NeighborhoodTranslation = _context.neighborhoods_translations_20ts24tu.
                    Include(x => x.language_)
                .Include(x => x.neighborhood_)
                .Include(x => x.status_translation_)
                .Include(x => x.district_translation_).FirstOrDefault(x => x.neighborhood_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return NeighborhoodTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public NeighborhoodTranslation GetNeighborhoodTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var NeighborhoodTranslation = _context.neighborhoods_translations_20ts24tu.
                    Include(x => x.language_)
                .Include(x => x.neighborhood_)
                .Include(x => x.status_translation_)
                .Include(x => x.district_translation_)
                    .Where(x => x.status_translation_.status != "Deleted")
                .FirstOrDefault(x => x.neighborhood_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return NeighborhoodTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public NeighborhoodTranslation GetNeighborhoodTranslationByIdSite(int id)
    {
        try
        {
            var NeighborhoodTranslation = _context.neighborhoods_translations_20ts24tu.
                    Include(x => x.language_)
                .Include(x => x.neighborhood_).Where(x => x.status_translation_.status != "Deleted")
                .Include(x => x.district_translation_).FirstOrDefault(x => x.id.Equals(id));
            return NeighborhoodTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateNeighborhoodTranslation(int id, NeighborhoodTranslation NeighborhoodTranslation)
    {

        try
        {
            var dbcheck = GetNeighborhoodTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.language_id = NeighborhoodTranslation.language_id;
            dbcheck.neighborhood_id = NeighborhoodTranslation.neighborhood_id;
            dbcheck.district_translation_id = NeighborhoodTranslation.district_translation_id;
            dbcheck.title = NeighborhoodTranslation.title;
            dbcheck.status_translation_id = NeighborhoodTranslation.status_translation_id;
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
        try { _context.SaveChanges(); return true; }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message); return false;
        }
    }




}
