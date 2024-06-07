using Entities.Model.FileModel;
using Entities.Model.SitesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.SiteDetailsModel
{
    public class SiteDetail
    {
        public int id { get; set; }
        [MaxLength(500)] public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("Files")] public int? logo_w_id { get; set; }
        public Files? logo_w_ { get; set; }
        [ForeignKey("Files")] public int? logo_b_id { get; set; }
        public Files? logo_b_ { get; set; }
        [ForeignKey("Files")] public int? favicon_id { get; set; }
        public Files? favicon_ { get; set; }
        public string? socials { get; set; }
        public string? details { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? update_at { get; set; }
        [ForeignKey("Site")] public int? site_id { get; set; }
        public Site? site_ { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
    }
}
