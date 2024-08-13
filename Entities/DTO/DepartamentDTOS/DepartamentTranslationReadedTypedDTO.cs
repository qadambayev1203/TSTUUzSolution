using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentTranslationReadedTypedDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public DepartamentTypeTranslationConfReadedDTO? departament_type_translation_ { get; set; }
    public DepartamentConfReadedDTO? departament_ { get; set; }
}
