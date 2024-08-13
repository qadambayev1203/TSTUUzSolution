using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.NeighborhoodsDTOS;

public class NeighborhoodTranslationReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? neighborhood_id { get; set; }
    public StatusTranslationConfReadedDTO status_translation_ { get; set; }
}
