using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.DepartamentsTypeModel
{
    public class DepartamentTypeTranslation
    {
        public int id { get; set; }
        [MaxLength(300)] public string? type { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        [ForeignKey("DepartamentType")] public int? departament_type_id { get; set; }
        public DepartamentType? departament_type_ { get; set; }
    }
}

