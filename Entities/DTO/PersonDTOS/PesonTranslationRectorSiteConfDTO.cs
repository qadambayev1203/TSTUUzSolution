using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;

namespace Entities.DTO.PersonDTOS;

public class PesonTranslationRectorSiteConfDTO
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? fathers_name { get; set; }
    public GenderTranslationConfReadedDTO? gender_ { get; set; }

}
