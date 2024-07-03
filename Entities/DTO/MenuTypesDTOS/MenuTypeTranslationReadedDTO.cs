using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuTypesConfDTO;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.LanguagesModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.MenuTypesDTOS
{
    public class MenuTypeTranslationReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public MenuTypeConfReadedDTO? menu_type_ { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
    }
}
