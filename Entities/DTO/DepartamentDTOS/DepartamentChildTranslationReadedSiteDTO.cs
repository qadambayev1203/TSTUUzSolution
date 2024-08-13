using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentChildTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }        
    public int? parent_id { get; set; }
    public int? departament_id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public DepartamentTypeTranslationConfReadedDTO? departament_type_translation_ { get; set; }
}
