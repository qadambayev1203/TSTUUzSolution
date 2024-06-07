using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS
{
    public class FileTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public int? files_id { get; set; }
        public FileConfReadedDTO? files_ { get; set; }

    }
}
