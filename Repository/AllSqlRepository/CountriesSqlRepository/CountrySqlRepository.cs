using Contracts.AllRepository.CountriesRepository;
using Entities.Model.CountrysModel;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.CountriesSqlRepository
{
    public class CountrySqlRepository : ICountryRepository
    {
        private readonly RepositoryContext _context;
        public CountrySqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        #region Country CRUD
        public IEnumerable<Country> AllCountry()
        {
            try
            {
                var Countrys = new List<Country>();

                Countrys = _context.countries_20ts24tu.ToList();

                return Countrys;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateCountry(Country Country)
        {
            try
            {
                if (Country == null)
                {
                    return false;
                }
                _context.countries_20ts24tu.Add(Country);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCountry(int id)
        {
            return true;
        }

        public Country GetCountryById(int id)
        {
            try
            {
                var Country = _context.countries_20ts24tu.FirstOrDefault(x => x.id.Equals(id));

                return Country;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateCountry(int id, Country Country)
        {

            try
            {
                var dep = GetCountryById(id);
                if (dep == null)
                {
                    return false;
                }
                Country.id = dep.id;
                _context.countries_20ts24tu.Update(Country);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion




        #region CountryTranslation CRUD
        public IEnumerable<CountryTranslation> AllCountryTranslation()
        {
            try
            {
                var CountryTranslations = new List<CountryTranslation>();

                CountryTranslations = _context.countries_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.country_)
                    .ToList();


                return CountryTranslations;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateCountryTranslation(CountryTranslation CountryTranslation)
        {
            try
            {
                if (CountryTranslation == null)
                {
                    return false;
                }
                _context.countries_translations_20ts24tu.Add(CountryTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCountryTranslation(int id)
        {

            return true;

        }

        public CountryTranslation GetCountryTranslationById(int id)
        {
            try
            {
                var CountryTranslation = _context.countries_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.country_).FirstOrDefault(x => x.id.Equals(id));
                return CountryTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateCountryTranslation(int id, CountryTranslation CountryTranslation)
        {

            try
            {
                var deptr = GetCountryById(id);
                if (deptr == null)
                {
                    return false;
                }
                CountryTranslation.id = deptr.id;
                _context.countries_translations_20ts24tu.Update(CountryTranslation);
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
