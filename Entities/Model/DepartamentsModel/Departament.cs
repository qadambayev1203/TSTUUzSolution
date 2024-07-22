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

namespace Entities.Model.DepartamentsModel
{
    public class Departament
    {
        public int id { get; set; }
        [MaxLength(250)] public string? title_short { get; set; }
        [MaxLength(500)] public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public int? parent_id { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
        public DateTime? crated_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        [ForeignKey("Files")] public int? img_id { get; set; }
        public Files? img_ { get; set; }
        [ForeignKey("Files")] public int? img_icon_id { get; set; }
        public Files? img_icon_ { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
        [ForeignKey("DepartamentType")] public int? departament_type_id { get; set; }
        public DepartamentType? departament_type_ { get; set; }
        [MaxLength(100)] public string? hemis_id { get; set; }
    }
}
