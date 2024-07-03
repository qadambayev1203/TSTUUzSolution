using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.CountrysModel;
using Entities.Model.LanguagesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.CountrysDTOS
{
    public class CountryTranslationReadedSiteDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? country_id { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
    }
}
