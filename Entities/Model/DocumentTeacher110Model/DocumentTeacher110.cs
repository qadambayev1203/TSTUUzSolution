using Entities.DTO.DocumentTeacher110DTOS;
using Entities.Model.StatusModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.DocumentTeacher110Model
{
    public class DocumentTeacher110
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int? parent_id { get; set; }
        public bool? indicator { get; set; }
        public bool? one_indicator { get; set; }
        public bool? two_indicator { get; set; }
        public double? max_score { get; set; }
        public string? description { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }

        [NotMapped]
        public List<DocumentSequenceItemDTO>? document_sequence
        {
            get => string.IsNullOrEmpty(document_sequence_string)
                    ? null
                    : JsonConvert.DeserializeObject<List<DocumentSequenceItemDTO>>(document_sequence_string);
            set => document_sequence_string = JsonConvert.SerializeObject(value);
        }

        public string? document_sequence_string { get; set; }
    }
}
