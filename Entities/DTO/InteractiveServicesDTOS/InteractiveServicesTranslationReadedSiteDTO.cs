using Entities.DTO.FilesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.InteractiveServicesDTOS;

public class InteractiveServicesTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? url_ { get; set; }
    public bool? favorite { get; set; }
    public InteractiveServicesReadedConfDTO? interactive_services_ { get; set; }
    public FileTranslationSelectDTO? img_ { get; set; }
    public FileTranslationSelectDTO? icon_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
