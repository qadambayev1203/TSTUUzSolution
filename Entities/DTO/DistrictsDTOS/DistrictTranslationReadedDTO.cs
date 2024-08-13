using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.DistrictsDTOS;

public class DistrictTranslationReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? district_id { get; set; }
    public StatusTranslationConfReadedDTO status_translation_ { get; set; }
}
