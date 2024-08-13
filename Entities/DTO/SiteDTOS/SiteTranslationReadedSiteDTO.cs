using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;

namespace Entities.DTO.SiteDTOS;

public class SiteTranslationReadedSiteDTO
{
    public int id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public SiteTypeTranslationConfDTO? site_type_translation_ { get; set; }
    public int? site_id { get; set; }
}
