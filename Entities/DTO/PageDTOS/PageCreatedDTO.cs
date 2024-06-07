using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PageDTOS
{
    public class PageCreatedDTO
    {
        public string title_short { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string text { get; set; }
        public IFormFile? img_up { get; set; }
        public int? position { get; set; }
        public bool favorite { get; set; }
    }
}
