using Entities.Model.SiteTypesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.SiteTypesRepository
{
    public interface ISiteTypeRepository
    {
        //SiteType CRUD
        public IEnumerable<SiteType> AllSiteType(int queryNum, int pageNum);
        public IEnumerable<SiteType> AllSiteTypeSite(int queryNum, int pageNum);
        public SiteType GetSiteTypeById(int id);
        public SiteType GetSiteTypeByIdSite(int id);
        public int CreateSiteType(SiteType siteType);
        public bool UpdateSiteType(int id, SiteType siteType);
        public bool DeleteSiteType(int id);



        //SiteTypeTranslation CRUD
        public IEnumerable<SiteTypeTranslation> AllSiteTypeTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<SiteTypeTranslation> AllSiteTypeTranslationSite(int queryNum, int pageNum, string language_code);
        public SiteTypeTranslation GetSiteTypeTranslationById(int id);
        public SiteTypeTranslation GetSiteTypeTranslationById(int uz_id, string language_code);
        public SiteTypeTranslation GetSiteTypeTranslationByIdSite(int uz_id, string language_code);
        public SiteTypeTranslation GetSiteTypeTranslationByIdSite(int id);
        public int CreateSiteTypeTranslation(SiteTypeTranslation siteTypeTranslation);
        public bool UpdateSiteTypeTranslation(int id, SiteTypeTranslation siteType);
        public bool DeleteSiteTypeTranslation(int id);

        public bool SaveChanges();

    }
}
