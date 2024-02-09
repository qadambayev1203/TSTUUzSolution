using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.GenderDTOS
{
    public class GenderTranslationReadedDTO
    {
        public int id { get; set; }
        public string? gender { get; set; }
        public Gender? genders_ { get; set; }
        public Language? languages_ { get; set; }
        public StatusTranslation status_translation_ { get; set; }
    }
}
