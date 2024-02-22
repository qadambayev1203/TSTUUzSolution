using Entities.Model.BlogsCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.BlogsCategoryRepository
{
    public interface IBlogCategoryRepository
    {
        //BlogCategory CRUD
        public IEnumerable<BlogCategory> AllBlogCategory(int queryNum, int pageNum);
        public BlogCategory GetBlogCategoryById(int id);
        public bool CreateBlogCategory(BlogCategory blogCategory);
        public bool UpdateBlogCategory(int id, BlogCategory blogCategory);
        public bool DeleteBlogCategory(int id);



        //BlogCategoryTranslation CRUD
        public IEnumerable<BlogCategoryTranslation> AllBlogCategoryTranslation(int queryNum, int pageNum);
        public BlogCategoryTranslation GetBlogCategoryTranslationById(int id);
        public bool CreateBlogCategoryTranslation(BlogCategoryTranslation blogCategoryTranslation);
        public bool UpdateBlogCategoryTranslation(int id, BlogCategoryTranslation blogCategoryTranslation);
        public bool DeleteBlogCategoryTranslation(int id);
    }
}
