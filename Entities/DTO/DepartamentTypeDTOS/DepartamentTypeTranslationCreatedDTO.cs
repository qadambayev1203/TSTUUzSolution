using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentTypeDTOS
{
    public class DepartamentTypeTranslationCreatedDTO
    {
        public string type { get; set; }
        public int language_id { get; set; }
        public int departament_type_id { get; set; }
    }
}
