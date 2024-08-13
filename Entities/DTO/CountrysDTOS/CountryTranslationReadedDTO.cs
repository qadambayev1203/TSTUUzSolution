using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.CountrysDTOS;

public class CountryTranslationReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public int? country_id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO status_translation_ { get; set; }
}
