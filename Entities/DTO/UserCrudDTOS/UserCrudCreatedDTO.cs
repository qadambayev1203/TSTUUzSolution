using Entities.Model.DepartamentsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserCrudDTOS
{
    public class UserCrudCreatedDTO
    {
        public required string login { get; set; }
        public required string password { get; set; }
        public string? email { get; set; }
        public required int user_type_id { get; set; }
        public required int person_id { get; set; }
        public bool removed { get; set; }
        public bool active { get; set; }
    }
}
