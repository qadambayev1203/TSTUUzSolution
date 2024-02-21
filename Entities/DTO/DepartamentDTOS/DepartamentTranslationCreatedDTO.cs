using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentDTOS
{
    public class DepartamentTranslationCreatedDTO
    {
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public int? parent_id { get; set; }
        public int? language_id { get; set; }
        public int? status_translation_id { get; set; }
        public int? files_translation_id { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
        public int? user_id { get; set; }
        public int? departament_type_translation_id { get; set; }

    }
}
