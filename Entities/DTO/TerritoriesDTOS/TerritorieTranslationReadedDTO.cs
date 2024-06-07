using Entities.DTO.CountrysDTOS;
using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
using Entities.DTO.SiteDTOS;
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
        public string title { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public SiteTranslationConfReadedDTO status_ { get; set; }
        public int? territorie_id { get; set; }
    }
}
