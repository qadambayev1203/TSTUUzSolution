using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.AppealsToEmployeeDTOS
{
    public class AppealToEmployeeReadedDTO
    {
        public int id { get; set; }
        public string? full_name { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public DateTime? created_at { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
    }
}
