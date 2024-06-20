using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.Model.FileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.PersonsConfDTOS
{
    public class PersonReadedConfigurDTO
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        public string? email { get; set; }
        public string? pinfl { get; set; }
        public string? passport_text { get; set; }
        public string? passport_number { get; set; }
        public GenderConfReadedDTO? gender_ { get; set; }
        public FileConfReadedDTO? img_ { get; set; }
        public EmployeeTypeReadedSiteDTO? employee_type_ { get; set; }
        public DepartamentConfReadedDTO? departament_ { get; set; }
    }
}
