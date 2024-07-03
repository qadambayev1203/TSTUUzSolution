using Entities.Model.DepartamentsModel;
using Entities.Model.EmployeeTypesModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.PersonModel
{
    public class Person
    {
        public int id { get; set; }
        [MaxLength(150)] public string? firstName { get; set; }
        [MaxLength(150)]public string? lastName { get; set; }
        [MaxLength(150)]public string? fathers_name { get; set; }
        [MaxLength(250)]public string? email { get; set; }
        [ForeignKey("Gender")] public int? gender_id { get; set; }
        public Gender? gender_ { get; set; }
        public string? pinfl { get; set; }
        public string? passport_text { get; set; }
        public string? passport_number { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        [ForeignKey("Files")] public int? img_id { get; set; }
        public Files? img_ { get; set; }
        [ForeignKey("Departament")] public required int? departament_id { get; set; }
        public Departament? departament_ { get; set; }
        [ForeignKey("EmployeeType")] public required int? employee_type_id { get; set; }
        public EmployeeType? employee_type_ { get; set; }

    }
}
