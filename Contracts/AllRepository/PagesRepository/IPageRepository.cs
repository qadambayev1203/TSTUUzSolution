using Entities.Model.PagesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.PagesRepository
{
    public interface IPageRepository
    {
        //Page CRUD
        public IEnumerable<Pages> AllPage(int queryNum, int pageNum);
        public IEnumerable<Pages> AllPageSelect();
        public IEnumerable<Pages> AllPageSite(int queryNum, int pageNum);
        public Pages GetPageById(int id);
        public Pages GetPageByIdSite(int id);
        public int CreatePage(Pages page);
        public bool UpdatePage(int id, Pages pages);
        public bool DeletePage(int id);



        //PageTranslation CRUD
        public IEnumerable<PageTranslation> AllPageTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<PageTranslation> AllPageTranslationSelect(string language_code);
        public IEnumerable<PageTranslation> AllPageTranslationSite(int queryNum, int pageNum, string language_code);
        public PageTranslation GetPageTranslationById(int id);
        public PageTranslation GetPageTranslationById(int uz_id, string language_code);
        public PageTranslation GetPageTranslationByIdSite(int uz_id, string language_code);
        public PageTranslation GetPageTranslationByIdSite(int id);
        public int CreatePageTranslation(PageTranslation pageTranslation);
        public bool UpdatePageTranslation(int id, PageTranslation pageTranslation);
        public bool DeletePageTranslation(int id);

        public bool SaveChanges();

    }
}
