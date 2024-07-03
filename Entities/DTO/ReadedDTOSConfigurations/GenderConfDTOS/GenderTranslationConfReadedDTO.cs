using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS
{
    public class GenderTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string? gender { get; set; }
        public GenderConfReadedDTO? gender_ { get; set; }
        public int? gender_id { get; set; }
    }
}
