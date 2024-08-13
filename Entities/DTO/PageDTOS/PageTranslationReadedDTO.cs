using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.PageDTOS;

public class PageTranslationReadedDTO
{
    public int id { get; set; }
    public string? title_short { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public PageConfReadDTO? page_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
    public FileTranslationConfReadedDTO? img_translation_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    public UserConfReadedDTO? user_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
}
