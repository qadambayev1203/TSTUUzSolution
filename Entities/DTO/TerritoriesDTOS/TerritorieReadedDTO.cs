using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.TerritoriesDTOS;

public class TerritorieReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
