using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentReadedDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? hemis_id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? parent_id { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public FileConfReadedDTO? img_icon_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    public DepartamentTypeConfReadedDTO? departament_type_ { get; set; }


}
