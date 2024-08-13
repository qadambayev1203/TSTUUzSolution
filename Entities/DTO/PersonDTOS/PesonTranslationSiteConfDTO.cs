using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;

namespace Entities.DTO.PersonDTOS;

public class PesonTranslationSiteConfDTO
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? fathers_name { get; set; }
    public PesonConfDTO? persons_ { get; set; }
    public int? persons_id { get; set; }
    public GenderTranslationConfReadedDTO? gender_ { get; set; }
    public DepartamentTranslationConfReadedDTO? departament_translation_ { get; set; }
    public EmployeeTypeTranslationConfReadedDTO? employee_type_translation_ { get; set; }
}
