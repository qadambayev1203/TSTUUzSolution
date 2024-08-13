using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.MenuDTOS;

public class MenuTranslationCreatedDTO
{
    public int? menu_id { get; set; }
    public int? parent_id { get; set; }
    public int? position { get; set; }
    public int? high_menu { get; set; }
    public IFormFile? icon_upload { get; set; }
    public int? menu_type_translation_id { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    public string? description { get; set; }
    public string? link_ { get; set; }
    public bool top_menu { get; set; }
    public int? blog_translation_id { get; set; }
    public int? page_translation_id { get; set; }
    public int? departament_translation_id { get; set; }
    public int? language_id { get; set; }
}
