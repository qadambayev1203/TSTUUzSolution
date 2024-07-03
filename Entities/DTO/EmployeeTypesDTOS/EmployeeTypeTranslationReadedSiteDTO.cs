using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
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
    public class EmployeeTypeTranslationReadedSiteDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public EmployeeTypeReadedSiteDTO? employee_ { get; set; }
        public LanguageConfReadedDTO language_ { get; set; }

    }
}
