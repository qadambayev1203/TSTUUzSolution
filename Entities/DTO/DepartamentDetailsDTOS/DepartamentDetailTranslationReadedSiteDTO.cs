using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.DepartamentDetailsDTOS;

public class DepartamentDetailTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? text_json { get; set; }
    public LanguageConfReadedDTO? languages_ { get; set; }
    public int? departament_detail_id { get; set; }
    public DepartamentTranslationConfReadedDTO? departament_translation_ { get; set; }

}
