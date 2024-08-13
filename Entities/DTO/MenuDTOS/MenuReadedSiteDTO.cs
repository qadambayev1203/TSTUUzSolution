using Entities.DTO.ReadedDTOSConfigurations.BlogConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuTypesConfDTO;
using Entities.DTO.ReadedDTOSConfigurations.PageConfDTOS;

namespace Entities.DTO.MenuDTOS;

public class MenuReadedSiteDTO
{
    public int id { get; set; }
    public int parent_id { get; set; }
    public int? position { get; set; }
    public int? high_menu { get; set; }
    public MenuTypeConfReadedDTO? menu_type_ { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public FileConfReadedDTO? icon_ { get; set; }
    public string? link_ { get; set; }
    public bool top_menu { get; set; }
    public BlogConfRededDTO? blog_ { get; set; }
    public PageConfReadDTO? page_ { get; set; }
    public DepartamentConfReadedDTO? departament_ { get; set; }

}
