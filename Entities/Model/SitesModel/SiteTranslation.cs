using Entities.Model.LanguagesModel;
using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.SitesModel
{
    public class SiteTranslation
    {
        public int id { get; set; }
        [ForeignKey("Site")] public int? site_id { get; set; }
        public Site? site_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [MaxLength(500)] public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        [ForeignKey("SiteTypeTranslation")] public int? site_type_translation_id { get; set; }
        public SiteTypeTranslation? site_type_translation_ { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
    }

}
