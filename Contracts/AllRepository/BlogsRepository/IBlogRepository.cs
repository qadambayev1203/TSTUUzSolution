﻿using Entities.Model.BlogsCategoryModel;
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
        public IEnumerable<Blog> AllBlog(int queryNum, int pageNum, string? blog_category, bool? favorite);
        public IEnumerable<Blog> AllBlogSelect(string? blog_category, bool? favorite);
        public IEnumerable<Blog> AllBlogSite(int queryNum, int pageNum, string? blog_category, bool? favorite);
        public Blog GetBlogById(int id);
        public Blog GetBlogByIdSite(int id);
        public int CreateBlog(Blog blog);
        public bool UpdateBlog(int id, Blog blog);
        public bool DeleteBlog(int id);



        //BlogTranslation CRUD
        public IEnumerable<BlogTranslation> AllBlogTranslation(int queryNum, int pageNum, string language_code, string? blog_category, bool? favorite);
        public IEnumerable<BlogTranslation> AllBlogTranslationSelect(string language_code, string? blog_category, bool? favorite);
        public IEnumerable<BlogTranslation> AllBlogTranslationSite(int queryNum, int pageNum, string language_code, string? blog_category, bool? favorite);
        public BlogTranslation GetBlogTranslationById(int id);
        public BlogTranslation GetBlogTranslationByIdSite(int id);
        public BlogTranslation GetBlogTranslationById(int uz_id, string language_code);
        public BlogTranslation GetBlogTranslationByIdSite(int uz_id, string language_code);
        public int CreateBlogTranslation(BlogTranslation blogTranslation);
        public bool UpdateBlogTranslation(int id, BlogTranslation blog);
        public bool DeleteBlogTranslation(int id);
        public bool SaveChanges();

    }
}
