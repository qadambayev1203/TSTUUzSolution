using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.MenuTypesDTOS;

public class MenuTypeTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? menu_type_id { get; set; }
}
