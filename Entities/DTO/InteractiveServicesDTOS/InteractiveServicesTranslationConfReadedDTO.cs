using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.Model.LanguagesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.InteractiveServicesDTOS
{
    public class InteractiveServicesTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public bool? favorite { get; set; }
        public string? url_ { get; set; }
    }
}
