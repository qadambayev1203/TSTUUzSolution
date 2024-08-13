using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.EmployeeTypesDTOS;

public class EmployeeTypeTranslationReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public EmployeeTypeReadedSiteDTO? employee_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO status_translation_ { get; set; }

}
