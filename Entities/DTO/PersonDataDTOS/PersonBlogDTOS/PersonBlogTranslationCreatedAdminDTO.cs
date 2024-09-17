namespace Entities.DTO.PersonDataDTOS.PersonBlogDTOS;

public class PersonBlogTranslationCreatedAdminDTO
{
    public int id { get; set; }
    public required string title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public required int person_data_id { get; set; }
    public required int language_id { get; set; }
    public required int person_blog_id { get; set; }
}
