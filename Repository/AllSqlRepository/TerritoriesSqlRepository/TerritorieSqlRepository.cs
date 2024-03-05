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

        public bool CreateTerritorie(Territorie Territorie)
        {
            try
            {
                if (Territorie == null)
                {
                    return false;
                }
                _context.territories_20ts24tu.Add(Territorie);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTerritorie(int id)
        {
            return true;
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
                var dep = GetTerritorieById(id);
                if (dep == null)
                {
                    return false;
                }
                Territorie.id = dep.id;
                _context.territories_20ts24tu.Update(Territorie);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion




        #region TerritorieTranslation CRUD
        public IEnumerable<TerritorieTranslation> AllTerritorieTranslation(int country_translation_id)
        {
            try
            {
                var TerritorieTranslations = new List<TerritorieTranslation>();

                TerritorieTranslations = _context.territories_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.territorie_)
                    .Include(x => x.country_translation_)
                    .Where(x => x.country_translation_.id == country_translation_id)
                    .ToList();


                return TerritorieTranslations;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateTerritorieTranslation(TerritorieTranslation TerritorieTranslation)
        {
            try
            {
                if (TerritorieTranslation == null)
                {
                    return false;
                }
                _context.territories_translations_20ts24tu.Add(TerritorieTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTerritorieTranslation(int id)
        {

            return true;

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
                var deptr = GetTerritorieById(id);
                if (deptr == null)
                {
                    return false;
                }
                TerritorieTranslation.id = deptr.id;
                _context.territories_translations_20ts24tu.Update(TerritorieTranslation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
