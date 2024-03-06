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
        public Pages GetPageById(int id);
        public int CreatePage(Pages page);
        public bool UpdatePage();
        public bool DeletePage(int id);



        //PageTranslation CRUD
        public IEnumerable<PageTranslation> AllPageTranslation(int queryNum, int pageNum, string language_code);
        public PageTranslation GetPageTranslationById(int id);
        public int CreatePageTranslation(PageTranslation pageTranslation);
        public bool UpdatePageTranslation();
        public bool DeletePageTranslation(int id);

        public bool SaveChanges();

    }
}
