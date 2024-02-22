using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.DepartamentsModel
{
    public class DepartamentTranslation
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public int? parent_id { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public DateTime? crated_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        [ForeignKey("FilesTranslation")] public int? img_id { get; set; }
        public FilesTranslation? img_ { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
        [ForeignKey("DepartamentTypeTranslation")] public int? departament_type_translation_id { get; set; }
        public DepartamentTypeTranslation? departament_translation_type_ { get; set; }
    }
}
