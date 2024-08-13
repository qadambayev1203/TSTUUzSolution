using Microsoft.AspNetCore.Http;

namespace Entities.DTO.FilesDTOS;

public class FilesTranslationCreatedDTO
{
    public string title { get; set; }
    public IFormFile url { get; set; }
    public int? files_id { get; set; }
    public int language_id { get; set; }
}
