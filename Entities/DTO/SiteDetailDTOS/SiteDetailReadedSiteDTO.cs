using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;

namespace Entities.DTO.SiteDetailDTOS;

public class SiteDetailReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public FileConfReadedDTO? logo_w_ { get; set; }
    public FileConfReadedDTO? logo_b_ { get; set; }
    public FileConfReadedDTO? favicon_ { get; set; }
    public string? socials { get; set; }
    public string? details { get; set; }
    public SiteConfReadedDTO? site_ { get; set; }
}
