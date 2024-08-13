using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.MenuTypesDTOS;

public class MenuTypeReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
