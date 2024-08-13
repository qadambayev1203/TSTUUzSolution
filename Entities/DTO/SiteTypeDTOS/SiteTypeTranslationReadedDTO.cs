using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.SiteTypeDTOS;

public class SiteTypeTranslationReadedDTO
{
    public int id { get; set; }
    public SiteTypeConfReadedDTO? site_type_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public string? type { get; set; }
}
