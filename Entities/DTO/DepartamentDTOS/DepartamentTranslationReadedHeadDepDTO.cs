using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.FilesDTOS;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentTranslationReadedHeadDepDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? parent_id { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public FileTranslationSelectDTO? img_ { get; set; }
    public FileTranslationSelectDTO? img_icon_ { get; set; }
    public bool? favorite { get; set; }
    public int? departament_id { get; set; }
}
