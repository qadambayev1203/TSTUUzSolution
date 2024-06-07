using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.NeighborhoodConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.DistrictsModel;
using Entities.Model.LanguagesModel;
using Entities.Model.NeighborhoodsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.NeighborhoodsDTOS
{
    public class NeighborhoodTranslationReadedIdDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public NeighborhoodConfReadedDTO neighborhood_ { get; set; }
        public DistrictTranslationConfReadedDTO district_translation_ { get; set; }

        public StatusTranslationConfReadedDTO status_translation_ { get; set; }
    }
}
