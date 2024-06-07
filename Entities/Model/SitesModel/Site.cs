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
    public class Site
    {
        public int id { get; set; }
        [MaxLength(500)] public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
        [ForeignKey("SiteType")] public int? site_type_id { get; set; }
        public SiteType? site_type_ { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
    }

}
