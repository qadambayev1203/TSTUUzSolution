using Entities.Model.AnyClasses;
using Entities.Model.BlogsModel;

namespace Contracts.AllRepository.BlogsRepository;

public interface IBlogRepository
{
    //Blog CRUD
    public QueryList<Blog> AllBlog(int queryNum, int pageNum, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time);
    public QueryList<Blog> AllBlogSelect(string? blog_category, bool? favorite);
    public QueryList<Blog> AllBlogSite(int queryNum, int pageNum, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time);
    public Blog GetBlogById(int id);
    public Blog GetBlogByIdSite(int id);
    public int CreateBlog(Blog blog);
    public bool UpdateBlog(int id, Blog blog);
    public bool DeleteBlog(int id);



    //BlogTranslation CRUD
    public QueryList<BlogTranslation> AllBlogTranslation(int queryNum, int pageNum, string language_code, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time);
    public QueryList<BlogTranslation> AllBlogTranslationSelect(string language_code, string? blog_category, bool? favorite);
    public QueryList<BlogTranslation> AllBlogTranslationSite(int queryNum, int pageNum, string language_code, string? blog_category, bool? favorite, DateTime? start_time, DateTime? end_time);
    public BlogTranslation GetBlogTranslationById(int id);
    public BlogTranslation GetBlogTranslationByIdSite(int id);
    public BlogTranslation GetBlogTranslationById(int uz_id, string language_code);
    public BlogTranslation GetBlogTranslationByIdSite(int uz_id, string language_code);
    public int CreateBlogTranslation(BlogTranslation blogTranslation);
    public bool UpdateBlogTranslation(int id, BlogTranslation blog);
    public bool DeleteBlogTranslation(int id);
    public bool SaveChanges();

}
