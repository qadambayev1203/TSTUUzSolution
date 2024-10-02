using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentSearchDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public DepartamentTypeConfReadedDTO? departament_type_ { get; set; }
}
