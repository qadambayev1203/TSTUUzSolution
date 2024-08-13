using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.StatusDTOS;

public class StatusTranslationReadedDTO
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? status { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public bool? is_deleted { get; set; }
}
