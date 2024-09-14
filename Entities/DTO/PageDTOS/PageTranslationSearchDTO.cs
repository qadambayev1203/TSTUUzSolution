using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.PageDTOS;

public class PageTranslationSearchDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
