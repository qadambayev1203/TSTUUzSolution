using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentDetailsDTOS
{
    public class DepartamentDetailCreatedDTO
    {
        public string text_json { get; set; }
        public required int departament_id { get; set; }
    }
}

