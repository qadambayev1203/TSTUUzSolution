using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.RectorGivenDTOS;

public class RectorGivenGetDTO
{
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public DateTime? crated_at { get; set; } 
    public DateTime? updated_at { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public FileConfReadedDTO? img_icon_ { get; set; }
    public bool? favorite { get; set; }
}
