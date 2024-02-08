using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.PersonModel
{
    public class PersonTranslation
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? fathers_name { get; set; }
        [ForeignKey("GenderTranslation")] public int? gender_id { get; set; }
        public GenderTranslation? gender_ { get; set; }
        [ForeignKey("Person")] public int? persons_id { get; set; }
        public Person? persons_ { get; set; }
        [ForeignKey("Language")] public int? languages_id { get; set; }
        public Language? languages_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }

    }
}
