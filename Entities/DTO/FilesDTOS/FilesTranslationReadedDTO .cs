using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;

namespace Entities.DTO.FilesDTOS;

public class FilesTranslationReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public DateTime? crated_at { get; set; } 
    public DateTime? updated_at { get; set; }
    public FileConfReadedDTO? files_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public UserConfReadedDTO? user_ { get; set; }
}
