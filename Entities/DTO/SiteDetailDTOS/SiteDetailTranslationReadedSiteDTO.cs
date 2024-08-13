using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;

namespace Entities.DTO.SiteDetailDTOS;

public class SiteDetailTranslationReadedSiteDTO
{
    public int id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public FileTranslationConfReadedDTO? logo_w_ { get; set; }
    public FileTranslationConfReadedDTO? logo_b_ { get; set; }
    public FileTranslationConfReadedDTO? favicon_ { get; set; }
    public string? socials { get; set; }
    public string? details { get; set; }
    public SiteTranslationConfReadedDTO? site_translation_ { get; set; }
    public int? site_detail_id { get; set; }
}
