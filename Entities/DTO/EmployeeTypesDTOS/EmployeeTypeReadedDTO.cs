using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.EmployeeTypesDTOS;

public class EmployeeTypeReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
