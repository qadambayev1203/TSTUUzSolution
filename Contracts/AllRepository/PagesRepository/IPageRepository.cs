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
        public bool CreatePage(Pages page);
        public bool UpdatePage(int id,Pages page);
        public bool DeletePage(int id);



        //PageTranslation CRUD
        public IEnumerable<PageTranslation> AllPageTranslation(int queryNum, int pageNum);
        public PageTranslation GetPageTranslationById(int id);
        public bool CreatePageTranslation(PageTranslation pageTranslation);
        public bool UpdatePageTranslation(int id,PageTranslation pageTranslation);
        public bool DeletePageTranslation(int id);
    }
}
