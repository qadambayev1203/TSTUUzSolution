using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.EmploymentModel;
using Entities.Model.LanguagesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmploymentsDTOS
{
    public class EmploymentTranslationReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public EmploymentReadedDTO? employment_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public StatusTranslationConfReadedDTO status_translation_ { get; set; }
    }
}
