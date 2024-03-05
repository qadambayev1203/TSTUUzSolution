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
        public IEnumerable<Neighborhood> AllNeighborhood(int district_id);
        public Neighborhood GetNeighborhoodById(int id);
        public bool CreateNeighborhood(Neighborhood neighborhood);
        public bool UpdateNeighborhood(int id, Neighborhood neighborhood);
        public bool DeleteNeighborhood(int id);



        //NeighborhoodTranslation CRUD
        public IEnumerable<NeighborhoodTranslation> AllNeighborhoodTranslation(int district_translation_id);
        public NeighborhoodTranslation GetNeighborhoodTranslationById(int id);
        public bool CreateNeighborhoodTranslation(NeighborhoodTranslation neighborhoodTranslation);
        public bool UpdateNeighborhoodTranslation(int id, NeighborhoodTranslation neighborhoodTranslation);
        public bool DeleteNeighborhoodTranslation(int id);
    }
}
