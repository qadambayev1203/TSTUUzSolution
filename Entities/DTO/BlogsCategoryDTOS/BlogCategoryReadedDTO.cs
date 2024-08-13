using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.BlogsCategoryDTOS;

public class BlogCategoryReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
