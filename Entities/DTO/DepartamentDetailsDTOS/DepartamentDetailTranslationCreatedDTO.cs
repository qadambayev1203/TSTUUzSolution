namespace Entities.DTO.DepartamentDetailsDTOS;

public class DepartamentDetailTranslationCreatedDTO
{
    public string text_json { get; set; }
    public int language_id { get; set; }
    public required int departament_translation_id { get; set; }
    public int departament_detail_id { get; set; }

}
