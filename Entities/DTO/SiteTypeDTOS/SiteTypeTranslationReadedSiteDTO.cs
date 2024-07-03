using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.LanguagesModel;
using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteTypeDTOS
{
    public class SiteTypeTranslationReadedSiteDTO
    {
        public int id { get; set; }
        public SiteTypeConfReadedDTO? site_type_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public string? type { get; set; }
    }
}
