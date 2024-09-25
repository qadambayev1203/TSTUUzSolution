using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.PersonDataDTOS.PersonScientificActivityDTOS;

public class PersonScientificActivityTranslationReadedProfilDTO
{
    public int id { get; set; }
    public int? since_when { get; set; }
    public int? until_when { get; set; }
    public string? whom { get; set; }
    public string? where { get; set; }
    public int? person_scientific_activity_id { get; set; }
    public int? person_data_translation_id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
}
