using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.StatisticalNumbersDTOS;

public class StatisticalNumbersReadedSiteDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string numbers { get; set; }
    public FileConfReadedDTO icon_ { get; set; }
}
