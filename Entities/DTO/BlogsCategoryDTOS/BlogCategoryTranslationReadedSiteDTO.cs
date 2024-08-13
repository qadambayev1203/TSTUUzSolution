using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.BlogsCategoryDTOS;

public class BlogCategoryTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? blog_category_id { get; set; }
    public BlogCategoryReadedConfDTO? blog_category_ { get; set; }
}
