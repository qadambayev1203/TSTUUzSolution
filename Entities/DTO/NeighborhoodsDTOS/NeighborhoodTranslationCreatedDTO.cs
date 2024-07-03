using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.NeighborhoodsDTOS
{
    public class NeighborhoodTranslationCreatedDTO
    {
        public int language_id { get; set; }
        public int neighborhood_id { get; set; }
        public int district_translation_id { get; set; }
        public string title { get; set; }
    }
}
