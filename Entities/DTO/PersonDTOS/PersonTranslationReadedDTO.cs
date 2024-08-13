using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PersonsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.PersonDTOS;

public class PersonTranslationReadedDTO
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? fathers_name { get; set; }
    public GenderTranslationConfReadedDTO? gender_ { get; set; }
    public PersonReadedConfigurDTO? persons_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public EmployeeTypeTranslationConfReadedDTO? employee_type_translation_ { get; set; }
    public DepartamentTranslationConfReadedDTO? departament_translation_ { get; set; }
}
