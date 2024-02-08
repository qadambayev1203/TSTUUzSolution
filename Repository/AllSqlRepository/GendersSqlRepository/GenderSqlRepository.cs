using Contracts.AllRepository.GendersRepository;
using Entities;
using Entities.Model.GenderModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AllSqlRepository.GendersSqlRepository
{
    public class GenderSqlRepository : IGenderRepository
    {
        private readonly RepositoryContext _context;
        public GenderSqlRepository(RepositoryContext repositoryContext)
        {
           _context = repositoryContext;
        }



        //Gender CRUD
        public IEnumerable<Gender> AllGender()
        {
            var genders = new List<Gender>();
            genders = _context.genders_20ts24tu.Include(x => x.status_).ToList();
            return genders;
        }

        public bool CreateGender(Gender gender)
        {
            if(gender == null)
            {
                return false;
            }
            _context.genders_20ts24tu.Add(gender);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteGender(int id)
        {
            var gender = GetGenderById(id);
            if(gender == null)
            {
                return false;
            }
            _context.Update(gender);
            _context.SaveChanges();

            return true;
        }

        public Gender GetGenderById(int id)
        {
            var gender = _context.genders_20ts24tu.Include(x => x.status_).FirstOrDefault(x=>x.id.Equals(id));
            
            return gender;
        }

        public bool UpdateGender(int id, Gender gender)
        {
            var genderCheck = GetGenderById(id);
            if (genderCheck == null)
            {
                return false;
            }
            _context.Update(gender);
            _context.SaveChanges();

            return true;
        }







        //GenderTranslation CRUD
        public IEnumerable<GenderTranslation> AllGenderTranslation()
        {
            var genderTranslations = new List<GenderTranslation>();
            genderTranslations=_context.genders_translations_20ts24tu.Include(x => x.genders_).Include(x => x.status_translation_).Include(x => x.languages_).ToList();
            return genderTranslations;
        }

        public bool CreateGenderTranslation(GenderTranslation genderTranslation)
        {
            if(genderTranslation == null)
            {
                return false;
            }
            _context.genders_translations_20ts24tu.Add(genderTranslation);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteGenderTranslation(int id)
        {
            var genderTranslation=GetGenderTranslationById(id);
            if(genderTranslation == null)
            {
                return false;
            }
            _context.genders_translations_20ts24tu.Update(genderTranslation);
            _context.SaveChanges();

            return true;
        }

        public GenderTranslation GetGenderTranslationById(int id)
        {
            var genderTranslation=_context.genders_translations_20ts24tu.Include(x => x.genders_).Include(x => x.status_translation_).Include(x => x.languages_).FirstOrDefault(x=>x.id.Equals(id));
            return genderTranslation;
        }

        public bool UpdateGenderTranslation(int id, GenderTranslation genderTranslation)
        {
            var genderTranslationCheck = GetGenderTranslationById(id);
            if (genderTranslationCheck == null)
            {
                return false;
            }
            _context.genders_translations_20ts24tu.Update(genderTranslation);
            _context.SaveChanges();

            return true;
        }

    }
}
