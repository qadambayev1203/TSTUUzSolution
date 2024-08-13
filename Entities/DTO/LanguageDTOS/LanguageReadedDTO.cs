using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.LanguageDTOS;

public class LanguageReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? title_short { get; set; }
    public string? description { get; set; }
    public string? code { get; set; }
    public string? details { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
