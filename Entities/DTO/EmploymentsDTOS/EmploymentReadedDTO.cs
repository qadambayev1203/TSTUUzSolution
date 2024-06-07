using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmploymentsDTOS
{
    public class EmploymentReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public StatusConfReadedDTO status_ { get; set; }
    }
}
