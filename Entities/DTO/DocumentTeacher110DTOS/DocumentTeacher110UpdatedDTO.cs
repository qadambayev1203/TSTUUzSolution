using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DocumentTeacher110DTOS
{
    public class DocumentTeacher110UpdatedDTO
    {
        public required string title { get; set; }
        public required int parent_id { get; set; }
        public required bool indicator { get; set; }
        public required double max_score { get; set; }
        public string? description { get; set; }
        public List<DocumentSequenceItemDTO>? document_sequence { get; set; }
        public int? status_id { get; set; }
    }
}
