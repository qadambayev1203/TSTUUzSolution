using Entities.DTO.CountrysDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.CountrysModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.TerritoriesDTOS
{
    public class TerritorieReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public StatusConfReadedDTO status_ { get; set; }
    }
}
