using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.LanguagesModel;
using Entities.Model.SitesModel;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;

namespace Entities.DTO.SiteDTOS
{
    public class SiteTranslationReadedDTO
    {
        public int id { get; set; }
        public SiteConfReadedDTO? site_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
        public SiteTypeTranslationConfDTO? site_type_translation_ { get; set; }
        public UserConfReadedDTO? user_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
    }
}
