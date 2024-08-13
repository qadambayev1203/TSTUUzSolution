using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.LanguageDTOS;

public class LanguageReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? title_short { get; set; }
    public string? description { get; set; }
    public string? code { get; set; }
    public string? details { get; set; }
    public FileConfReadedDTO? img_ { get; set; }
}
