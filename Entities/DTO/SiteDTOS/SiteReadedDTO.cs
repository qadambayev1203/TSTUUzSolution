﻿using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;

namespace Entities.DTO.SiteDTOS;

public class SiteReadedDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
    public SiteTypeConfReadedDTO? site_type_ { get; set; }
    public UserConfReadedDTO? user_ { get; set; }
    public DateTime? created_at { get; set; } 
    public DateTime? updated_at { get; set; }
}
