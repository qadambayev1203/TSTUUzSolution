using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;

namespace Entities.DTO.BlogsDTOS;

public class BlogSearchDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
}
