using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.LanguagesModel
{
    public class Language
    {
        public int id { get; set; }
        [MaxLength(250)] public string? title { get; set; }
        [MaxLength(150)] public string? title_short { get; set; }
        [MaxLength(250)] public string? description { get; set; }
        [MaxLength(50)] public string? code { get; set; }
        public string? details { get; set; }
        [ForeignKey("Files")] public int? img_id { get; set; }
        public Files? img_ { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
    }
}
