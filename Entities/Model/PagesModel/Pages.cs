using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.PagesModel
{
    public class Pages
    {
        public int id { get; set; }
        [MaxLength(250)] public string? title_short { get; set; }
        [MaxLength(500)] public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
        public DateTime? crated_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        [ForeignKey("Files")] public int? img_id { get; set; }
        public Files? img_ { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; }
       
    }
}
