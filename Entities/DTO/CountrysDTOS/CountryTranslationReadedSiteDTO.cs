using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.CountrysDTOS;

public class CountryTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public int? country_id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
