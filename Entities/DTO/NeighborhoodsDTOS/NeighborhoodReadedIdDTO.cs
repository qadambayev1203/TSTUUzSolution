using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.NeighborhoodsDTOS;

public class NeighborhoodReadedIdDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public DistrictConfReadedDTO? district_ { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
