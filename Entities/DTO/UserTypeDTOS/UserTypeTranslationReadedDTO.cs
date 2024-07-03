using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.UserTypeDTOS
{
    public class UserTypeTranslationReadedDTO
    {
        public int id { get; set; }
        public string? type { get; set; }
        public UserTypeConfReadedDTO? user_types_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    }
}
