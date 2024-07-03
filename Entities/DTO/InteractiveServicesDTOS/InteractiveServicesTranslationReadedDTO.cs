using Entities.DTO.FilesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.EmploymentModel;
using Entities.Model.FileModel;
using Entities.Model.InteractiveServicesModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.InteractiveServicesDTOS
{
    public class InteractiveServicesTranslationReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? url_ { get; set; }
        public bool? favorite { get; set; }
        public InteractiveServicesReadedConfDTO? interactive_services_ { get; set; }
        public FileTranslationSelectDTO? img_ { get; set; }
        public FileTranslationSelectDTO? icon_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    }
}
