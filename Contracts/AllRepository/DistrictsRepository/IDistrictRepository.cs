using Entities.Model.DistrictsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.DistrictsRepository
{
    public interface IDistrictRepository
    {
        //District CRUD
        public IEnumerable<District> AllDistrict(int? territorie_id);
        public IEnumerable<District> AllDistrictSite(int territorie_id);
        public District GetDistrictById(int id);
        public District GetDistrictByIdSite(int id);
        public int CreateDistrict(District district);
        public bool UpdateDistrict(int id, District district);
        public bool DeleteDistrict(int id);



        //DistrictTranslation CRUD
        public IEnumerable<DistrictTranslation> AllDistrictTranslation(int? territorie_translation_id, string language_code);
        public IEnumerable<DistrictTranslation> AllDistrictTranslationSite(int territorie_translation_id, string language_code);
        public DistrictTranslation GetDistrictTranslationById(int id);
        public DistrictTranslation GetDistrictTranslationById(int uz_id, string language_code);
        public DistrictTranslation GetDistrictTranslationByIdSite(int uz_id, string language_code);
        public DistrictTranslation GetDistrictTranslationByIdSite(int id);
        public int CreateDistrictTranslation(DistrictTranslation districtTranslation);
        public bool UpdateDistrictTranslation(int id, DistrictTranslation districtTranslation);
        public bool DeleteDistrictTranslation(int id);




        public bool SaveChanges();
    }
}
