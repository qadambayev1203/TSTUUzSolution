namespace Entities.DTO.PersonDataDTOS.PersonScientificActivityDTOS;

public class PersonScientificActivityTranslationUpdatedAdminDTO
{
    public required int since_when { get; set; }
    public int? until_when { get; set; }
    public required string whom { get; set; }
    public required string where { get; set; }
    public required int person_scientific_activity_id { get; set; }
    public required int person_data_translation_id { get; set; }
    public required int language_id { get; set; }
    public required int status_translation_id { get; set; }

}
