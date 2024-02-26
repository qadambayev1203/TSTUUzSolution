using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
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
        public FileConfReadedDTO? img_ { get; set; }
    }
}
