using Microsoft.AspNetCore.Http;

namespace Entities.DTO.FilesDTOS;

public class FilesCreatedDTO
{
    public string title { get; set; }
    public IFormFile url { get; set; }
}
