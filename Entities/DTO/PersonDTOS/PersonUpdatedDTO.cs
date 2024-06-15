using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PersonDTOS
{
    public class PersonUpdatedDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fathers_name { get; set; }
        public string? email { get; set; }
        public int gender_id { get; set; }
        public string? pinfl { get; set; }
        public string? passport_text { get; set; }
        public string? passport_number { get; set; }
        public int status_id { get; set; }
        public IFormFile? img_up { get; set; }
        public required int departament_id { get; set; }
        public required int employee_type_id { get; set; }
    }
}
