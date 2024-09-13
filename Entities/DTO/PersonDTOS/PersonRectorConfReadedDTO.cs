using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;

namespace Entities.DTO.PersonDTOS
{
    public class PersonRectorConfReadedDTO
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        public string? email { get; set; }
        public string? pinfl { get; set; }
        public string? passport_text { get; set; }
        public string? passport_number { get; set; }
        public FileConfReadedDTO? img_ { get; set; }
        public GenderConfReadedDTO? gender_ { get; set; }
    }
}
