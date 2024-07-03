using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.GenderDTOS
{
    public class GenderTranslationReadedSiteDTO
    {
        public int id { get; set; }
        public string? gender { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public int? gender_id { get; set; }
        public GenderConfReadedDTO? gender_ { get; set; }
    }
}
