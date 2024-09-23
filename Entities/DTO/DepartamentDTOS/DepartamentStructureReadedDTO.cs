using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentStructureReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public int? parent_id { get; set; }
    public DepartamentTypeConfReadedDTO? departament_type_ { get; set; }
}
