using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.DistrictsDTOS;

public class DistrictTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? district_id { get; set; }
}
