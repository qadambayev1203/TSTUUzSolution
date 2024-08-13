using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.TerritoriesDTOS;

public class TerritorieReadedIdDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public CountryReadedConfDTO country_ { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
