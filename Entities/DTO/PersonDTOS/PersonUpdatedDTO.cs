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
    public class PersonUpdatedDTO
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        public string? email { get; set; }
        public int? gender_id { get; set; }
        public string? pinfl { get; set; }
        public string? passport_text { get; set; }
        public string? passport_number { get; set; }
        public int? status_id { get; set; }
        public int? files_id { get; set; }
    }
}
