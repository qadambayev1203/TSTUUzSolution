using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.FilesDTOS
{
    public class FileTranslationSelectDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public int? files_id { get; set; }
    }
}
