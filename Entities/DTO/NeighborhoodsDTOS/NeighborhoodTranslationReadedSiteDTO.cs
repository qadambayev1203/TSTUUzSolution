using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.NeighborhoodsDTOS;

public class NeighborhoodTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? neighborhood_id { get; set; }
}
