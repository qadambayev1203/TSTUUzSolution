using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;

namespace Entities.DTO.DistrictsDTOS;

public class DistrictReadedIdDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public TerritorieConfReadedDTO territorie_ { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
