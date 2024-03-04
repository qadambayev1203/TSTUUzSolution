using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.EmploymentModel
{
    public class EmploymentTranslation
    {
        public int id { get; set; }
        public string title { get; set; }
        [ForeignKey("Employment")] public int? employment_id { get; set; }
        public Employment? employment_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
    }
}
