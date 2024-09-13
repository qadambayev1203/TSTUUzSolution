using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.RectorGivenDTOS;

public class RectorGivenTranslationGetDTO
{
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public DateTime? crated_at { get; set; } 
    public DateTime? updated_at { get; set; }
    public FileTranslationConfReadedDTO? img_ { get; set; }
    public FileTranslationConfReadedDTO? img_icon_ { get; set; }
    public bool? favorite { get; set; }
}
