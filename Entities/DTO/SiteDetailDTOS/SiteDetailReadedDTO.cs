using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.SiteDetailDTOS;

public class SiteDetailReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public FileConfReadedDTO? logo_w_ { get; set; }
    public FileConfReadedDTO? logo_b_ { get; set; }
    public FileConfReadedDTO? favicon_ { get; set; }
    public string? socials { get; set; }
    public string? details { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? update_at { get; set; }
    public SiteConfReadedDTO? site_ { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
