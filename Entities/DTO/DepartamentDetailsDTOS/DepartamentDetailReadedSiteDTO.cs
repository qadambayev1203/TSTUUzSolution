using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;

namespace Entities.DTO.DepartamentDetailsDTOS;

public class DepartamentDetailReadedSiteDTO
{
    public int id { get; set; }
    public string? text_json { get; set; }
    public DepartamentConfReadedDTO? departament_ { get; set; }
}
