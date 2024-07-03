using Entities.Model.DepartamentsModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;

namespace Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS
{
    public class UserConfReadedDTO
    {
        public int id { get; set; }
        public UserTypeConfReadedDTO? user_type_ { get; set; }

    }
}
