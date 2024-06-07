using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StatusDTOS
{
    public class StatusTranslationReadedDTO
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public bool? is_deleted { get; set; }
    }
}
