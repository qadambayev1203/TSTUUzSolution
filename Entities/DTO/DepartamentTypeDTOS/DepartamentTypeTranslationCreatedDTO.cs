using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentTypeDTOS
{
    public class DepartamentTypeTranslationCreatedDTO
    {
        public string? type { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        [ForeignKey("DepartamentType")] public int? departament_type_id { get; set; }
    }
}
