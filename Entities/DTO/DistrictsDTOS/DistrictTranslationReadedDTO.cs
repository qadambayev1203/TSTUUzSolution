using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
using Entities.Model.DistrictsModel;
using Entities.Model.LanguagesModel;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DistrictsDTOS
{
    public class DistrictTranslationReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public int? district_id { get; set; }
        public StatusTranslationConfReadedDTO status_translation_ { get; set; }
    }
}
