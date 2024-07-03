using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.SiteTypeConfDTOS;

namespace Entities.DTO.ReadedDTOSConfigurations.SiteConfDTOS
{
    public class SiteConfReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
    }
}
