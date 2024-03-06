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
                var id = Country.id;

                return id;
            }
            catch
            {
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

                return true;
            }
            catch
            {
                return false;
            }
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
                return true;
            }
            catch
            {
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
                    .Include(x => x.country_)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .ToList();


                return CountryTranslations;
            }
            catch
            {
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
                int id = CountryTranslation.id;

                return id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteCountryTranslation(int id)
        {

            try
            {
                var count= GetCountryTranslationById(id);
                if (count == null)
                {
                    return false;
                }
                count.status_translation_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.countries_translations_20ts24tu.Update(count);

                return true;
            }
            catch
            {
                return false;
            }

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
