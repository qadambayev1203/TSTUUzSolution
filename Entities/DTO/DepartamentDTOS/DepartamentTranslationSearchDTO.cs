using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentTranslationSearchDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
