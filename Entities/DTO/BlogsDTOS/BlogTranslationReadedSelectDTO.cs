using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.BlogsDTOS;

public class BlogTranslationReadedSelectDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public int? blog_id { get; set; }
    public DateTime? event_date { get; set; }
    public DateTime? event_end_date { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
   
}
