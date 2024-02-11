using Contracts.AllRepository.LanguagesRepository;
using Entities;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AllSqlRepository.LanguagesSqlRepository
{
    public class LanguageSqlRepository : ILanguageRepository
    {
        private readonly RepositoryContext _context;
        public LanguageSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }


        public IEnumerable<Language> AllLanguage()
        {
            try
            {
                var languages = new List<Language>();
                languages = _context.languages_20ts24tu.Include(x => x.status_).ToList();
                return languages;
            }
            catch 
            {
                return null;
            }
        }

        public bool CreateLanguage(Language language)
        {
            try
            {
                if (language == null)
                {
                    return false;
                }
                _context.languages_20ts24tu.Add(language);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteLanguage(int id)
        {
            try
            {
                var language = GetLanguageById(id);
                if (language == null)
                {
                    return false;
                }
                language.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.languages_20ts24tu.Update(language);
                _context.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public Language GetLanguageById(int id)
        {
            try
            {
                var language = _context.languages_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
                return language;
            }
            catch 
            {
                return null;
            }
        }

        public bool UpdateLanguage()
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
