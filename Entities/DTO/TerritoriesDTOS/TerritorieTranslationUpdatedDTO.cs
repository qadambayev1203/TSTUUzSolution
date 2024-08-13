namespace Entities.DTO.TerritoriesDTOS;

public class TerritorieTranslationUpdatedDTO
{
    public int language_id { get; set; }
    public int territorie_id { get; set; }
    public string title { get; set; }
    public int country_translation_id { get; set; }
    public int status_translation_id { get; set; }
}
