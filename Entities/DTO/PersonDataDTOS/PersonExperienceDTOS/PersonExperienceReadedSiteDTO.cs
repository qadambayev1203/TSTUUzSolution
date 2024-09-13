using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.PersonDataDTOS.PersonExperienceDTOS;

public class PersonExperienceReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? person_data_id { get; set; }
    public DateTime? crated_at { get; set; } 
    public DateTime? updated_at { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
