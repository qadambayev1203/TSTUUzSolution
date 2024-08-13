using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.TerritoriesDTOS;

public class TerritorieTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? territorie_id { get; set; }
}
