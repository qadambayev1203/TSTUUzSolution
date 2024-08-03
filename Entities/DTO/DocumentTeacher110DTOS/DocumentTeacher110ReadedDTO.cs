using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110DTOS
{
    public class DocumentTeacher110ReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int? parent_id { get; set; }
        public bool? indicator { get; set; }
        public double? max_score { get; set; }
        public string? description { get; set; }
    }
}
