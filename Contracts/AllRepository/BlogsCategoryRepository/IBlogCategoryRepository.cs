using Entities.Model.BlogsCategoryModel;

namespace Contracts.AllRepository.BlogsCategoryRepository;

public interface IBlogCategoryRepository
{
    //BlogCategory CRUD
    public IEnumerable<BlogCategory> AllBlogCategory(int queryNum, int pageNum);
    public BlogCategory GetBlogCategoryById(int id);
    public int CreateBlogCategory(BlogCategory blogCategory);
    public bool UpdateBlogCategory(int id, BlogCategory blogCategory);
    public bool DeleteBlogCategory(int id);

    public IEnumerable<BlogCategory> AllBlogCategorySite(int queryNum, int pageNum);
    public BlogCategory GetBlogCategoryByIdSite(int id);


    //BlogCategoryTranslation CRUD
    public IEnumerable<BlogCategoryTranslation> AllBlogCategoryTranslation(int queryNum, int pageNum, string language_code);
    public BlogCategoryTranslation GetBlogCategoryTranslationById(int id);
    public int CreateBlogCategoryTranslation(BlogCategoryTranslation blogCategoryTranslation);
    public bool UpdateBlogCategoryTranslation(int id, BlogCategoryTranslation blogCategoryTranslation);
    public bool DeleteBlogCategoryTranslation(int id);
    public BlogCategoryTranslation GetBlogCategoryTranslationById(int uz_id, string language_code);
    public BlogCategoryTranslation GetBlogCategoryTranslationByIdSite(int uz_id, string language_code);
    public IEnumerable<BlogCategoryTranslation> AllBlogCategoryTranslationSite(int queryNum, int pageNum, string language_code);
    public BlogCategoryTranslation GetBlogCategoryTranslationByIdSite(int id);
    public bool SaveChanges();
}
