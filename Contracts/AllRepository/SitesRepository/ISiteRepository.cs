using Entities.Model.SitesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.SitesRepository
{
    public interface ISiteRepository
    {
        //Site CRUD
        public IEnumerable<Site> AllSite(int queryNum, int pageNum);
        public Site GetSiteById(int id);
        public int CreateSite(Site site);
        public bool UpdateSite();
        public bool DeleteSite(int id);



        //SiteTranslation CRUD
        public IEnumerable<SiteTranslation> AllSiteTranslation(int queryNum, int pageNum, string language_code);
        public SiteTranslation GetSiteTranslationById(int id);
        public int CreateSiteTranslation(SiteTranslation siteTranslation);
        public bool UpdateSiteTranslation();
        public bool DeleteSiteTranslation(int id);
        public bool SaveChanges();

    }
}
