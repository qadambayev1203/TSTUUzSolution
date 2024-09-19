using Entities.DTO.EmployeeTypesDTOS;
using Entities.Model.EmployeeTypesModel;

namespace Entities.DTO.PersonDTOS;

public class PersonRectorConfReadedDTOAll
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? fathers_name { get; set; }
    public string? email { get; set; }
    public EmployeeTypeReadedSiteDTO? employee_type_ { get; set; }
}
