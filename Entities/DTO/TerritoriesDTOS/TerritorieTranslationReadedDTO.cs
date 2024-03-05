using Entities.DTO.CountrysDTOS;
using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
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
    public class TerritorieTranslationReadedDTO
    {
        public int id { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public TerritorieConfReadedDTO territorie_ { get; set; }
        public string title { get; set; }
        public CountryTranslationReadedConfDTO country_translation_ { get; set; }
    }
}
