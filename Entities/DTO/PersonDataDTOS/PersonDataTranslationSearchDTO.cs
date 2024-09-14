using Entities.DTO.PersonDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.PersonDataDTOS;

public class PersonDataTranslationSearchDTO
{
    public int id { get; set; }
    public PersonfioTranslationDTO? persons_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
