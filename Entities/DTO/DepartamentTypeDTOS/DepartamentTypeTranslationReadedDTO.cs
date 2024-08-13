using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.DepartamentTypeDTOS;

public class DepartamentTypeTranslationReadedDTO
{
    public int id { get; set; }
    public string? type { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public DepartamentTypeConfReadedDTO? departament_type_ { get; set; }
}
