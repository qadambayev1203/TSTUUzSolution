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

namespace Entities.Model.CountrysModel
{
    public class CountryTranslation
    {
        public int id { get; set; }

        [MaxLength(250)]
        public string title { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("Country")] public int? country_id { get; set; }
        public Country country_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
