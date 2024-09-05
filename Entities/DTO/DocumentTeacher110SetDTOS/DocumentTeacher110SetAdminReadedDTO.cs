using Entities.DTO.DocumentTeacher110DTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.UserCrudDTOS;

namespace Entities.DTO.DocumentTeacher110SetDTOS;

public class DocumentTeacher110SetAdminReadedDTO
{
    public int id { get; set; }
    public int? old_year { get; set; }
    public int? new_year { get; set; }
    public DocumentTeacher110ReadedDTO? document_ { get; set; }
    public FileConfReadedDTO? file_ { get; set; }
    public string? comment { get; set; }
    public double? score { get; set; }
    public bool? rejection { get; set; }
    public string? reason_for_rejection { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
    public UserFIODTO? assessor_ { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
}
