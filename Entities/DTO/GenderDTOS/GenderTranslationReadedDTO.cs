using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.GenderDTOS;

public class GenderTranslationReadedDTO
{
    public int id { get; set; }
    public string? gender { get; set; }
    public GenderConfReadedDTO? gender_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO status_translation_ { get; set; }
}
