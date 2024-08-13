using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.EmploymentsDTOS;

public class EmploymentReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public StatusConfReadedDTO status_ { get; set; }
}
