using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.FilesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;

namespace Entities.DTO.DepartamentDTOS
{
    public class DepartamentTranslationReadedTypedDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public LanguageConfReadedDTO? languages_ { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
        public DepartamentTypeTranslationConfReadedDTO? departament_type_translation_ { get; set; }
        public DepartamentConfReadedDTO? departament_ { get; set; }
    }
}
