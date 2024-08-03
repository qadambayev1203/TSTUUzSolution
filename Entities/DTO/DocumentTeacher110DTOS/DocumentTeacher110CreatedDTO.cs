using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110DTOS
{
    public class DocumentTeacher110CreatedDTO
    {
        public string? title { get; set; }
        public int? parent_id { get; set; }
        public bool? indicator { get; set; }
        public double? max_score { get; set; }
        public string? description { get; set; }
        public List<DocumentSequenceItemDTO>? document_sequence { get; set; }
    }
   
}
