using Entities.Model.CountrysModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.TerritoriesDTOS
{
    public class TerritorieUpdatedDTO
    {
        public string title { get; set; }
        public int country_id { get; set; }
        public int status_id { get; set; }

    }
}
