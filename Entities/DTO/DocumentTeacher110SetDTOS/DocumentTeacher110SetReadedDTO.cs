using Entities.DTO.DocumentTeacher110DTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110SetDTOS
{
    public class DocumentTeacher110SetReadedDTO
    {
        public int id { get; set; }
        public int? old_year { get; set; }
        public int? new_year { get; set; }
        public DocumentTeacher110ReadedDTO? document_ { get; set; }
        public FileConfReadedDTO? file_ { get; set; }
        public string? comment { get; set; }
        public double? score { get; set; }
        public bool? rejection { get; set; }
        public string? reason_for_rejection { get; set; }
    }
}
