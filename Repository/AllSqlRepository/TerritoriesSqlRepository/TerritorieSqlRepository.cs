using Contracts.AllRepository.TerritoriesRepository;
using Entities.Model.TerritoriesModel;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.TerritoriesSqlRepository
{
    public class TerritorieSqlRepository : ITerritorieRepository
    {
        private readonly RepositoryContext _context;
        public TerritorieSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        #region Territorie CRUD
        public IEnumerable<Territorie> AllTerritorie(int country_id)
        {
            try
            {
                var Territories = new List<Territorie>();

                Territories = _context.territories_20ts24tu.Include(x => x.country_).Where(x => x.country_.id == country_id).ToList();

                return Territories;
            }
            catch
            {
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

                return id;
            }
            catch
            {
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

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Territorie GetTerritorieById(int id)
        {
            try
            {
                var Territorie = _context.territories_20ts24tu.Include(x => x.country_).FirstOrDefault(x => x.id.Equals(id));

                return Territorie;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateTerritorie(int id, Territorie Territorie)
        {

            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion




        #region TerritorieTranslation CRUD
        public IEnumerable<TerritorieTranslation> AllTerritorieTranslation(int country_translation_id, string language_code)
        {
            try
            {
                var TerritorieTranslations = new List<TerritorieTranslation>();

                TerritorieTranslations = _context.territories_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.territorie_)
                    .Include(x => x.country_translation_)
                    .Where(x => x.country_translation_.id == country_translation_id)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();


                return TerritorieTranslations;
            }
            catch
            {
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
                return id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteTerritorieTranslation(int id)
        {

            try
            {
                var terr= GetTerritorieTranslationById(id);
                if (terr == null)
                {
                    return false;
                }
                terr.status_translation_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.territories_translations_20ts24tu.Update(terr);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public TerritorieTranslation GetTerritorieTranslationById(int id)
        {
            try
            {
                var TerritorieTranslation = _context.territories_translations_20ts24tu
                        .Include(x => x.language_)
                    .Include(x => x.territorie_)
                    .Include(x => x.country_translation_).FirstOrDefault(x => x.id.Equals(id));
                return TerritorieTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateTerritorieTranslation(int id, TerritorieTranslation TerritorieTranslation)
        {

            try
            {
                return true;
            }
            catch
            {
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
            catch
            {
                return false;
            }
        }
    }
}
