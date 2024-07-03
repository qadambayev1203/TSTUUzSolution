using Entities.Model.BlogsCategoryModel;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.DTO.BlogsDTOS
{
    public class BlogUpdatedDTO
    {
        public string title_short { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string text { get; set; }
        public int status_id { get; set; }
        public DateTime? event_date { get; set; }
        public DateTime? event_end_date { get; set; }
        public IFormFile? img_up { get; set; }
        public int blog_category_id { get; set; }
        public int? position { get; set; }
        public bool favorite { get; set; }
    }
}
