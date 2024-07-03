using Entities.Model.EmployeeTypesModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmployeeTypesDTOS
{
    public class EmployeeTypeTranslationCreatedDTO
    {
        public string title { get; set; }
        public int employee_id { get; set; }
        public int language_id { get; set; }

    }
}
