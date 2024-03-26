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
                    pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    pages = _context.pages_20ts24tu.Include(x => x.img_).Include(x => x.user_).ThenInclude(y => y.user_type_).Include(x => x.status_).ToList();

                }
                return pages;
            }
            catch
            {
                return null;
            }
        }

        public int CreatePage(Pages page)
        {
            try
            {
                if (page == null)
                {
                    return 0;
                }
                _context.pages_20ts24tu.Add(page);
                _context.SaveChanges();

                return page.id;
            }
            catch
            {
                return 0;
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

        public bool UpdatePage()
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
                        .Include(x => x.page_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    pageTranslations = _context.pages_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.page_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1)).Take(queryNum)
                        .ToList();

                }
                else
                {
                    pageTranslations = _context.pages_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Include(x => x.page_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return pageTranslations;
            }
            catch
            {
                return null;
            }
        }

        public int CreatePageTranslation(PageTranslation pageTranslation)
        {
            try
            {
                if (pageTranslation == null)
                {
                    return 0;
                }
                _context.pages_translations_20ts24tu.Add(pageTranslation);
                _context.SaveChanges();

                return pageTranslation.id;
            }
            catch
            {
                return 0;
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

        public bool UpdatePageTranslation()
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
