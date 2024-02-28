using Contracts.AllRepository.PagesRepository;
using Entities.Model.PagesModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.PagesSqlRepository
{
    public class PageSqlRepository : IPageRepository
    {
        private readonly RepositoryContext _context;
        public PageSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        //Page CRUD
        public IEnumerable<Pages> AllPage(int queryNum, int pageNum)
        {
            try
            {
                var pages = new List<Pages>();
                if (queryNum == 0 && pageNum != 0)
                {
                    pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y=>y.user_type_)
                        .Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).Take(200).ToList();

                }
                return pages;
            }
            catch
            {
                return null;
            }
        }

        public bool CreatePage(Pages page)
        {
            try
            {
                if (page == null)
                {
                    return false;
                }
                _context.pages_20ts24tu.Add(page);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePage(int id)
        {
            try
            {
                var page = GetPageById(id);
                if (page == null)
                {
                    return false;
                }
                page.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.pages_20ts24tu.Update(page);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Pages GetPageById(int id)
        {
            try
            {
                var page = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return page;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdatePage(int id, Pages page)
        {

            try
            {
                var dep = GetPageById(id);
                if (dep == null)
                {
                    return false;
                }
                page.id = dep.id;
                _context.pages_20ts24tu.Update(page);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }







        //PageTranslation CRUD
        public IEnumerable<PageTranslation> AllPageTranslation(int queryNum, int pageNum, string language_code)
        {
            try
            {
                var pageTranslations = new List<PageTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    pageTranslations = _context.pages_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.page_).Where(x => x.language_.code.Equals(language_code))
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    pageTranslations = _context.pages_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.page_).Where(x => x.language_.code.Equals(language_code))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    pageTranslations = _context.pages_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.page_).Where(x => x.language_.code.Equals(language_code))
                        .Take(200).ToList();

                }
                return pageTranslations;
            }
            catch
            {
                return null;
            }
        }

        public bool CreatePageTranslation(PageTranslation pageTranslation)
        {
            try
            {
                if (pageTranslation == null)
                {
                    return false;
                }
                _context.pages_translations_20ts24tu.Add(pageTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePageTranslation(int id)
        {
            try
            {
                var pageTranslation = GetPageTranslationById(id);
                if (pageTranslation == null)
                {
                    return false;
                }
                pageTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.pages_translations_20ts24tu.Update(pageTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public PageTranslation GetPageTranslationById(int id)
        {
            try
            {
                var pageTranslation = _context.pages_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.page_).FirstOrDefault(x => x.id.Equals(id));
                return pageTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdatePageTranslation(int id, PageTranslation pageTranslation)
        {

            try
            {
                var deptr = GetPageById(id);
                if (deptr == null)
                {
                    return false;
                }
                pageTranslation.id = deptr.id;
                _context.pages_translations_20ts24tu.Update(pageTranslation);
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
