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
    public class EmployeeTypeTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public EmployeeTypeReadedSiteDTO? employee_ { get; set; }

    }
}
