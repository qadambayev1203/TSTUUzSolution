using Entities.DTO.FilesDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteDetailDTOS
{
    public class SiteDetailCreatedDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public IFormFile? logo_w_up { get; set; }
        public IFormFile? logo_b_up { get; set; }
        public IFormFile? favicon_up { get; set; }
        public string socials { get; set; }
        public string details { get; set; }
        public int site_id { get; set; }
    }
}
