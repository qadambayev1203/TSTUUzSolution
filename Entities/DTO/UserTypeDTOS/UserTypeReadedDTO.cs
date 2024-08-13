using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.UserTypeDTOS;

public class UserTypeReadedDTO
{
    public int id { get; set; }
    public string? type { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
