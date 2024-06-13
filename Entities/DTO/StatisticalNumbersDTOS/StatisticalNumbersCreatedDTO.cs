using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StatisticalNumbersDTOS
{
    public class StatisticalNumbersCreatedDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public string numbers { get; set; }
        public IFormFile? icon_up { get; set; }

    }
}
