using Entities.DTO.PersonDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserProfilDTOS
{
    public class UserProfilUpdatedDTO
    {
        public string login { get; set; }
        public string password { get; set; }
        public string oldPassword { get; set; }
        public PersonUserProfilUpdatedDTO? person_ { get; set; }
        public IFormFile? img_up { get; set; }
    }
}
