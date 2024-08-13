using Microsoft.AspNetCore.Http;

namespace Entities.DTO.MenuDTOS;

public class MenuUpdatedDTO
{
    public int? parent_id { get; set; }
    public int? position { get; set; }
    public int? high_menu { get; set; }
    public int menu_type_id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public IFormFile? icon_upload { get; set; }
    public string? link_ { get; set; }
    public int status_id { get; set; }
    public bool top_menu { get; set; }
    public int? blog_id { get; set; }
    public int? page_id { get; set; }
    public int? departament_id { get; set; }
}
