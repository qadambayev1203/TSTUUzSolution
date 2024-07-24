using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppealsToRectorDTOS
{
    public class AppealTranslationEmailCheckStatusDTO
    {
        public int id { get; set; }
        public string appeal { get; set; }
        public bool? confirm { get; set; }


    }
}
