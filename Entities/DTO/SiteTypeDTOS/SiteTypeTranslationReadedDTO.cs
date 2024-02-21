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
    public class SiteTypeTranslationReadedDTO
    {
        public int id { get; set; }
        public SiteType? site_type_ { get; set; }
        public Language? language_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public string? type { get; set; }
    }
}
