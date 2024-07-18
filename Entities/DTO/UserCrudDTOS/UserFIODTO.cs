using Entities.DTO.PersonDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PersonsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserCrudDTOS
{
    public class UserFIODTO
    {
        public int id { get; set; }
        public UserTypeConfReadedDTO? user_type_ { get; set; }
        public PersonUserDTO? person_ { get; set; }
    }
}
