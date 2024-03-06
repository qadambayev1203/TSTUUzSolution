using Contracts.AllRepository.NeighborhoodsRepository;
using Entities.Model.NeighborhoodsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Model.DistrictsModel;

namespace Repository.AllSqlRepository.NeighborhoodsSqlRepository
{
    public class NeighborhoodSqlRepository : INeighborhoodRepository
    {
        private readonly RepositoryContext _context;
        public NeighborhoodSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        #region Neighborhood CRUD
        public IEnumerable<Neighborhood> AllNeighborhood(int district_id)
        {
            try
            {
                var Neighborhoods = new List<Neighborhood>();

                Neighborhoods = _context.neighborhoods_20ts24tu.Include(x => x.district_).Where(x => x.district_.id == district_id).ToList();

                return Neighborhoods;
            }
            catch
            {
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
                return id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteNeighborhood(int id)
        {
            try
            {
                var neig= GetNeighborhoodById(id);
                if (neig == null)
                {
                    return false;
                }
                neig.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.neighborhoods_20ts24tu.Update(neig);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Neighborhood GetNeighborhoodById(int id)
        {
            try
            {
                var Neighborhood = _context.neighborhoods_20ts24tu.Include(x => x.district_).FirstOrDefault(x => x.id.Equals(id));

                return Neighborhood;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateNeighborhood(int id, Neighborhood Neighborhood)
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




        #region NeighborhoodTranslation CRUD
        public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslation(int district_translation_id, string language_code)
        {
            try
            {
                var NeighborhoodTranslations = new List<NeighborhoodTranslation>();

                NeighborhoodTranslations = _context.neighborhoods_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.neighborhood_)
                    .Include(x => x.district_translation_)
                    .Where(x => x.district_translation_.id == district_translation_id)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();


                return NeighborhoodTranslations;
            }
            catch
            {
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
                return id;
            }
            catch
            {
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
                neig.status_translation_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.neighborhoods_translations_20ts24tu.Update(neig);

                return true;
            }
            catch
            {
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
                    .Include(x => x.district_translation_).FirstOrDefault(x => x.id.Equals(id));
                return NeighborhoodTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateNeighborhoodTranslation(int id, NeighborhoodTranslation NeighborhoodTranslation)
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
            try { _context.SaveChanges(); return true; } catch { return false; }
        }
    }
}
