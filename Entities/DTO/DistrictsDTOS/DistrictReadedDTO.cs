using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DistrictsDTOS
{
    public class DistrictReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public StatusConfReadedDTO status_ { get; set; }
    }
}
