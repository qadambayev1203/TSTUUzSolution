namespace Entities.DTO.PersonDataDTOS.PersonBlogDTOS;

public class PersonBlogUpdatedDTO
{
    public required string title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? status_id { get; set; }
}
