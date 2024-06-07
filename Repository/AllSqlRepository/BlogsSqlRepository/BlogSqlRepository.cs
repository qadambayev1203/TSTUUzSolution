using Entities.Model.BlogsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.BlogsRepository;
using Microsoft.Extensions.Logging;
using Repository.AllSqlRepository.StatusesSqlRepository;
using Entities.Model.StatusModel;
using Newtonsoft.Json;
using Entities.Model.PagesModel;

namespace Repository.AllSqlRepository.BlogsSqlRepository
{
    public class BlogSqlRepository : IBlogRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<BlogSqlRepository> _logger;
        public BlogSqlRepository(RepositoryContext repositoryContext, ILogger<BlogSqlRepository> logger)
        {
            _context = repositoryContext;
            _logger = logger;
        }



        #region Blog CRUD
        public IEnumerable<Blog> AllBlog(int queryNum, int pageNum, string? blog_category)
        {
            try
            {
                var blogs = new List<Blog>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum).ToList();

                }
                else
                {
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                        .Include(x => x.blog_category_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).ToList();

                }
                return blogs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<Blog> AllBlogSelect(string? blog_category)
        {
            try
            {
                var blogs = new List<Blog>();

                blogs = _context.blogs_20ts24tu
                .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                .Select(x => new Blog
                {
                    id = x.id,
                    title_short = x.title_short,
                    title = x.title,
                    description = x.description,
                    status_ = x.status_
                })
                .ToList();

                return blogs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }
        public IEnumerable<Blog> AllBlogSite(int queryNum, int pageNum, string? blog_category)
        {
            try
            {
                var blogs = new List<Blog>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_).Where(x => x.status_.status != "Deleted")
                        .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_).Where(x => x.status_.status != "Deleted")
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Skip(queryNum * (pageNum - 1))
                        .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                        .Take(queryNum).ToList();

                }
                else
                {
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_).Where(x => x.status_.status != "Deleted")
                        .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).ToList();

                }
                return blogs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public int CreateBlog(Blog blog)
        {
            try
            {
                if (blog == null)
                {
                    return 0;
                }
                _context.blogs_20ts24tu.Add(blog);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(blog));

                return blog.id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return 0;
            }
        }

        public bool DeleteBlog(int id)
        {
            try
            {
                var blog = GetBlogById(id);
                if (blog == null)
                {
                    return false;
                }
                blog.status_id = (_context.statuses_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.blogs_20ts24tu.Update(blog);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(blog));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return false;
            }
        }

        public Blog GetBlogById(int id)
        {
            try
            {
                var blog = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.id.Equals(id));

                return blog;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public Blog GetBlogByIdSite(int id)
        {
            try
            {
                var blog = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_).Where(x => x.status_.status != "Deleted")
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.id.Equals(id));

                return blog;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public bool UpdateBlog(int id, Blog blog)
        {

            try
            {
                var dbcheck = GetBlogById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.title_short = blog.title_short;
                dbcheck.title = blog.title;
                dbcheck.description = blog.description;
                dbcheck.text = blog.text;
                dbcheck.status_id = blog.status_id;
                dbcheck.img_id = blog.img_id;
                dbcheck.blog_category_id = blog.blog_category_id;
                dbcheck.position = blog.position;
                dbcheck.favorite = blog.favorite;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(blog));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return false;
            }

        }


        #endregion




        #region BlogTranslation CRUD
        public IEnumerable<BlogTranslation> AllBlogTranslation(int queryNum, int pageNum, string language_code, string? blog_category)
        {
            try
            {
                var blogTranslations = new List<BlogTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogTranslations = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogTranslations = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    blogTranslations = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(200).ToList();

                }
                return blogTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<BlogTranslation> AllBlogTranslationSelect(string language_code, string? blog_category)
        {
            try
            {
                var blogTranslations = new List<BlogTranslation>();

                blogTranslations = _context.blogs_translations_20ts24tu

                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                     .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                    .Select(x => new BlogTranslation
                    {
                        id = x.id,
                        title_short = x.title_short,
                        title = x.title,
                        description = x.description,
                        status_translation_ = x.status_translation_,
                        blog_id = x.blog_id
                    })
                    .ToList();


                return blogTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public IEnumerable<BlogTranslation> AllBlogTranslationSite(int queryNum, int pageNum, string language_code, string? blog_category)
        {
            try
            {
                var blogTranslations = new List<BlogTranslation>();
                if (queryNum == 0 && pageNum != 0)
                {
                    blogTranslations = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Skip(10 * (pageNum - 1))
                        .Take(10)
                        .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .ToList();

                }
                if (queryNum != 0 && pageNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogTranslations = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Skip(queryNum * (pageNum - 1))
                        .Take(queryNum)
                        .ToList();

                }
                else
                {
                    blogTranslations = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.user_).ThenInclude(y => y.user_type_)
                        .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                        .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                        .Take(200).ToList();

                }
                return blogTranslations;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public int CreateBlogTranslation(BlogTranslation blogTranslation)
        {
            try
            {
                if (blogTranslation == null)
                {
                    return 0;
                }
                _context.blogs_translations_20ts24tu.Add(blogTranslation);
                _context.SaveChanges();
                _logger.LogInformation($"Created " + JsonConvert.SerializeObject(blogTranslation));

                return blogTranslation.id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return 0;
            }
        }

        public bool DeleteBlogTranslation(int id)
        {
            try
            {
                var blogTranslation = GetBlogTranslationById(id);
                if (blogTranslation == null)
                {
                    return false;
                }
                blogTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted" && x.language_id == blogTranslation.language_id)).id;
                _context.blogs_translations_20ts24tu.Update(blogTranslation);
                _logger.LogInformation($"Deleted " + JsonConvert.SerializeObject(blogTranslation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return false;
            }
        }

        public BlogTranslation GetBlogTranslationById(int id)
        {
            try
            {
                var blogTranslation = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.id.Equals(id));
                return blogTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }
        public BlogTranslation GetBlogTranslationById(int uz_id, string language_code)
        {
            try
            {
                var blogTranslation = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.blog_id.Equals(uz_id) && x.language_.code.Equals(language_code));
                return blogTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public BlogTranslation GetBlogTranslationByIdSite(int id)
        {
            try
            {
                var blogTranslation = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Where(x => x.status_translation_.status != "Deleted")
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).FirstOrDefault(x => x.id.Equals(id));
                return blogTranslation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return null;
            }
        }

        public bool UpdateBlogTranslation(int id, BlogTranslation blog)
        {

            try
            {
                var dbcheck = GetBlogTranslationById(id);
                if (dbcheck is null)
                {
                    return false;
                }
                dbcheck.title_short = blog.title_short;
                dbcheck.title = blog.title;
                dbcheck.description = blog.description;
                dbcheck.text = blog.text;
                dbcheck.status_translation_id = blog.status_translation_id;
                dbcheck.img_translation_id = blog.img_translation_id;
                dbcheck.blog_category_translation_id = blog.blog_category_translation_id;
                dbcheck.position = blog.position;
                dbcheck.favorite = blog.favorite;
                dbcheck.blog_id = blog.blog_id;
                dbcheck.language_id = blog.language_id;
                _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(dbcheck));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return false;
            }

        }
        #endregion

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error" + ex.ToString());
                return false;
            }
        }


    }
}
