using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.CountrysDTOS;

public class CountryReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public StatusConfReadedDTO status_ { get; set; }

}
