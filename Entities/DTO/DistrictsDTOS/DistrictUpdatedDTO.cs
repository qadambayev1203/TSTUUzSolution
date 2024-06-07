using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DistrictsDTOS
{
    public class DistrictUpdatedDTO
    {
        public int territorie_id { get; set; }
        public string title { get; set; }
        public int status_id { get; set; }
    }
}
