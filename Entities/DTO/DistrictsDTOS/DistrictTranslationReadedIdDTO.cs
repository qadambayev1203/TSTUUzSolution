using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;

namespace Entities.DTO.DistrictsDTOS;

public class DistrictTranslationReadedIdDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public DistrictConfReadedDTO district_ { get; set; }
    public TerritorieTranslationConfReadedDTO territorie_translation_ { get; set; }
    public StatusTranslationConfReadedDTO status_translation_ { get; set; }
}
