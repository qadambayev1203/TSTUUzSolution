namespace Entities.DTO.NeighborhoodsDTOS;

public class NeighborhoodTranslationUpdatedDTO
{
    public int language_id { get; set; }
    public int neighborhood_id { get; set; }
    public int district_translation_id { get; set; }
    public string title { get; set; }
    public int status_translation_id { get; set; }
}
