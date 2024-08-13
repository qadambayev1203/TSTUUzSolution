using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.NeighborhoodsDTOS;

public class NeighborhoodReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
