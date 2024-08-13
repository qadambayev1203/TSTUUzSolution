using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.BlogsDTOS;

public class BlogReadedSelectDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public DateTime? event_date { get; set; }
    public DateTime? event_end_date { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
    
}
