using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? parent_id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public FileTranslationConfReadedDTO? img_ { get; set; }
    public FileTranslationConfReadedDTO? img_icon_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    public DepartamentTypeTranslationConfReadedDTO? departament_type_translation_ { get; set; }
    public DepartamentConfReadedDTO? departament_ { get; set; }
}
