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
    public class StatusTranslationCreatedDTO
    {
        public string? name { get; set; }
        public string status { get; set; }
        public int language_id { get; set; }
    }
}
