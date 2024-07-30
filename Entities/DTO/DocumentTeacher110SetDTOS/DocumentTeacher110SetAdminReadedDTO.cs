using Entities.DTO.DocumentTeacher110DTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.DocumentTeacher110Model;
using Entities.Model.FileModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110SetDTOS
{
    public class DocumentTeacher110SetAdminReadedDTO
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
        public StatusConfReadedDTO? status_ { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
