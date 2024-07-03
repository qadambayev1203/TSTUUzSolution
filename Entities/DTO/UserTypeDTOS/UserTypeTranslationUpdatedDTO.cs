using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserTypeDTOS
{
    public class UserTypeTranslationUpdatedDTO
    {
        public string type { get; set; }
        public int user_types_id { get; set; }
        public int language_id { get; set; }
        public int status_translation_id { get; set; }
    }
}
