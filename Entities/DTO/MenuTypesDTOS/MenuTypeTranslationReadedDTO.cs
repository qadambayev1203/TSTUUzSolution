using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuTypesConfDTO;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.MenuTypesDTOS;

public class MenuTypeTranslationReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public MenuTypeConfReadedDTO? menu_type_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
