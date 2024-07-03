using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;

namespace Entities.DTO.FilesDTOS
{
    public class FilesReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public DateTime? crated_at { get; set; } = DateTime.Now;
        public DateTime? updated_at { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
        public UserConfReadedDTO? user_ { get; set; }
    }
}
