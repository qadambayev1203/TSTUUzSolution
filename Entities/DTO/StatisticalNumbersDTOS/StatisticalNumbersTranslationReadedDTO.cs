using Entities.DTO.FilesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.EmploymentModel;
using Entities.Model.FileModel;
using Entities.Model.InteractiveServicesModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatisticalNumbersModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StatisticalNumbersDTOS
{
    public class StatisticalNumbersTranslationReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string numbers { get; set; }
        public FileTranslationSelectDTO? icon_ { get; set; }
        public StatisticalNumbersReadedConfDTO? statistical_numbers_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    }
}
