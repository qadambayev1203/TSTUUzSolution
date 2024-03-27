using Entities.DTO.FilesDTOS;
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
    public class SiteDetailUpdatedDTO
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public int? logo_w_id { get; set; }
        public int? logo_b_id { get; set; }
        public int? favicon_id { get; set; }
        public string? socials { get; set; }
        public string? details { get; set; }
        public int? site_id { get; set; }
        public int? status_id { get; set; }
    }
}
