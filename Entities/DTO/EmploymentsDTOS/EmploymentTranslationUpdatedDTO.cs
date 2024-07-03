using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmploymentsDTOS
{
    public class EmploymentTranslationUpdatedDTO
    {
        public string title { get; set; }
        public int employment_id { get; set; }
        public int language_id { get; set; }
        public int status_translation_id { get; set; }
    }
}
