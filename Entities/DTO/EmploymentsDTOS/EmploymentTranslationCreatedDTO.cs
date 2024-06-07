using Entities.Model.EmploymentModel;
using Entities.Model.LanguagesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmploymentsDTOS
{
    public class EmploymentTranslationCreatedDTO
    {
        public string title { get; set; }
        public int employment_id { get; set; }
        public int language_id { get; set; }

    }
}
