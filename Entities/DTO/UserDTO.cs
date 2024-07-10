using Entities.Model.DepartamentsModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using Entities.DTO.PersonDTOS;

namespace Entities.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public required string login { get; set; }
        public UserTypeConfReadedDTO? user_type_ { get; set; }
        public PersonUserReadedDTO? person_ { get; set; }

    }
}
