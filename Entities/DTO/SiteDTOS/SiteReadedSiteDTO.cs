using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;

namespace Entities.DTO.SiteDTOS;

public class SiteReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public SiteTypeConfReadedDTO? site_type_ { get; set; }
}
