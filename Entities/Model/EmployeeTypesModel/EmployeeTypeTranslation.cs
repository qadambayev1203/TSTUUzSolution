using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model.EmployeeTypesModel;

public class EmployeeTypeTranslation
{
    public int id { get; set; }
    [MaxLength(250)] public string title { get; set; }
    [ForeignKey("EmployeeType")] public int? employee_id { get; set; }
    public EmployeeType? employee_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
}
