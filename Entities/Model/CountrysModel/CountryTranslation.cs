using Entities.Model.LanguagesModel;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.CountrysModel
{
    public class CountryTranslation
    {
        public int id { get; set; }
        public string title { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("Country")] public int? country_id { get; set; }
        public Country country_ { get; set; }
    }
}
