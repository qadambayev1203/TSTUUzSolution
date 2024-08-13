using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentReadedSiteDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? parent_id { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public FileConfReadedDTO? img_icon_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    public DepartamentTypeConfReadedDTO? departament_type_ { get; set; }

}
