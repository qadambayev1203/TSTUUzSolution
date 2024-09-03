namespace Entities.DTO.PersonDataDTOS.PersonExperienceDTOS;

public class PersonExperienceTranslationCreatedDTO
{
    public int id { get; set; }
    public required string title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? language_id { get; set; }
    public int? person_experience_id { get; set; }
}
