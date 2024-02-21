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

namespace Entities.DTO.SiteDTOS
{
    public class SiteTranslationReadedDTO
    {
        public int id { get; set; }
        public Site? site_ { get; set; }
        public Language? language_ { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public SiteTypeTranslation? site_type_translation_ { get; set; }
        public User? user_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
    }
}
