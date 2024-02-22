using Entities.Model.BlogsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.BlogsRepository
{
    public interface IBlogRepository
    {
        //Blog CRUD
        public IEnumerable<Blog> AllBlog(int queryNum, int pageNum);
        public Blog GetBlogById(int id);
        public bool CreateBlog(Blog blog);
        public bool UpdateBlog(int id, Blog blog);
        public bool DeleteBlog(int id);



        //BlogTranslation CRUD
        public IEnumerable<BlogTranslation> AllBlogTranslation(int queryNum, int pageNum);
        public BlogTranslation GetBlogTranslationById(int id);
        public bool CreateBlogTranslation(BlogTranslation blogTranslation);
        public bool UpdateBlogTranslation(int id, BlogTranslation blogTranslation);
        public bool DeleteBlogTranslation(int id);
    }
}
