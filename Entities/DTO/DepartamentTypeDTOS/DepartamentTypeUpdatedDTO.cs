using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentTypeDTOS
{
    public class DepartamentTypeUpdatedDTO
    {
        public string type { get; set; }
        public int status_id { get; set; }
    }
}
