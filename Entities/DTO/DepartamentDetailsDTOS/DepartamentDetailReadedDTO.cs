using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.DepartamentDetailsDTOS;

public class DepartamentDetailReadedDTO
{
    public int id { get; set; }
    public string? text_json { get; set; }
    public DepartamentConfReadedDTO? departament_ { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
