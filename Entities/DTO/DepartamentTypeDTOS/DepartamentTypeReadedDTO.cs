using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentTypeDTOS
{
    public class DepartamentTypeReadedDTO
    {
        public int id { get; set; }
        public string? type { get; set; }
        public Status? status_ { get; set; }
    }
}
