using Entities.Model.DistrictsModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.NeighborhoodsModel
{
    public class NeighborhoodTranslation
    {
        public int id { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("Neighborhood")] public int? neighborhood_id { get; set; }
        public Neighborhood neighborhood_ { get; set; }
        [ForeignKey("DistrictTranslation")] public int? district_translation_id { get; set; }
        public DistrictTranslation? district_translation_ { get; set; }
        [MaxLength(250)] public string title { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
