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

        public bool CreateNeighborhood(Neighborhood Neighborhood)
        {
            try
            {
                if (Neighborhood == null)
                {
                    return false;
                }
                _context.neighborhoods_20ts24tu.Add(Neighborhood);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNeighborhood(int id)
        {
            return true;
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
                var dep = GetNeighborhoodById(id);
                if (dep == null)
                {
                    return false;
                }
                Neighborhood.id = dep.id;
                _context.neighborhoods_20ts24tu.Update(Neighborhood);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion




        #region NeighborhoodTranslation CRUD
        public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslation(int district_translation_id)
        {
            try
            {
                var NeighborhoodTranslations = new List<NeighborhoodTranslation>();

                NeighborhoodTranslations = _context.neighborhoods_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.neighborhood_)
                    .Include(x => x.district_translation_)
                    .Where(x => x.district_translation_.id == district_translation_id)
                    .ToList();


                return NeighborhoodTranslations;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateNeighborhoodTranslation(NeighborhoodTranslation NeighborhoodTranslation)
        {
            try
            {
                if (NeighborhoodTranslation == null)
                {
                    return false;
                }
                _context.neighborhoods_translations_20ts24tu.Add(NeighborhoodTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNeighborhoodTranslation(int id)
        {

            return true;

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
                var deptr = GetNeighborhoodById(id);
                if (deptr == null)
                {
                    return false;
                }
                NeighborhoodTranslation.id = deptr.id;
                _context.neighborhoods_translations_20ts24tu.Update(NeighborhoodTranslation);
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
