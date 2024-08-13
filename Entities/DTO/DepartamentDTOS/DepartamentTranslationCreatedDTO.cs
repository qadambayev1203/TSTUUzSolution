using Microsoft.AspNetCore.Http;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentTranslationCreatedDTO
{
    public string title_short { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string text { get; set; }
    public int parent_id { get; set; }
    public int language_id { get; set; }
    public IFormFile? img_up { get; set; }
    public IFormFile? img_icon_up { get; set; }
    public int? position { get; set; }
    public bool favorite { get; set; }
    public int departament_type_translation_id { get; set; }
    public int departament_id { get; set; }

}
