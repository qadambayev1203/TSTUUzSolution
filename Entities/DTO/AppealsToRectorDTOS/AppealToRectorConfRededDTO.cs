using Entities.DTO.EmploymentsDTOS;
using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.NeighborhoodConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppealsToRectorDTOS
{
    public class AppealToRectorConfRededDTO
    {
        public int id { get; set; }
        public string addres { get; set; }
        public string fio_ { get; set; }
        public string email { get; set; }
        public string appeal { get; set; }
    }
}
