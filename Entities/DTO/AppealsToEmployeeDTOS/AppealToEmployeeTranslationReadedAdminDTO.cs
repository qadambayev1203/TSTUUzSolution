using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.DTO.UserCrudDTOS;

namespace Entities.DTO.AppealsToEmployeeDTOS
{
    public class AppealToEmployeeTranslationReadedAdminDTO
    {
        public int id { get; set; }
        public string? full_name { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public DateTime? created_at { get; set; }
        public StatusTranslationConfReadedDTO? status_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public UserFIODTO? user_ { get; set; }
    }
}
