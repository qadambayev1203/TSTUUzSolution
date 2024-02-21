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
        public bool CreateSite(Site site);
        public bool UpdateSite(Site site, int id);
        public bool DeleteSite(int id);



        //SiteTranslation CRUD
        public IEnumerable<SiteTranslation> AllSiteTranslation(int queryNum, int pageNum);
        public SiteTranslation GetSiteTranslationById(int id);
        public bool CreateSiteTranslation(SiteTranslation siteTranslation);
        public bool UpdateSiteTranslation(SiteTranslation siteTranslation, int id);
        public bool DeleteSiteTranslation(int id);
    }
}
