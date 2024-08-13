using Microsoft.AspNetCore.Http;

namespace Entities.DTO.StatisticalNumbersDTOS;

public class StatisticalNumbersTranslationUpdatedDTO
{
    public string title { get; set; }
    public string description { get; set; }
    public string numbers { get; set; }
    public IFormFile? icon_up { get; set; }
    public int? statistical_numbers_id { get; set; }
    public int? language_id { get; set; }
    public int? status_translation_id { get; set; }
}
