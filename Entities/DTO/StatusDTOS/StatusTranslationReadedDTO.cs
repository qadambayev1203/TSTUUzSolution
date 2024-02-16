using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StatusDTOS
{
    public class StatusTranslationReadedDTO
    {
        public int id { get; set; }
        public string? status { get; set; }
        public Status? status_ { get; set; }
        public Language? languages_ { get; set; }
        public bool? is_deleted { get; set; }
    }
}
