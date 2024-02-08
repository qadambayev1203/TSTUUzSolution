using Contracts.AllRepository.PersonsRepository;
using Entities;
using Entities.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AllSqlRepository.PersonsSqlRepository
{
    public class PersonSqlRepository : IPersonRepository
    {

        private readonly RepositoryContext _context;
        public PersonSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        //Person CRUD
        public IEnumerable<Person> AllPerson()
        {
            var persons = new List<Person>();
            persons = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_).ToList();
            return persons;
        }

        public bool CreatePerson(Person person)
        {
            if (person == null)
            {
                return false;
            }
            _context.persons_20ts24tu.Add(person);
            _context.SaveChanges();

            return true;
        }

        public bool DeletePerson(int id)
        {
            var person = GetPersonById(id);
            if (person == null)
            {
                return false;
            }
            _context.persons_20ts24tu.Update(person);
            _context.SaveChanges();

            return true;
        }

        public Person GetPersonById(int id)
        {
            var person = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_).FirstOrDefault(x => x.id.Equals(id));
            return person;
        }

        public bool UpdatePerson(int id, Person person)
        {
            var personCheck = GetPersonById(id);
            if (personCheck == null)
            {
                return false;
            }
            _context.persons_20ts24tu.Update(person);
            _context.SaveChanges();

            return true;
        }






        //PersonTranslation CRUD
        public IEnumerable<PersonTranslation> AllPersonTranslation()
        {
            var personsTranslation = new List<PersonTranslation>();
            personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_).Include(x => x.languages_).Include(x => x.persons_).Include(x => x.status_translation_).ToList();
            return personsTranslation;
        }

        public bool CreatePersonTranslation(PersonTranslation personTranslation)
        {
            if (personTranslation == null)
            {
                return false;
            }
            _context.persons_translations_20ts24tu.Add(personTranslation);
            _context.SaveChanges();

            return true;
        }

        public bool DeletePersonTranslation(int id)
        {
            var personTranslation = GetPersonTranslationById(id);
            if (personTranslation == null)
            {
                return false;
            }
            _context.persons_translations_20ts24tu.Update(personTranslation);
            _context.SaveChanges();

            return true;
        }

        public PersonTranslation GetPersonTranslationById(int id)
        {
            var personTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_).Include(x => x.languages_).Include(x => x.persons_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
            return personTranslation;
        }

        public bool UpdatePersonTranslation(int id, PersonTranslation personTranslation)
        {
            var personTranslationCheck = GetPersonTranslationById(id);
            if (personTranslationCheck == null)
            {
                return false;
            }
            _context.persons_translations_20ts24tu.Update(personTranslation);
            _context.SaveChanges();

            return true;
        }

    }
}
