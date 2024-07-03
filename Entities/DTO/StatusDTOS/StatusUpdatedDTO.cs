using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StatusDTOS
{
    public class StatusUpdatedDTO
    {
        public string status { get; set; }
        public string? name { get; set; }
        public bool is_deleted { get; set; }
    }
}
