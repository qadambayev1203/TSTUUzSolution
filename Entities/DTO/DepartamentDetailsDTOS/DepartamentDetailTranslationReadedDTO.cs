using Entities.Model.DepartamentDetailsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.DepartamentDetailsDTOS
{
    public class DepartamentDetailTranslationReadedDTO
    {
        public int id { get; set; }
        public string? text_json { get; set; }
        public Language? languages_ { get; set; }
        public DepartamentTranslation? departament_translation_ { get; set; }
        public DepartamentDetail? departament_detail_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }

    }
}
