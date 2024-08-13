using Microsoft.AspNetCore.Http;

namespace Entities.DTO.DocumentTeacher110SetDTOS;

public class DocumentTeacher110SetUpdatedDTO
{
    public required int old_year { get; set; }
    public required int new_year { get; set; }
    public required int document_id { get; set; }
    public required IFormFile file_up { get; set; }
    public string? comment { get; set; }
}
