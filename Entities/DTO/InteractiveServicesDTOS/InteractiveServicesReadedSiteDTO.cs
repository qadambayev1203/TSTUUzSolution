using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.InteractiveServicesDTOS;

public class InteractiveServicesReadedSiteDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url_ { get; set; }
    public bool? favorite { get; set; }
    public FileConfReadedDTO img_ { get; set; }
    public FileConfReadedDTO icon_ { get; set; }
}
