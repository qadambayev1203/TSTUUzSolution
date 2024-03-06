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
        public SiteType GetSiteTypeById(int id);
        public int CreateSiteType(SiteType siteType);
        public bool UpdateSiteType();
        public bool DeleteSiteType(int id);



        //SiteTypeTranslation CRUD
        public IEnumerable<SiteTypeTranslation> AllSiteTypeTranslation(int queryNum, int pageNum, string language_code);
        public SiteTypeTranslation GetSiteTypeTranslationById(int id);
        public int CreateSiteTypeTranslation(SiteTypeTranslation siteTypeTranslation);
        public bool UpdateSiteTypeTranslation();
        public bool DeleteSiteTypeTranslation(int id);

        public bool SaveChanges();

    }
}
