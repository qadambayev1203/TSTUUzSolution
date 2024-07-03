using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
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
    public class DepartamentDetailReadedDTO
    {
        public int id { get; set; }
        public string? text_json { get; set; }
        public DepartamentConfReadedDTO? departament_ { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
    }
}
