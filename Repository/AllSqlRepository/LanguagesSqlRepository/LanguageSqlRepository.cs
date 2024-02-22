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


        public IEnumerable<Language> AllLanguage(int queryNum,int pageNum)
        {
            try
            {
                var languages = new List<Language>();
                if (queryNum == 0 && pageNum != 0)
                {
                    languages = _context.languages_20ts24tu.Include(x => x.status_).Include(x=>x.img_).Skip(10*(pageNum-1)).Take(10).ToList();

                }
                else if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    languages = _context.languages_20ts24tu.Include(x => x.status_).Include(x => x.img_).Take(queryNum).ToList();

                }
                else
                {
                    languages = _context.languages_20ts24tu.Include(x => x.status_).Include(x => x.img_).Take(200).ToList();

                }
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
                var language = _context.languages_20ts24tu.Include(x => x.status_).Include(x => x.img_).FirstOrDefault(x => x.id.Equals(id));
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
