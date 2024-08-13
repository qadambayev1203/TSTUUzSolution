using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.PageDTOS;

public class PageReadedSelectDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }       
    public StatusConfReadedDTO? status_ { get; set; }
   
}
