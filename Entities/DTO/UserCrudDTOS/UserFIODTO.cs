using Entities.DTO.PersonDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;

namespace Entities.DTO.UserCrudDTOS;

public class UserFIODTO
{
    public int id { get; set; }
    public UserTypeConfReadedDTO? user_type_ { get; set; }
    public PersonUserDTO? person_ { get; set; }
}
