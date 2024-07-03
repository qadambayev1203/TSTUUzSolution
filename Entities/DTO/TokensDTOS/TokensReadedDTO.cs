using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.TokensDTOS
{
    public class TokensReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string token { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
    }
}
