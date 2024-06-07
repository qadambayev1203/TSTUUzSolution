using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.FileModel;
using Entities.Model.SitesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteDetailDTOS
{
    public class SiteDetailReadedSiteDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public FileConfReadedDTO? logo_w_ { get; set; }
        public FileConfReadedDTO? logo_b_ { get; set; }
        public FileConfReadedDTO? favicon_ { get; set; }
        public string? socials { get; set; }
        public string? details { get; set; }
        public SiteConfReadedDTO? site_ { get; set; }
    }
}
