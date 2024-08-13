using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;

namespace Entities.DTO.BlogsDTOS;

public class BlogReadedSiteDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public DateTime? event_date { get; set; }
    public DateTime? event_end_date { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public BlogCategoryReadedConfDTO? blog_category_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
}
