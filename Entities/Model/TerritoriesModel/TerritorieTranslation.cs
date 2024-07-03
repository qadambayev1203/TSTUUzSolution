using Entities.Model.CountrysModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.TerritoriesModel
{
    public class TerritorieTranslation
    {
        public int id { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("Territorie")] public int? territorie_id { get; set; }
        public Territorie territorie_ { get; set; }
        [MaxLength(250)] public string title { get; set; }
        [ForeignKey("CountryTranslation")] public int? country_translation_id { get; set; }
        public CountryTranslation country_translation_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
