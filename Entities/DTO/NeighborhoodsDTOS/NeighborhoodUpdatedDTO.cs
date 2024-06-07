using Entities.Model.DistrictsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.NeighborhoodsDTOS
{
    public class NeighborhoodUpdatedDTO
    {
        public int district_id { get; set; }
        public string title { get; set; }
        public int status_id { get; set; }
    }
}
