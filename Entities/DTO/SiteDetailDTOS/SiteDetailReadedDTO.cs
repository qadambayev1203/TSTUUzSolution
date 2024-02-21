using Entities.Model.FileModel;
using Entities.Model.SitesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteDetailDTOS
{
    public class SiteDetailReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public Files? logo_w_ { get; set; }
        public Files? logo_b_ { get; set; }
        public Files? favicon_ { get; set; }
        public string? socials { get; set; }
        public string? details { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public Site? site_ { get; set; }
        public Status? status_ { get; set; }
    }
}
