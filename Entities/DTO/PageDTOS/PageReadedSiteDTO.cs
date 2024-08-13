using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.PageDTOS;

public class PageReadedSiteDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
}
