using Entities.Model.BlogsModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.AllRepository.BlogsRepository;

namespace Repository.AllSqlRepository.BlogsSqlRepository
{
    public class BlogSqlRepository : IBlogRepository
    { 
        private readonly RepositoryContext _context;
        public BlogSqlRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }



        //Blog CRUD
        public IEnumerable<Blog> AllBlog(int queryNum, int pageNum)
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
                        .Include(x => x.user_).ThenInclude(y=>y.user_type_)
                        .Skip(10 * (pageNum - 1)).Take(10).ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).Take(queryNum).ToList();

                }
                else
                {
                    blogs = _context.blogs_20ts24tu
                        .Include(x => x.status_)
                        .Include(x => x.img_)
                        .Include(x => x.blog_category_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).Take(200).ToList();

                }
                return blogs;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateBlog(Blog blog)
        {
            try
            {
                if (blog == null)
                {
                    return false;
                }
                _context.blogs_20ts24tu.Add(blog);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                _context.SaveChanges();

                return true;
            }
            catch
            {
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
            catch
            {
                return null;
            }
        }

        public bool UpdateBlog(int id, Blog blog)
        {

            try
            {
                var dep = GetBlogById(id);
                if (dep == null)
                {
                    return false;
                }
                blog.id = dep.id;
                _context.blogs_20ts24tu.Update(blog);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }







        //BlogTranslation CRUD
        public IEnumerable<BlogTranslation> AllBlogTranslation(int queryNum, int pageNum, string language_code)
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
                        .Skip(10 * (pageNum - 1))
                        .Take(10).Where(x => x.language_.code.Equals(language_code))
                        .ToList();

                }
                if (queryNum != 0)
                {
                    if (queryNum > 200) { queryNum = 200; }
                    blogTranslations = _context.blogs_translations_20ts24tu
                        .Include(x => x.language_)
                        .Include(x => x.status_translation_)
                        .Include(x => x.blog_category_translation_)
                        .Include(x => x.blog_)
                        .Include(x => x.img_translation_)
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).Where(x => x.language_.code.Equals(language_code))
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
                        .Include(x => x.user_).ThenInclude(y => y.user_type_).Where(x => x.language_.code.Equals(language_code))
                        .Take(200).ToList();

                }
                return blogTranslations;
            }
            catch(Exception ex) 
            {
                return null;
            }
        }

        public bool CreateBlogTranslation(BlogTranslation blogTranslation)
        {
            try
            {
                if (blogTranslation == null)
                {
                    return false;
                }
                _context.blogs_translations_20ts24tu.Add(blogTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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
                blogTranslation.status_translation_id = (_context.statuses_translations_20ts24tu.FirstOrDefault(x => x.status == "Deleted")).id;
                _context.blogs_translations_20ts24tu.Update(blogTranslation);
                _context.SaveChanges();

                return true;
            }
            catch
            {
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
            catch
            {
                return null;
            }
        }

        public bool UpdateBlogTranslation(int id, BlogTranslation blogTranslation)
        {

            try
            {
                var deptr = GetBlogById(id);
                if (deptr == null)
                {
                    return false;
                }
                blogTranslation.id = deptr.id;
                _context.blogs_translations_20ts24tu.Update(blogTranslation);
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
