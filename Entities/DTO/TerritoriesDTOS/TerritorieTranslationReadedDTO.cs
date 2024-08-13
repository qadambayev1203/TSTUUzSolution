using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;

namespace Entities.DTO.TerritoriesDTOS;

public class TerritorieTranslationReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public SiteTranslationConfReadedDTO status_ { get; set; }
    public int? territorie_id { get; set; }
}
