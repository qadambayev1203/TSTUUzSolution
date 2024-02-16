using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentDTOS
{
    public class DepartamentTranslationReadedDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public int? parent_id { get; set; }
        public Language? languages_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public DateTime? crated_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        public FilesTranslation? img_ { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
        public User? user_ { get; set; }
        public DepartamentTypeTranslation? departament_translation_type_ { get; set; }
    }
}
