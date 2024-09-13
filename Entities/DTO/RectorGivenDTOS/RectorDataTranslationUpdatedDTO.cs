using Entities.DTO.PersonDTOS;

namespace Entities.DTO.RectorGivenDTOS;

public class RectorDataTranslationUpdatedDTO
{
    public PersonTranslationRectorUpdatedDataDTO? persons_translation_ { get; set; }
    public string? biography_json { get; set; }
    public DateTime? birthday { get; set; }
    public string? degree { get; set; }
    public string? scientific_title { get; set; }
    public int? experience_year { get; set; }
    public string? phone_number1 { get; set; }
    public string? phone_number2 { get; set; }
    public string? orchid { get; set; }
    public string? scopus_id { get; set; }
    public string? address { get; set; }
    public int? languages_uz { get; set; }
    public int? languages_en { get; set; }
    public int? languages_ru { get; set; }
    public string? languages_any_title { get; set; }
    public int? languages_any { get; set; }
    public int? language_id { get; set; }
}
