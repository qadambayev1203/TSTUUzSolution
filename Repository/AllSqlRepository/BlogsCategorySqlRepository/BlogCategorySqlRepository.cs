using Contracts.AllRepository.BlogsCategoryRepository;
using Entities.Model.BlogsCategoryModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.AllSqlRepository.StatusesSqlRepository;
using Newtonsoft.Json;
using Entities.Model.AppealsToTheRectorsModel;

namespace Repository.AllSqlRepository.BlogsCategorySqlRepository
{
    public class BlogCategorySqlRepository : IBlogCategoryRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<BlogCategorySqlRepository> _logger;
        public BlogCategorySqlRepository(RepositoryContext repositoryContext, ILogger<BlogCategorySqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        #region BlogCategory CRUD
        public IEnumerable<BlogCategory> AllBlogCategory(int queryNum, int pageNum)
        {
            try
            {
                var blogCategorys = new List<BlogCategory>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogCategorys = _context.blogs_category_20ts24tu.Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogCategorys = _context.blogs_category_20ts24tu.Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    blogCategorys = _context.blogs_category_20ts24tu.Include(x => x.status_).ToList();

                }
                return blogCategorys;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public int CreateBlogCategory(BlogCategory blogCategory)
        {
            try
            {
                if (blogCategory == null)
                {
                    return 0;
                }
                _context.blogs_category_20ts24tu.Add(blogCategory);
                _context.SaveChanges();
                _logger.LogInformation($"Created" + JsonConvert.SerializeObject(blogCategory));
                int id = blogCategory.id;
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return 0;
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
                _logger.LogInformation($"Deleted" + JsonConvert.SerializeObject(blogCategory));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public bool UpdateBlogCategory(int id, BlogCategory blogCategory)
        {

            try
            {
                var dbcheck = GetBlogCategoryById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.status_id = blogCategory.status_id;
                dbcheck.title = blogCategory.title;
                _logger.LogInformation($"Updated" + JsonConvert.SerializeObject(blogCategory));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return false;
            }

        }

        public IEnumerable<BlogCategory> AllBlogCategorySite(int queryNum, int pageNum)
        {
            try
            {
                var blogCategorys = new List<BlogCategory>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogCategorys = _context.blogs_category_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogCategorys = _context.blogs_category_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).Skip(queryNum * (pageNum - 1)).Take(queryNum).ToList();

                }
                else
                {
                    blogCategorys = _context.blogs_category_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).ToList();

                }
                return blogCategorys;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public BlogCategory GetBlogCategoryByIdSite(int id)
        {
            try
            {
                var blogCategory = _context.blogs_category_20ts24tu.Where(x => x.status_.status != "Deleted").Include(x => x.status_).FirstOrDefault(x => x.id.Equals(id));

                return blogCategory;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }


        #endregion





        #region BlogCategoryTranslation CRUD
        public IEnumerable<BlogCategoryTranslation> AllBlogCategoryTranslation(int queryNum, int pageNum, string language_code)
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
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogCategoryTranslations = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    blogCategoryTranslations = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return blogCategoryTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public int CreateBlogCategoryTranslation(BlogCategoryTranslation blogCategoryTranslation)
        {
            try
            {
                if (blogCategoryTranslation == null)
                {
                    return 0;
                }
                _context.blogs_category_translations_20ts24tu.Add(blogCategoryTranslation);
                _context.SaveChanges();
                _logger.LogInformation($"Created" + JsonConvert.SerializeObject(blogCategoryTranslation));
                int id = blogCategoryTranslation.id;
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return 0;
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
                blogCategoryTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == blogCategoryTranslation.language_id)).id;
                _context.blogs_category_translations_20ts24tu.Update(blogCategoryTranslation);
                _logger.LogInformation($"Deleted" + JsonConvert.SerializeObject(blogCategoryTranslation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }
        public BlogCategoryTranslation GetBlogCategoryTranslationById(int uz_id, string language_code)
        {
            try
            {
                var blogCategoryTranslation = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .FirstOrDefault(x => x.blog_category_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return blogCategoryTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public BlogCategoryTranslation GetBlogCategoryTranslationByIdSite(int uz_id, string language_code)
        {
            try
            {
                var blogCategoryTranslation = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .FirstOrDefault(x => x.blog_category_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return blogCategoryTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public bool UpdateBlogCategoryTranslation(int id, BlogCategoryTranslation blogCategoryTranslation)
        {

            try
            {
                var dbcheck = GetBlogCategoryTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.status_translation_id = blogCategoryTranslation.status_translation_id;
                dbcheck.title = blogCategoryTranslation.title;
                dbcheck.language_id = blogCategoryTranslation.language_id;
                dbcheck.blog_category_id = blogCategoryTranslation.blog_category_id;
                _logger.LogInformation($"Updated" + JsonConvert.SerializeObject(blogCategoryTranslation));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return false;
            }

        }



        public IEnumerable<BlogCategoryTranslation> AllBlogCategoryTranslationSite(int queryNum, int pageNum, string language_code)
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
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogCategoryTranslations = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    blogCategoryTranslations = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                return blogCategoryTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }

        public BlogCategoryTranslation GetBlogCategoryTranslationByIdSite(int id)
        {
            try
            {
                var blogCategoryTranslation = _context.blogs_category_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.blog_category_).FirstOrDefault(x => x.id.Equals(id));
                return blogCategoryTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return null;
            }
        }
        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.Message);
                return false;
            }
        }




        #endregion
    }
}
