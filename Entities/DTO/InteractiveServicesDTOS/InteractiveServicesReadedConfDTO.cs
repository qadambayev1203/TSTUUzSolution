using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;

namespace Entities.DTO.InteractiveServicesDTOS
{
    public class InteractiveServicesReadedConfDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool? favorite { get; set; }
        public string url_ { get; set; }
    }
}
