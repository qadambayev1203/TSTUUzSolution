using Contracts.AllRepository.TerritoriesRepository;
using Entities.Model.TerritoriesModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Repository.AllSqlRepository.TerritoriesSqlRepository;

public class TerritorieSqlRepository : ITerritorieRepository
{

    private readonly RepositoryContext _context;
    private readonly ILogger<TerritorieSqlRepository> _logger;
    public TerritorieSqlRepository(RepositoryContext repositoryContext, ILogger<TerritorieSqlRepository> logger)
    {
        _context = repositoryContext;
        _logger = logger;
    }



    #region Territorie CRUD
    public IEnumerable<Territorie> AllTerritorieSite(int country_id)
    {
        try
        {
            var Territories = new List<Territorie>();

            Territories = _context.territories_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.country_).Where(x => x.country_.id == country_id).ToList();

            return Territories;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public IEnumerable<Territorie> AllTerritorie(int? country_id)
    {
        try
        {
            var Territories = new List<Territorie>();

            if (country_id == null || country_id == 0)
            {
                Territories = _context.territories_20ts24tu.Include(x => x.country_).Include(x => x.status_).ToList();

                return Territories;
            }
            else
            {

                Territories = _context.territories_20ts24tu.Include(x => x.country_).Include(x => x.status_).Where(x => x.country_.id == country_id).ToList();

                return Territories;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateTerritorie(Territorie Territorie)
    {
        try
        {
            if (Territorie == null)
            {
                return 0;
            }
            _context.territories_20ts24tu.Add(Territorie);
            _context.SaveChanges();
            int id = Territorie.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(Territorie));

            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteTerritorie(int id)
    {
        try
        {
            var terr = GetTerritorieById(id);
            if (terr == null)
            {
                return false;
            }
            terr.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
            _context.territories_20ts24tu.Update(terr);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(terr));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }
    }

    public Territorie GetTerritorieByIdSite(int id)
    {
        try
        {
            var Territorie = _context.territories_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.country_).FirstOrDefault(x => x.id.Equals(id));

            return Territorie;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public Territorie GetTerritorieById(int id)
    {
        try
        {
            var Territorie = _context.territories_20ts24tu.Include(x => x.country_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

            return Territorie;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateTerritorie(int id, Territorie Territorie)
    {

        try
        {
            var dbcheck = GetTerritorieById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.title = Territorie.title;
            dbcheck.country_id = Territorie.country_id;
            dbcheck.status_id = Territorie.status_id;
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




    #region TerritorieTranslation CRUD
    public IEnumerable<TerritorieTranslation> AllTerritorieTranslationSite(int country_translation_id, string language_code)
    {
        try
        {
            var TerritorieTranslations = new List<TerritorieTranslation>();

            TerritorieTranslations = _context.territories_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.territorie_)
                .Include(x => x.country_translation_).Where(x => x.status_translation_.status != "Deleted")
                .Where(x => x.country_translation_.id == country_translation_id)
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                .ToList();


            return TerritorieTranslations;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public IEnumerable<TerritorieTranslation> AllTerritorieTranslation(int? country_translation_id, string language_code)
    {
        try
        {
            var TerritorieTranslations = new List<TerritorieTranslation>();
            if (country_translation_id == null || country_translation_id == 0)
            {
                TerritorieTranslations = _context.territories_translations_20ts24tu
               .Include(x => x.language_)
               .Include(x => x.territorie_)
               .Include(x => x.country_translation_)
               .Include(x => x.status_translation_)
               .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
               .ToList();


                return TerritorieTranslations;
            }
            else
            {

                TerritorieTranslations = _context.territories_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.territorie_)
                    .Include(x => x.country_translation_)
                    .Include(x => x.status_translation_)
                    .Where(x => x.country_translation_.id == country_translation_id)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();


                return TerritorieTranslations;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public int CreateTerritorieTranslation(TerritorieTranslation TerritorieTranslation)
    {
        try
        {
            if (TerritorieTranslation == null)
            {
                return 0;
            }
            _context.territories_translations_20ts24tu.Add(TerritorieTranslation);
            _context.SaveChanges();
            int id = TerritorieTranslation.id;
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(TerritorieTranslation));
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return 0;
        }
    }

    public bool DeleteTerritorieTranslation(int id)
    {

        try
        {
            var terr = GetTerritorieTranslationById(id);
            if (terr == null)
            {
                return false;
            }
            terr.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == terr.language_id)).id;
            _context.territories_translations_20ts24tu.Update(terr);
            _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(terr));

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return false;
        }

    }

    public TerritorieTranslation GetTerritorieTranslationByIdSite(int id)
    {
        try
        {
            var TerritorieTranslation = _context.territories_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_).Where(x => x.status_translation_.status != "Deleted")
                .Include(x => x.country_translation_).FirstOrDefault(x => x.id.Equals(id));
            return TerritorieTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public TerritorieTranslation GetTerritorieTranslationById(int id)
    {
        try
        {
            var TerritorieTranslation = _context.territories_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_)
                .Include(x => x.status_translation_)
                .Include(x => x.country_translation_).FirstOrDefault(x => x.id.Equals(id));
            return TerritorieTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }
    public TerritorieTranslation GetTerritorieTranslationById(int uz_id, string language_code)
    {
        try
        {
            var TerritorieTranslation = _context.territories_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_)
                .Include(x => x.status_translation_)
                .Include(x => x.country_translation_)
                .FirstOrDefault(x => x.territorie_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return TerritorieTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public TerritorieTranslation GetTerritorieTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var TerritorieTranslation = _context.territories_translations_20ts24tu
                    .Include(x => x.language_)
                .Include(x => x.territorie_)
                .Include(x => x.status_translation_)
                .Include(x => x.country_translation_)
                .Where(x => x.status_translation_.status != "Deleted")
                .FirstOrDefault(x => x.territorie_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return TerritorieTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error " + ex.Message);
            return null;
        }
    }

    public bool UpdateTerritorieTranslation(int id, TerritorieTranslation TerritorieTranslation)
    {

        try
        {
            var dbcheck = GetTerritorieTranslationById(id);
            if (dbcheck is null)
            {
                return false;
            }
            dbcheck.language_id = TerritorieTranslation.language_id;
            dbcheck.territorie_id = TerritorieTranslation.territorie_id;
            dbcheck.title = TerritorieTranslation.title;
            dbcheck.country_translation_id = TerritorieTranslation.country_translation_id;
            dbcheck.status_translation_id = TerritorieTranslation.status_translation_id;
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
