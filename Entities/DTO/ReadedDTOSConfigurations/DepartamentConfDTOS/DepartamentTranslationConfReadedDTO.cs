using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS
{
    public class DepartamentTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public int? parent_id { get; set; }
        public DepartamentTypeTranslationConfReadedDTO? departament_translation_type_ { get; set; }

    }
}
