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
        public Country GetCountryById(int id);
        public bool CreateCountry(Country country);
        public bool UpdateCountry(int id, Country country);
        public bool DeleteCountry(int id);



        //CountryTranslation CRUD
        public IEnumerable<CountryTranslation> AllCountryTranslation();
        public CountryTranslation GetCountryTranslationById(int id);
        public bool CreateCountryTranslation(CountryTranslation countryTranslation);
        public bool UpdateCountryTranslation(int id, CountryTranslation countryTranslation);
        public bool DeleteCountryTranslation(int id);
    }
}
