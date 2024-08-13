using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;

namespace Entities.DTO.SiteTypeDTOS;

public class SiteTypeTranslationReadedSiteDTO
{
    public int id { get; set; }
    public SiteTypeConfReadedDTO? site_type_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public string? type { get; set; }
}
