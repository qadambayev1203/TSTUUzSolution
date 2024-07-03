using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DistrictsDTOS
{
    public class DistrictTranslationCreatedDTO
    {
        public int language_id { get; set; }
        public int district_id { get; set; }
        public string title { get; set; }
        public int status_translation_id { get; set; }
    }
}
