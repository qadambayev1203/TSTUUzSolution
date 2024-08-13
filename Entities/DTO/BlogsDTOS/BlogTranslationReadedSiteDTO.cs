using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.BlogsDTOS;

public class BlogTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public DateTime? event_date { get; set; }
    public DateTime? event_end_date { get; set; }
    public FileTranslationConfReadedDTO? img_translation_ { get; set; }
    public BlogCategoryTranslationReadedConfDTO? blog_category_translation_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? blog_id { get; set; }
}
