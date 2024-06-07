using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.GenderDTOS
{
    public class GenderTranslationCreatedDTO
    {
        public string gender { get; set; }
        public int gender_id { get; set; }
        public int language_id { get; set; }
    }
}
