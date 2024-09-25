using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentReadedHeadDepDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? parent_id { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public FileConfReadedDTO? img_icon_ { get; set; }
    public bool? favorite { get; set; }

}
