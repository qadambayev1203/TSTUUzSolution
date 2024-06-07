using Entities.Model.CountrysModel;
using Entities.Model.LanguagesModel;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.TerritoriesDTOS
{
    public class TerritorieTranslationUpdatedDTO
    {
        public int language_id { get; set; }
        public int territorie_id { get; set; }
        public string title { get; set; }
        public int country_translation_id { get; set; }
        public int status_translation_id { get; set; }
    }
}
