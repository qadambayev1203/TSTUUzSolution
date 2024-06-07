using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmployeeTypesDTOS
{
    public class EmployeeTypeReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public StatusConfReadedDTO status_ { get; set; }
    }
}
