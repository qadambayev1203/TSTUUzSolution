using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.DistrictsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.NeighborhoodsDTOS
{
    public class NeighborhoodReadedIdDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public DistrictConfReadedDTO? district_ { get; set; }
        public StatusConfReadedDTO status_ { get; set; }
    }
}
