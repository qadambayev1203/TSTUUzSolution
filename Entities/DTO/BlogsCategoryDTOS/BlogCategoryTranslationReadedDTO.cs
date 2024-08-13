using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.BlogsCategoryDTOS;

public class BlogCategoryTranslationReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public BlogCategoryReadedConfDTO? blog_category_ { get; set; }
}
