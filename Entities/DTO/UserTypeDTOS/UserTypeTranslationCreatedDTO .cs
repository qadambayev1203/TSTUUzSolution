using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.GenderDTOS
{
    public class UserTypeTranslationCreatedDTO
    {
        public string? type { get; set; }
        public int user_types_id { get; set; }
        public int? languages_id { get; set; }
        public int? status_translation_id { get; set; }
    }
}
