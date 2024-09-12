using Entities.Model.BlogsModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.BlogsRepository;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Entities.Model.AnyClasses;

namespace Repository.AllSqlRepository.BlogsSqlRepository;

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
    public QueryList<Blog> AllBlog(int queryNum, int pageNum, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        try
        {
            int length = 0;
            if (start_time.HasValue)
            {
                var time = start_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                start_time = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, DateTimeKind.Utc);
            }

            if (end_time.HasValue)
            {
                var time = end_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                end_time = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59, DateTimeKind.Utc);
            }



            IQueryable<Blog> query = _context.blogs_20ts24tu
                .Include(x => x.status_)
                .Include(x => x.img_)
                .Include(x => x.blog_category_)
                .Include(x => x.user_).ThenInclude(y => y.user_type_);

            if (favorite == true)
            {
                query = query.Where(x => x.favorite == true);
            }

            if (start_time != null && end_time != null)
            {
                query = query.Where(x => x.event_date >= start_time && x.event_date <= end_time);
            }

            if (!string.IsNullOrEmpty(blog_category))
            {
                query = query.Where(x => x.blog_category_.title.Equals(blog_category));
            }

            length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);

            }

            QueryList<Blog> blogList = new QueryList<Blog>()
            {
                length = length,
                query_list = query.ToList()
            };

            return blogList;



        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<Blog> AllBlogSelect(string? blog_category, bool? favorite)
    {
        try
        {
            IQueryable<Blog> query = _context.blogs_20ts24tu
                    .Where((favorite == true) ? x => x.favorite == true : x => x != null)
            .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
            .Select(x => new Blog
            {
                id = x.id,
                title_short = x.title_short,
                title = x.title,
                description = x.description,
                status_ = x.status_
            });
            int length = query.Count();

            QueryList<Blog> blogList = new QueryList<Blog>()
            {
                length = length,
                query_list = query.ToList()
            };

            return blogList;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }
    public QueryList<Blog> AllBlogSite(int queryNum, int pageNum, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        try
        {
            if (start_time.HasValue)
            {
                var time = start_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                start_time = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, DateTimeKind.Utc);
            }

            if (end_time.HasValue)
            {
                var time = end_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                end_time = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59, DateTimeKind.Utc);
            }

            IQueryable<Blog> query = _context.blogs_20ts24tu
                    .Include(x => x.status_)
                    .Include(x => x.img_)
                    .Include(x => x.blog_category_).Where(x => x.status_.status != "Deleted")
                    .OrderByDescending(b => b.event_date)
                    .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                    .Where((blog_category != null) ? x => x.blog_category_.title.Equals(blog_category) : x => x.blog_category_.title != null)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_);



            if (start_time != null && end_time != null)
            {
                query = query.Where(x => x.event_date >= start_time && x.event_date <= end_time);
            }
            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);
            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);

            }

            QueryList<Blog> blogList = new QueryList<Blog>()
            {
                length = length,
                query_list = query.ToList()
            };

            return blogList;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
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

            DateTime localDateTime = DateTime.Parse(blog.event_date.ToString());
            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            DateTime localDateTime1 = DateTime.Parse(blog.event_end_date.ToString());
            localDateTime1 = DateTime.SpecifyKind(localDateTime1, DateTimeKind.Local);
            DateTime utcDateTime1 = localDateTime1.ToUniversalTime();

            blog.event_date = utcDateTime;
            blog.event_end_date = utcDateTime1;

            _context.blogs_20ts24tu.Add(blog);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(blog));

            return blog.id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
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

            DateTime localDateTime = DateTime.Parse(blog.event_date.ToString());
            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            DateTime localDateTime1 = DateTime.Parse(blog.event_end_date.ToString());
            localDateTime1 = DateTime.SpecifyKind(localDateTime1, DateTimeKind.Local);
            DateTime utcDateTime1 = localDateTime1.ToUniversalTime();

            blog.event_date = utcDateTime;
            blog.event_end_date = utcDateTime1;

            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.event_date = blog.event_date;
            dbcheck.event_end_date = blog.event_end_date;
            dbcheck.title_short = blog.title_short;
            dbcheck.title = blog.title;
            dbcheck.description = blog.description;
            dbcheck.text = blog.text;
            dbcheck.status_id = blog.status_id;
            if (blog.img_ != null)
            {
                dbcheck.img_ = blog.img_;
            }
            dbcheck.blog_category_id = blog.blog_category_id;
            dbcheck.position = blog.position;
            dbcheck.favorite = blog.favorite;
            _logger.LogInformation($"Updated " + JsonConvert.SerializeObject(blog));
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return false;
        }

    }


    #endregion




    #region BlogTranslation CRUD
    public QueryList<BlogTranslation> AllBlogTranslation(int queryNum, int pageNum, string language_code, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        try
        {
            if (start_time.HasValue)
            {
                var time = start_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                start_time = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, DateTimeKind.Utc);
            }

            if (end_time.HasValue)
            {
                var time = end_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                end_time = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59, DateTimeKind.Utc);
            }

            IQueryable<BlogTranslation> query = _context.blogs_translations_20ts24tu
                .Include(x => x.language_)
                .Include(x => x.status_translation_)
                .Include(x => x.blog_category_translation_)
                .Include(x => x.blog_)
                .Include(x => x.img_translation_)
                .Include(x => x.user_).ThenInclude(y => y.user_type_);

            if (favorite == true)
            {
                query = query.Where(x => x.favorite == true);
            }

            if (start_time != null && end_time != null)
            {
                query = query.Where(x => x.event_date >= start_time && x.event_date <= end_time);
            }

            if (!string.IsNullOrEmpty(blog_category))
            {
                query = query.Where(x => x.blog_category_translation_.title.Equals(blog_category));
            }

            if (!string.IsNullOrEmpty(language_code))
            {
                query = query.Where(x => x.language_.code.Equals(language_code));
            }

            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1)).Take(10);

            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);

            }

            QueryList<BlogTranslation> blogs_ = new QueryList<BlogTranslation>
            {
                length = length,
                query_list = query.ToList()
            };

            return blogs_;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error: {ex.Message}");
            return null;
        }

    }

    public QueryList<BlogTranslation> AllBlogTranslationSelect(string language_code, string? blog_category, bool? favorite)
    {
        try
        {
            IQueryable<BlogTranslation> query = _context.blogs_translations_20ts24tu
                .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null)
                    .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                 .Where((blog_category != null) ? x => x.blog_category_translation_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                .Select(x => new BlogTranslation
                {
                    id = x.id,
                    title_short = x.title_short,
                    title = x.title,
                    description = x.description,
                    status_translation_ = x.status_translation_,
                    blog_id = x.blog_id
                });
            int length = query.Count();


            QueryList<BlogTranslation> blogs_ = new QueryList<BlogTranslation>
            {
                length = length,
                query_list = query.ToList()
            };

            return blogs_;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }

    public QueryList<BlogTranslation> AllBlogTranslationSite(int queryNum, int pageNum, string language_code, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time)
    {
        try
        {
            if (start_time.HasValue)
            {
                var time = start_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                start_time = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, DateTimeKind.Utc);
            }

            if (end_time.HasValue)
            {
                var time = end_time.Value.ToUniversalTime();
                time = time.AddDays(1);
                end_time = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59, DateTimeKind.Utc);
            }

            IQueryable<BlogTranslation> query = _context.blogs_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.blog_category_translation_)
                    .Include(x => x.blog_)
                    .OrderBy(x => x.event_date)
                    .Include(x => x.img_translation_)
                    .Where((favorite == true) ? x => x.favorite == true : x => x != null)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Where((blog_category != null) ? x => x.blog_category_translation_.blog_category_.title.Equals(blog_category) : x => x.blog_category_translation_.title != null)
                    .Where((language_code != null) ? x => x.language_.code.Equals(language_code) : x => x.language_.code != null);




            if (start_time != null && end_time != null)
            {
                query = query.Where(x => x.event_date >= start_time && x.event_date <= end_time);
            }
            int length = query.Count();

            if (queryNum == 0 && pageNum != 0)
            {
                query = query.Skip(10 * (pageNum - 1))
                    .Take(10);
            }
            if (queryNum != 0 && pageNum != 0)
            {
                if (queryNum > 200) { queryNum = 200; }
                query = query.Skip(queryNum * (pageNum - 1))
                    .Take(queryNum);
            }


            QueryList<BlogTranslation> blogs_ = new QueryList<BlogTranslation>
            {
                length = length,
                query_list = query.ToList()
            };

            return blogs_;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
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

            DateTime localDateTime = DateTime.Parse(blogTranslation.event_date.ToString());
            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            DateTime localDateTime1 = DateTime.Parse(blogTranslation.event_end_date.ToString());
            localDateTime1 = DateTime.SpecifyKind(localDateTime1, DateTimeKind.Local);
            DateTime utcDateTime1 = localDateTime1.ToUniversalTime();

            blogTranslation.event_date = utcDateTime;
            blogTranslation.event_end_date = utcDateTime1;

            _context.blogs_translations_20ts24tu.Add(blogTranslation);
            _context.SaveChanges();
            _logger.LogInformation($"Created " + JsonConvert.SerializeObject(blogTranslation));

            return blogTranslation.id;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
            return null;
        }
    }
    public BlogTranslation GetBlogTranslationByIdSite(int uz_id, string language_code)
    {
        try
        {
            var blogTranslation = _context.blogs_translations_20ts24tu
                    .Include(x => x.language_)
                    .Include(x => x.status_translation_)
                    .Include(x => x.blog_category_translation_)
                    .Include(x => x.blog_)
                    .Include(x => x.img_translation_)
                    .Include(x => x.user_).ThenInclude(y => y.user_type_)
                    .Where(x => x.status_translation_.status != "Deleted")
                    .FirstOrDefault(x => x.blog_id.Equals(uz_id) && x.language_.code.Equals(language_code));
            return blogTranslation;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
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

            DateTime localDateTime = DateTime.Parse(blog.event_date.ToString());
            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            DateTime localDateTime1 = DateTime.Parse(blog.event_end_date.ToString());
            localDateTime1 = DateTime.SpecifyKind(localDateTime1, DateTimeKind.Local);
            DateTime utcDateTime1 = localDateTime1.ToUniversalTime();

            blog.event_date = utcDateTime;
            blog.event_end_date = utcDateTime1;

            dbcheck.updated_at = DateTime.UtcNow;
            dbcheck.event_date = blog.event_date;
            dbcheck.event_end_date = blog.event_end_date;
            dbcheck.title_short = blog.title_short;
            dbcheck.title = blog.title;
            dbcheck.description = blog.description;
            dbcheck.text = blog.text;
            dbcheck.status_translation_id = blog.status_translation_id;
            if (blog.img_translation_ != null)
            {
                dbcheck.img_translation_ = blog.img_translation_;
            }

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
            _logger.LogError($"Error" + ex.Message);
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
            _logger.LogError($"Error" + ex.Message);
            return false;
        }
    }


}
