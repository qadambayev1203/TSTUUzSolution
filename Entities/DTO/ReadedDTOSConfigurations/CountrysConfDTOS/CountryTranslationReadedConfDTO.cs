using Entities.DTO.CountrysDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS
{
    public class CountryTranslationReadedConfDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? country_id { get; set; }
    }
}
