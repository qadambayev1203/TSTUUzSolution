using Entities.DTO.EmployeeTypesDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PersonsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
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
    public class PersonTranslationReadedSiteDTO
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        public GenderTranslationConfReadedDTO? gender_ { get; set; }
        public PesonConfDTO? persons_ { get; set; }
        public int? persons_id { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public EmployeeTypeTranslationConfReadedDTO? employee_type_translation_ { get; set; }
        public DepartamentTranslationConfReadedDTO? departament_translation_ { get; set; }
    }
}
