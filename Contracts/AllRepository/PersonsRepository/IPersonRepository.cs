using Entities.Model.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.PersonsRepository
{
    public interface IPersonRepository
    {
        //Person CRUD
        public IEnumerable<Person> AllPerson(int queryNum, int pageNum);
        public IEnumerable<Person> AllPersonSite(int queryNum, int pageNum);
        public Person GetPersonById(int id);
        public Person GetPersonByIdSite(int id);
        public int CreatePerson(Person person);
        public bool UpdatePerson(int id, Person person);
        public bool DeletePerson(int id);



        //PersonTranslation CRUD
        public IEnumerable<PersonTranslation> AllPersonTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<PersonTranslation> AllPersonTranslationSite(int queryNum, int pageNum, string language_code);
        public PersonTranslation GetPersonTranslationById(int id);
        public PersonTranslation GetPersonTranslationById(int uz_id, string language_code);
        public PersonTranslation GetPersonTranslationByIdSite(int uz_id, string language_code);
        public PersonTranslation GetPersonTranslationByIdSite(int id);
        public int CreatePersonTranslation(PersonTranslation personTranslation);
        public bool UpdatePersonTranslation(int id, PersonTranslation person);
        public bool DeletePersonTranslation(int id);
        public bool SaveChanges();

    }
}
