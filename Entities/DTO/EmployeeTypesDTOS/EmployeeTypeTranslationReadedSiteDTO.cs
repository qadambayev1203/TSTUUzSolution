using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.EmployeeTypesDTOS;

public class EmployeeTypeTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public EmployeeTypeReadedSiteDTO? employee_ { get; set; }
    public LanguageConfReadedDTO language_ { get; set; }

}
