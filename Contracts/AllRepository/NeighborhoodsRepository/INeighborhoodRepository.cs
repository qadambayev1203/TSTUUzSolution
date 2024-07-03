using Entities.Model.NeighborhoodsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.NeighborhoodsRepository
{
    public interface INeighborhoodRepository
    {
        //Neighborhood CRUD
        public IEnumerable<Neighborhood> AllNeighborhood(int? district_id);
        public IEnumerable<Neighborhood> AllNeighborhood(int queryNum, int pageNum);
        public IEnumerable<Neighborhood> AllNeighborhoodSite(int district_id);
        public Neighborhood GetNeighborhoodById(int id);
        public Neighborhood GetNeighborhoodByIdSite(int id);
        public int CreateNeighborhood(Neighborhood neighborhood);
        public bool UpdateNeighborhood(int id, Neighborhood neighborhood);
        public bool DeleteNeighborhood(int id);



        //NeighborhoodTranslation CRUD
        public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslation(int? district_translation_id, string language_code);
        public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslation(int queryNum, int pageNum, string language_code);
        public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslationSite(int district_translation_id, string langiage_code);
        public NeighborhoodTranslation GetNeighborhoodTranslationById(int id);
        public NeighborhoodTranslation GetNeighborhoodTranslationById(int uz_id, string language_code);
        public NeighborhoodTranslation GetNeighborhoodTranslationByIdSite(int uz_id, string language_code);
        public NeighborhoodTranslation GetNeighborhoodTranslationByIdSite(int id);
        public int CreateNeighborhoodTranslation(NeighborhoodTranslation neighborhoodTranslation);
        public bool UpdateNeighborhoodTranslation(int id, NeighborhoodTranslation neighborhoodTranslation);
        public bool DeleteNeighborhoodTranslation(int id);




        public bool SaveChanges();

    }
}
