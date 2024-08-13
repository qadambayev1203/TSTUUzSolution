using Microsoft.AspNetCore.Http;

namespace Entities.DTO.FilesDTOS;

public class FilesUpdatedDTO
{
    public string title { get; set; }
    public IFormFile? url { get; set; }
    public int status_id { get; set; }
}
