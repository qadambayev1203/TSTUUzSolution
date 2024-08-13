using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.EmploymentModel;

public class EmploymentTranslation
{
    public int id { get; set; }
    [MaxLength(250)] public string title { get; set; }
    [ForeignKey("Employment")] public int? employment_id { get; set; }
    public Employment? employment_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
}
