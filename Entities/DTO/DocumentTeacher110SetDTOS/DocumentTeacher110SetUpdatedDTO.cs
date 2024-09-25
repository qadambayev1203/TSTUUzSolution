using Microsoft.AspNetCore.Http;

namespace Entities.DTO.DocumentTeacher110SetDTOS;

public class DocumentTeacher110SetUpdatedDTO
{
    public required int old_year { get; set; }
    public required int new_year { get; set; }
    public required int document_id { get; set; }
    public IFormFile? file_up { get; set; }
    public string? comment { get; set; }
    public required DateTime fixed_date { get; set; }
    public required bool avtor { get; set; }
    public int? number_authors { get; set; }
}
