using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserTypeDTOS
{
    public class UserTypeTranslationCreatedDTO
    {
        public string type { get; set; }
        public int user_types_id { get; set; }
        public int language_id { get; set; }
    }
}
