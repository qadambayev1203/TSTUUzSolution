using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteTypeDTOS
{
    public class SiteTypeReadedDTO
    {
        public int id { get; set; }
        public string? type { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
    }
}
