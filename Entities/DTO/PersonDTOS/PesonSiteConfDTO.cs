using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;

namespace Entities.DTO.PersonDTOS;

public class PesonSiteConfDTO
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fathers_name { get; set; }
    public string email { get; set; }
    public GenderConfReadedDTO? gender_ { get; set; }
    public DepartamentConfReadedDTO? departament_ { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public EmployeeTypeReadedSiteDTO? employee_type_ { get; set; }

}
