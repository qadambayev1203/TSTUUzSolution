using Microsoft.AspNetCore.Http;

namespace Entities.DTO.DepartamentDTOS;

public class DepartamentTranslationUpdatedHeadDepDTO
{
    public string title_short { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string text { get; set; }
    public IFormFile? img_up { get; set; }
    public IFormFile? img_icon_up { get; set; }
    public bool favorite { get; set; }
}
