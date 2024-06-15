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

namespace Entities.DTO.PersonDTOS
{
    public class PersonTranslationCreatedDataDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fathers_name { get; set; }
        public int gender_id { get; set; }
        public required int employee_type_translation_id { get; set; }
        public required int departament_translation_id { get; set; }
    }
}
