using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.GenderDTOS
{
    public class PersonTranslationReadedDTO
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        public GenderTranslation? gender_ { get; set; }
        public Person? persons_ { get; set; }
        public Language? languages_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
