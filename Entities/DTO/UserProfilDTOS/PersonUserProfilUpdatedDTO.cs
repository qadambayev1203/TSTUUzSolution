using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserProfilDTOS
{
    public class PersonUserProfilUpdatedDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fathers_name { get; set; }
        public string? email { get; set; }
    }
}
