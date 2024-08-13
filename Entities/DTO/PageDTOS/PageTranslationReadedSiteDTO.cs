using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.PageDTOS;

public class PageTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? page_id { get; set; }
    public FileTranslationConfReadedDTO? img_translation_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
