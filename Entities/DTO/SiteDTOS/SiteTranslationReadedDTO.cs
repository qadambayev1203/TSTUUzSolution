using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;

namespace Entities.DTO.SiteDTOS;

public class SiteTranslationReadedDTO
{
    public int id { get; set; }
    public SiteConfReadedDTO? site_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public SiteTypeTranslationConfDTO? site_type_translation_ { get; set; }
    public UserConfReadedDTO? user_ { get; set; }
    public DateTime? created_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
}
