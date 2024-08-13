using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.DistrictsDTOS;

public class DistrictReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
