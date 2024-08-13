using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.SiteTypeDTOS;

public class SiteTypeReadedDTO
{
    public int id { get; set; }
    public string? type { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
