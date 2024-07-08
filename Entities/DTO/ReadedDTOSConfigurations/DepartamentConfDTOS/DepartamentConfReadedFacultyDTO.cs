using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;
using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS
{
    public class DepartamentConfReadedFacultyDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public int? parent_id { get; set; }
    }
}
