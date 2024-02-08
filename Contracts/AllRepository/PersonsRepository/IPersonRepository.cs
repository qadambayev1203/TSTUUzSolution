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
        public IEnumerable<Person> AllPerson();
        public Person GetPersonById(int id);
        public bool CreatePerson(Person person);
        public bool UpdatePerson(int id, Person person);
        public bool DeletePerson(int id);



        //PersonTranslation CRUD
        public IEnumerable<PersonTranslation> AllPersonTranslation();
        public PersonTranslation GetPersonTranslationById(int id);
        public bool CreatePersonTranslation(PersonTranslation personTranslation);
        public bool UpdatePersonTranslation(int id, PersonTranslation personTranslation);
        public bool DeletePersonTranslation(int id);
    }
}
