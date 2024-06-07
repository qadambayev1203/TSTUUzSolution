using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS
{
    public class DepartamentTypeTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string? type { get; set; }
        public int? departament_type_id { get; set; }
    }
}
