using Entities.DTO.PersonDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.PersonDataDTOS;

public class PersonDataTranslationSearchDTO
{
    public int id { get; set; }
    public int? persons_data_id { get; set; }
    public PersonfioTranslationDTO? persons_translation_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
