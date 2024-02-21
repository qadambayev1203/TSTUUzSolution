using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentDetailsDTOS
{
    public class DepartamentDetailTranslationUpdatedDTO
    {
        public string text_json { get; set; }
        public int language_id { get; set; }
        public required int departament_translation_id { get; set; }
        public int departament_detail_id { get; set; }
        public int status_translation_id { get; set; }
    }
}
