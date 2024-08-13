using Microsoft.AspNetCore.Http;

namespace Entities.DTO.InteractiveServicesDTOS;

public class InteractiveServicesTranslationCreatedDTO
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? url_ { get; set; }
    public int? interactive_services_id { get; set; }
    public bool? favorite { get; set; }
    public IFormFile? img_up { get; set; }
    public IFormFile? icon_up { get; set; }
    public int? language_id { get; set; }

}
