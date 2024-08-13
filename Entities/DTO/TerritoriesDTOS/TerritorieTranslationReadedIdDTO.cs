using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;

namespace Entities.DTO.TerritoriesDTOS;

public class TerritorieTranslationReadedIdDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public TerritorieConfReadedDTO territorie_ { get; set; }
    public CountryTranslationReadedConfDTO country_translation_ { get; set; }

    public StatusTranslationConfReadedDTO status_translation_ { get; set; }
}
