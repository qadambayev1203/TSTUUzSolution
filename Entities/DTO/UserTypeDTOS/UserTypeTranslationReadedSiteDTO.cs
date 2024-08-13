using Entities.DTO.ReadedDTOSConfigurations.UserTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.UserTypeDTOS;

public class UserTypeTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? type { get; set; }
    public UserTypeConfReadedDTO? user_types_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
