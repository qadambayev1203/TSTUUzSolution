using Entities.Model.DepartamentsModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentDetailsDTOS
{
    public class DepartamentDetailUpdatedDTO
    {
        public string text_json { get; set; }
        public required int departament_id { get; set; }
        public int status_id { get; set; }
    }
}
