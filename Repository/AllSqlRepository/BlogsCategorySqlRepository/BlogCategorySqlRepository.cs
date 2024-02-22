using Contracts.AllRepository.BlogsCategoryRepository;
using Entities.Model.BlogsCategoryModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.AllSqlRepository.BlogsCategorySqlRepository
{
    public class BlogCategorySqlRepository : IBlogCategoryRepository
    {
        private readonly RepositoryContext _context;
        public BlogCategorySqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        //BlogCategory CRUD
        public IEnumerable<BlogCategory> AllBlogCategory(int queryNum, int pageNum)
        {
            try
            {
                var blogCategorys = new List<BlogCategory>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogCategorys = _context.blogs_category_20ts24tu.Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogCategorys = _context.blogs_category_20ts24tu.Include(x => x.status_).Take(queryNum).ToList();

                }
                else
                {
                    blogCategorys = _context.blogs_category_20ts24tu.Include(x => x.status_).Take(200).ToList();

                }
                return blogCategorys;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateBlogCategory(BlogCategory blogCategory)
        {
            try
            {
                if (blogCategory == null)
                {
                    return false;
                }
                _context.blogs_category_20ts24tu.Add(blogCategory);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBlogCategory(int id)
        {
            try
            {
                var blogCategory = GetBlogCategoryById(id);
                if (blogCategory == null)
                {
                    return false;
                }
                blogCategory.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.blogs_category_20ts24tu.Update(blogCategory);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public BlogCategory GetBlogCategoryById(int id)
        {
            try
            {
                var blogCategory = _context.blogs_category_20ts24tu.Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return blogCategory;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateBlogCategory(int id, BlogCategory blogCategory)
        {

            try
            {
                var dep = GetBlogCategoryById(id);
                if (dep == null)
                {
                    return false;
                }
                blogCategory.id = dep.id;
                _context.blogs_category_20ts24tu.Update(blogCategory);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }







        //BlogCategoryTranslation CRUD
        public IEnumerable<BlogCategoryTranslation> AllBlogCategoryTranslation(int queryNum, int pageNum)
        {
            try
            {
                var blogCategoryTranslations = new List<BlogCategoryTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogCategoryTranslations = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogCategoryTranslations = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    blogCategoryTranslations = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Take(200).ToList();

                }
                return blogCategoryTranslations;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateBlogCategoryTranslation(BlogCategoryTranslation blogCategoryTranslation)
        {
            try
            {
                if (blogCategoryTranslation == null)
                {
                    return false;
                }
                _context.blogs_category_translations_20ts24tu.Add(blogCategoryTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBlogCategoryTranslation(int id)
        {
            try
            {
                var blogCategoryTranslation = GetBlogCategoryTranslationById(id);
                if (blogCategoryTranslation == null)
                {
                    return false;
                }
                blogCategoryTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.blogs_category_translations_20ts24tu.Update(blogCategoryTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public BlogCategoryTranslation GetBlogCategoryTranslationById(int id)
        {
            try
            {
                var blogCategoryTranslation = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_).FirstOrDefault(x => x.id.Equals(id));
                return blogCategoryTranslation;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateBlogCategoryTranslation(int id, BlogCategoryTranslation blogCategoryTranslation)
        {

            try
            {
                var deptr = GetBlogCategoryById(id);
                if (deptr == null)
                {
                    return false;
                }
                blogCategoryTranslation.id = deptr.id;
                _context.blogs_category_translations_20ts24tu.Update(blogCategoryTranslation);
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
