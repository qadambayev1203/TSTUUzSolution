using Entities.Model.LanguagesModel;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.DistrictsModel
{
    public class DistrictTranslation
    {
        public int id { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("District")] public int? district_id { get; set; }
        public District? district_ { get; set; }
        [ForeignKey("TerritorieTranslation")] public int? territorie_translation_id { get; set; }
        public TerritorieTranslation territorie_translation_ { get; set; }
        public string title { get; set; }


    }
}
