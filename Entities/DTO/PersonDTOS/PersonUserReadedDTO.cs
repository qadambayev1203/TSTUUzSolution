using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.PersonDTOS;

public class PersonUserReadedDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fathers_name { get; set; }
    public string email { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public EmployeeTypeReadedSiteDTO? employee_type_ { get; set; }
    public DepartamentConfReadedDTO? departament_ { get; set; }

}
