using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.StatusDTOS;

public class StatusTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? status { get; set; }
    public string? name { get; set; }
    public int? status_id { get; set; }

    public LanguageConfReadedDTO? language_ { get; set; }
}
