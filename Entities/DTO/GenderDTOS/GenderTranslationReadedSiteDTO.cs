using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.GenderDTOS;

public class GenderTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? gender { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? gender_id { get; set; }
    public GenderConfReadedDTO? gender_ { get; set; }
}
