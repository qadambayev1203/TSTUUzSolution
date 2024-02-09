using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.GenderDTOS
{
    public class PersonReadedDTO
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        public string? email { get; set; }
        public Gender? gender_ { get; set; }
        public string? pinfl { get; set; }
        public string? passport_text { get; set; }
        public string? passport_number { get; set; }
        public Status? status_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.Now;
        public DateTime? updated_at { get; set; }
        public Files? img_ { get; set; }
    }
}
