namespace Entities.DTO.PersonDataDTOS.PersonBlogDTOS;

public class PersonBlogCreatedAdminDTO
{
    public required string title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? person_data_id { get; set; }
}
