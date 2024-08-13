using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.PageDTOS;

public class PageTranslationReadedSelectDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? page_id { get; set; }
}
