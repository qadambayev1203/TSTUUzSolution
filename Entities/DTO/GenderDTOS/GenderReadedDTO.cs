using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.GenderDTOS;

public class GenderReadedDTO
{
    public int id { get; set; }
    public string? gender { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
