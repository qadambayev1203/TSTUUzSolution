namespace Entities.DTO.PersonDTOS;

public class PersonTranslationUpdatedDataDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fathers_name { get; set; }
    public int gender_id { get; set; }
    public required int employee_type_translation_id { get; set; }
    public required int departament_translation_id { get; set; }
}
