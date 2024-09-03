using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.PersonDataDTOS.PersonBlogDTOS;

public class PersonBlogReadedDTO
{
    public int id { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
    public int? person_data_id { get; set; }
    public DateTime? crated_at { get; set; } 
    public DateTime? updated_at { get; set; }
}
