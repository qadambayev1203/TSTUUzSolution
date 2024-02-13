using Contracts.AllRepository.GendersRepository;
using Entities;
using Entities.Model.GenderModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public IEnumerable<Gender> AllGender(int queryNum, int pageNum)
        {
            try
            {
                var genders = new List<Gender>();
                if (queryNum == 0 && pageNum != 0)
                {
                    genders = _context.genders_20ts24tu.Include(x => x.status_).Skip(10*(pageNum-1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    genders = _context.genders_20ts24tu.Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    genders = _context.genders_20ts24tu.Include(x => x.status_).Take(200).ToList();

                }
                return genders;
            }
            catch 
            {
                return null;
            }
        }

        public bool CreateGender(Gender gender)
        {
            try
            {
                if (gender == null)
                {
                    return false;
                }
                _context.genders_20ts24tu.Add(gender);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteGender(int id)
        {
            try
            {
                var gender = GetGenderById(id);
                if (gender == null)
                {
                    return false;
                }
                gender.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.Update(gender);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public Gender GetGenderById(int id)
        {
            try
            {
                var gender = _context.genders_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return gender;
            }
            catch 
            {
                return null;
            }
        }

        public bool UpdateGender()
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







        //GenderTranslation CRUD
        public IEnumerable<GenderTranslation> AllGenderTranslation(int queryNum, int pageNum)
        {
            try
            {
                var genderTranslations = new List<GenderTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.genders_).
                        Include(x => x.status_translation_).Include(x => x.languages_)
                        .Skip(10*(queryNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.genders_).
                        Include(x => x.status_translation_).Include(x => x.languages_)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    genderTranslations = _context.genders_translations_20ts24tu.Include(x => x.genders_).
                        Include(x => x.status_translation_).Include(x => x.languages_).Take(200).ToList();

                }
                return genderTranslations;
            }
            catch 
            {
                return null;
            }
        }

        public bool CreateGenderTranslation(GenderTranslation genderTranslation)
        {
            try
            {
                if (genderTranslation == null)
                {
                    return false;
                }
                _context.genders_translations_20ts24tu.Add(genderTranslation);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteGenderTranslation(int id)
        {
            try
            {
                var genderTranslation = GetGenderTranslationById(id);
                if (genderTranslation == null)
                {
                    return false;
                }
                genderTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.genders_translations_20ts24tu.Update(genderTranslation);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public GenderTranslation GetGenderTranslationById(int id)
        {
            try
            {
                var genderTranslation = _context.genders_translations_20ts24tu.Include(x => x.genders_).Include(x => x.status_translation_).Include(x => x.languages_).FirstOrDefault(x => x.id.Equals(id));
                return genderTranslation;
            }
            catch 
            {
                return null;
            }
        }

        public bool UpdateGenderTranslation()
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
