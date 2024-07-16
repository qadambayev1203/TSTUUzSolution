using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentTypeConfDTOS;

namespace Entities.DTO.DepartamentDTOS
{
    public class DepartamentTranslationStructureReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int? parent_id { get; set; }
        public int? departament_id { get; set; }

    }
}
