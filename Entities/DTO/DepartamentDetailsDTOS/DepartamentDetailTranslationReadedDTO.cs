using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentDetailConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.DepartamentDetailsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentDetailsDTOS
{
    public class DepartamentDetailTranslationReadedDTO
    {
        public int id { get; set; }
        public string? text_json { get; set; }
        public LanguageConfReadedDTO? languages_ { get; set; }
        public DepartamentTranslationConfReadedDTO? departament_translation_ { get; set; }
        public DepartamentDetailConfRededDTO? departament_detail_ { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }

    }
}
