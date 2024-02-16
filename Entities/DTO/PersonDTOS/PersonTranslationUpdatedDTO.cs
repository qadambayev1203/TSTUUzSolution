using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PersonDTOS
{
    public class PersonTranslationUpdatedDTO
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        public int? gender_id { get; set; }
        public int? persons_id { get; set; }
        public int? languages_id { get; set; }
        public int? status_translation_id { get; set; }
    }
}
