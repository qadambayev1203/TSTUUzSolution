﻿using Contracts.AllRepository.PersonsRepository;
using Entities;
using Entities.Model.GenderModel;
using Entities.Model.PersonModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public IEnumerable<Person> AllPerson(int queryNum, int pageNum)
        {
            try
            {
                var persons = new List<Person>();
                if (queryNum == 0 && pageNum != 0)
                {
                    persons = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    persons = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    persons = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_)
                        .ToList();

                }
                return persons;
            }
            catch
            {
                return Enumerable.Empty<Person>();
            }
        }

        public int CreatePerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    return 0;
                }
                person.created_at = DateTime.UtcNow;
                _context.persons_20ts24tu.Add(person);
                _context.SaveChanges();

                return person.id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeletePerson(int id)
        {
            try
            {
                var person = GetPersonById(id);
                if (person == null)
                {
                    return false;
                }
                person.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.persons_20ts24tu.Update(person);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Person GetPersonById(int id)
        {
            try
            {
                var person = _context.persons_20ts24tu.Include(x => x.gender_).Include(x => x.status_).Include(x => x.img_).FirstOrDefault(x => x.id.Equals(id));
                return person;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdatePerson()
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






        //PersonTranslation CRUD
        public IEnumerable<PersonTranslation> AllPersonTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var personsTranslation = new List<PersonTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_).Include(x => x.language_)
                        .Include(x => x.persons_).ThenInclude(y => y.img_)
                        .Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                else if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_).
                        Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                         .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    personsTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_)
                        .Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                          .ToList();

                }
                return personsTranslation;
            }
            catch
            {
                return Enumerable.Empty<PersonTranslation>();
            }
        }

        public int CreatePersonTranslation(PersonTranslation personTranslation)
        {
            try
            {
                if (personTranslation == null)
                {
                    return 0;
                }
                _context.persons_translations_20ts24tu.Add(personTranslation);
                _context.SaveChanges();

                return personTranslation.id;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeletePersonTranslation(int id)
        {
            try
            {
                var personTranslation = GetPersonTranslationById(id);
                if (personTranslation == null)
                {
                    return false;
                }
                personTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.persons_translations_20ts24tu.Update(personTranslation);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public PersonTranslation GetPersonTranslationById(int id)
        {
            try
            {
                var personTranslation = _context.persons_translations_20ts24tu.Include(x => x.gender_).Include(x => x.language_).Include(x => x.persons_).ThenInclude(y => y.img_).Include(x => x.status_translation_).FirstOrDefault(x => x.id.Equals(id));
                return personTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdatePersonTranslation()
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
        public bool SaveChanges()
        {
            try { _context.SaveChanges(); return true; } catch { return false; }
        }

    }
}
