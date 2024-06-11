using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.AllRepository.TerritoriesRepository
{
    public interface ITerritorieRepository
    {
        //Territorie CRUD
        public IEnumerable<Territorie> AllTerritorie(int? country_id);
        public IEnumerable<Territorie> AllTerritorieSite(int country_id);
        public Territorie GetTerritorieById(int id);
        public Territorie GetTerritorieByIdSite(int id);
        public int CreateTerritorie(Territorie territorie);
        public bool UpdateTerritorie(int id, Territorie territorie);
        public bool DeleteTerritorie(int id);



        //TerritorieTranslation CRUD
        public IEnumerable<TerritorieTranslation> AllTerritorieTranslation(int? country_translation_id, string language_code);
        public IEnumerable<TerritorieTranslation> AllTerritorieTranslationSite(int country_translation_id, string language_code);
        public TerritorieTranslation GetTerritorieTranslationById(int id);
        public TerritorieTranslation GetTerritorieTranslationById(int uz_id, string language_code);
        public TerritorieTranslation GetTerritorieTranslationByIdSite(int uz_id, string language_code);
        public TerritorieTranslation GetTerritorieTranslationByIdSite(int id);
        public int CreateTerritorieTranslation(TerritorieTranslation territorieTranslation);
        public bool UpdateTerritorieTranslation(int id, TerritorieTranslation territorieTranslation);
        public bool DeleteTerritorieTranslation(int id);

        public bool SaveChanges();
    }
}
