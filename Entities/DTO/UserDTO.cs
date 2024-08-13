using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using Entities.DTO.PersonDTOS;

namespace Entities.DTO;

public class UserDTO
{
    public int id { get; set; }
    public required string login { get; set; }
    public UserTypeConfReadedDTO? user_type_ { get; set; }
    public PersonUserReadedDTO? person_ { get; set; }

}
