namespace Entities.DTO.SiteDTOS;

public class SiteTranslationCreatedDTO
{
    public int site_id { get; set; }
    public int language_id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int site_type_translation_id { get; set; }
}
