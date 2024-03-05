using Contracts.AllRepository.DistrictsRepository;
using Entities.Model.DistrictsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.DistrictsSqlRepository
{
    public  class DistrictSqlRepository : IDistrictRepository
    {
        private readonly RepositoryContext _context;
        public DistrictSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        #region District CRUD
        public IEnumerable<District> AllDistrict(int territorie_id)
        {
            try
            {
                var Districts = new List<District>();

                Districts = _context.districts_20ts24tu.Include(x => x.territorie_).Where(x => x.territorie_.id == territorie_id).ToList();

                return Districts;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateDistrict(District District)
        {
            try
            {
                if (District == null)
                {
                    return false;
                }
                _context.districts_20ts24tu.Add(District);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDistrict(int id)
        {
            return true;
        }

        public District GetDistrictById(int id)
        {
            try
            {
                var District = _context.districts_20ts24tu.Include(x => x.territorie_).FirstOrDefault(x => x.id.Equals(id));

                return District;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDistrict(int id, District District)
        {

            try
            {
                var dep = GetDistrictById(id);
                if (dep == null)
                {
                    return false;
                }
                District.id = dep.id;
                _context.districts_20ts24tu.Update(District);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion




        #region DistrictTranslation CRUD
        public IEnumerable<DistrictTranslation> AllDistrictTranslation(int territorie_translation_id)
        {
            try
            {
                var DistrictTranslations = new List<DistrictTranslation>();

                DistrictTranslations = _context.districts_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.district_)
                    .Include(x => x.territorie_translation_)
                    .Where(x => x.territorie_translation_.id == territorie_translation_id)
                    .ToList();


                return DistrictTranslations;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateDistrictTranslation(DistrictTranslation DistrictTranslation)
        {
            try
            {
                if (DistrictTranslation == null)
                {
                    return false;
                }
                _context.districts_translations_20ts24tu.Add(DistrictTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDistrictTranslation(int id)
        {

            return true;

        }

        public DistrictTranslation GetDistrictTranslationById(int id)
        {
            try
            {
                var DistrictTranslation = _context.districts_translations_20ts24tu
                        .Include(x => x.language_)
                    .Include(x => x.territorie_translation_)
                    .Include(x => x.district_).FirstOrDefault(x => x.id.Equals(id));
                return DistrictTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDistrictTranslation(int id, DistrictTranslation DistrictTranslation)
        {

            try
            {
                var deptr = GetDistrictById(id);
                if (deptr == null)
                {
                    return false;
                }
                DistrictTranslation.id = deptr.id;
                _context.districts_translations_20ts24tu.Update(DistrictTranslation);
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
