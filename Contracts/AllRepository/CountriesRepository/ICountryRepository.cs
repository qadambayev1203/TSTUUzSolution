using Entities.Model.CountrysModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.CountriesRepository
{
    public interface ICountryRepository
    {
        //Country CRUD
        public IEnumerable<Country> AllCountry();
        public IEnumerable<Country> AllCountrySite();
        public Country GetCountryById(int id);
        public Country GetCountryByIdSite(int id);
        public int CreateCountry(Country country);
        public bool UpdateCountry(int id, Country country);
        public bool DeleteCountry(int id);



        //CountryTranslation CRUD
        public IEnumerable<CountryTranslation> AllCountryTranslation(string language_code);
        public IEnumerable<CountryTranslation> AllCountryTranslationSite(string language_code);
        public CountryTranslation GetCountryTranslationById(int id);
        public CountryTranslation GetCountryTranslationById(int uz_id, string language_code);
        public CountryTranslation GetCountryTranslationByIdSite(int uz_id, string language_code);
        public CountryTranslation GetCountryTranslationByIdSite(int id);
        public int CreateCountryTranslation(CountryTranslation countryTranslation);
        public bool UpdateCountryTranslation(int id, CountryTranslation countryTranslation);
        public bool DeleteCountryTranslation(int id);


        public bool SaveChanges();
    }
}
