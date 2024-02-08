using Contracts.AllRepository.LanguagesRepository;
using Entities;
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
            var languages = new List<Language>();
            languages = _context.languages_20ts24tu.Include(x=>x.status_).ToList();
            return languages;
        }

        public bool CreateLanguage(Language language)
        {
            if (language == null)
            {
                return false;
            }
            _context.languages_20ts24tu.Add(language);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteLanguage(int id)
        {
            var language = GetLanguageById(id);
            if (language == null)
            {
                return false;
            }
            _context.languages_20ts24tu.Update(language);
            _context.SaveChanges();

            return true;
        }

        public Language GetLanguageById(int id)
        {
            var language = _context.languages_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));
            return language;
        }

        public bool UpdateLanguage(int id, Language language)
        {
            var languageCheck = GetLanguageById(id);
            if (languageCheck == null)
            {
                return false;
            }
            _context.languages_20ts24tu.Update(language);
            _context.SaveChanges();

            return true;
        }
    }
}
