using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.Model.DepartamentsTypeModel;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentTranslationStructureReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public int? parent_id { get; set; }
    public int? departament_id { get; set; }
    public DepartamentTypeTranslationConfReadedDTO? departament_type_translation_ { get; set; }
}
