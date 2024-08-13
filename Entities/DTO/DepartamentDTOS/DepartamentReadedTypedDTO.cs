using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentReadedTypedDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
    public DepartamentTypeConfReadedDTO? departament_type_ { get; set; }

}
