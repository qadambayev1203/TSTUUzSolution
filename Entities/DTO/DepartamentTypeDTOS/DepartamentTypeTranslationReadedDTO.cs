using Entities.Model.DepartamentsTypeModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentTypeDTOS
{
    public class DepartamentTypeTranslationReadedDTO
    {
        public int id { get; set; }
        public string? type { get; set; }
        public Language? languages_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public DepartamentType? departament_type_ { get; set; }
    }
}
