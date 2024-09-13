using Microsoft.AspNetCore.Http;

namespace Entities.DTO.RectorGivenDTOS;

public class RectorGivenTranslationUpdateDTO
{
    public string title_short { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string text { get; set; }
    public int language_id { get; set; }
    public IFormFile? img_up { get; set; }
    public IFormFile? img_icon_up { get; set; }
    public bool favorite { get; set; }
}
