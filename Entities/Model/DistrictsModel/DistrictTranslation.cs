using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(250)] public string title { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }


    }
}
