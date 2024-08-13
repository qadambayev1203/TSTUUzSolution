using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.EmploymentsDTOS;

public class EmploymentTranslationReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public EmploymentReadedDTO? employment_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO status_translation_ { get; set; }
}
