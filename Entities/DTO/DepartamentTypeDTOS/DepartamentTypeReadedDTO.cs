using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.DepartamentTypeDTOS;

public class DepartamentTypeReadedDTO
{
    public int id { get; set; }
    public string? type { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
