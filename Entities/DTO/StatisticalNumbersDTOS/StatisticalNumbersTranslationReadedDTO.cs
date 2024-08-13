using Entities.DTO.FilesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.StatisticalNumbersDTOS;

public class StatisticalNumbersTranslationReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string numbers { get; set; }
    public FileTranslationSelectDTO? icon_ { get; set; }
    public StatisticalNumbersReadedConfDTO? statistical_numbers_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
}
