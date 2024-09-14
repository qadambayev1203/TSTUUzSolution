using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.BlogsDTOS;

public class BlogTranslationSearchDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
