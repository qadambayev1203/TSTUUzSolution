using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.DepartamentsModel;
using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PersonsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;

namespace Entities.DTO.UserCrudDTOS
{
    public class UserCrudReadedDTO
    {
        public int id { get; set; }
        public required string login { get; set; }
        public required string password { get; set; }
        public string? email { get; set; }
        public UserTypeConfReadedDTO? user_type_ { get; set; }
        public PersonConfReadedDTO? person_ { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
        public bool? removed { get; set; }
        public bool? active { get; set; }
    }
}
