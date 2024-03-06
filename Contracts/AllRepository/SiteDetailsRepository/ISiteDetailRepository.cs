using Entities.Model.SiteDetailsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.SiteDetailsRepository
{
    public interface ISiteDetailRepository
    {
        //SiteDetail CRUD
        public IEnumerable<SiteDetail> AllSiteDetail(int queryNum, int pageNum);
        public SiteDetail GetSiteDetailById(int id);
        public int CreateSiteDetail(SiteDetail siteDetail);
        public bool UpdateSiteDetail();
        public bool DeleteSiteDetail(int id);



        //SiteDetailTranslation CRUD
        public IEnumerable<SiteDetailTranslation> AllSiteDetailTranslation(int queryNum, int pageNum, string language_code);
        public SiteDetailTranslation GetSiteDetailTranslationById(int id);
        public int CreateSiteDetailTranslation(SiteDetailTranslation siteDetailTranslation);
        public bool UpdateSiteDetailTranslation();
        public bool DeleteSiteDetailTranslation(int id);
        public bool SaveChanges();

    }
}
