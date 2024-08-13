using Entities.DTO.FilesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.StatisticalNumbersDTOS;

public class StatisticalNumbersTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string numbers { get; set; }
    public FileTranslationSelectDTO? icon_ { get; set; }
    public StatisticalNumbersReadedConfDTO? statistical_numbers_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
