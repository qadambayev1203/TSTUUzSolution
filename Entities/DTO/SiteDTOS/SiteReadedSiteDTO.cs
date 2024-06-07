using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;

namespace Entities.DTO.SiteDTOS
{
    public class SiteReadedSiteDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public SiteTypeConfReadedDTO? site_type_ { get; set; }
    }
}
