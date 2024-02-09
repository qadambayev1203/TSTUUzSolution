using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.GenderDTOS
{
    public class UserTypeTranslationReadedDTO
    {
        public int id { get; set; }
        public string? type { get; set; }
        public UserType? user_types_ { get; set; }
        public Language? languages_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
