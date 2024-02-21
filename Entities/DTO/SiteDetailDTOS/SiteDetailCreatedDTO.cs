using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteDetailDTOS
{
    public class SiteDetailCreatedDTO
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
