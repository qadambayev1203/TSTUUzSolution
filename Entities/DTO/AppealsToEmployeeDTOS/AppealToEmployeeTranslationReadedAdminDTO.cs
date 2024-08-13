using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.UserCrudDTOS;

namespace Entities.DTO.AppealsToEmployeeDTOS;

public class AppealToEmployeeTranslationReadedAdminDTO
{
    public int id { get; set; }
    public string? full_name { get; set; }
    public string? email { get; set; }
    public string? subject { get; set; }
    public string? message { get; set; }
    public DateTime? created_at { get; set; }
    public StatusTranslationConfReadedDTO? status_ { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public UserFIODTO? user_ { get; set; }
}
