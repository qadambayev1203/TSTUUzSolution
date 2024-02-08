using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.GenderModel
{
    public class GenderTranslation
    {
        public int id { get; set; }
        public string? gender { get; set; }
        [ForeignKey("Gender")] public int? gender_id { get; set; }
        public Gender? genders_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? languages_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation status_translation_ { get; set; }

    }
}
