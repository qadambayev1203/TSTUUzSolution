using Entities.Model.DepartamentsModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class User
    {
        public int id { get; set; }
        [MaxLength(250)] public required string login { get; set; }
        [MaxLength(500)] public required string password { get; set; }
        [MaxLength(250)] public string? email { get; set; }
        public string? token { get; set; }
        [ForeignKey("UserType")] public required int? user_type_id { get; set; }
        public UserType? user_type_ { get; set; }
        [ForeignKey("Person")] public required int? person_id { get; set; }
        public Person? person_ { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }        
        [ForeignKey("Status")] public required int? status_id { get; set; }
        public Status? status_ { get; set; }
        public bool? removed { get; set; }
        public bool? active { get; set; }

        public User()
        {

        }
    }

}
