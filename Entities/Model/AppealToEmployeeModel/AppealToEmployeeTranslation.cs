using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.LanguagesModel;

namespace Entities.Model.AppealToEmployeeModel
{
    public class AppealToEmployeeTranslation
    {
        public int id { get; set; }
        [MaxLength(150)] public string? full_name { get; set; }
        [MaxLength(150)] public string? email { get; set; }
        [MaxLength(250)] public string? subject { get; set; }
        public string? message { get; set; }
        public DateTime? created_at { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_id { get; set; }
        public StatusTranslation? status_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; }
    }
}
