using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.DepartamentTypeDTOS;

public class DepartamentTypeTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? type { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public DepartamentTypeConfReadedDTO? departament_type_ { get; set; }
}
