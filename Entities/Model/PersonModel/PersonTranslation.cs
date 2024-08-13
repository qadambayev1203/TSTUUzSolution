using Entities.Model.DepartamentsModel;
using Entities.Model.EmployeeTypesModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.PersonModel;

public class PersonTranslation
{
    public int id { get; set; }
    [MaxLength(150)] public string? firstName { get; set; }
    [MaxLength(150)] public string? lastName { get; set; }
    [MaxLength(150)] public string? fathers_name { get; set; }
    [ForeignKey("GenderTranslation")] public int? gender_id { get; set; }
    public GenderTranslation? gender_ { get; set; }
    [ForeignKey("Person")] public int? persons_id { get; set; }
    public Person? persons_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
    [ForeignKey("DepartamentTranslation")] public required int? departament_translation_id { get; set; }
    public DepartamentTranslation? departament_translation_ { get; set; }
    [ForeignKey("EmployeeTypeTranslation")] public required int? employee_type_translation_id { get; set; }
    public EmployeeTypeTranslation? employee_type_translation_ { get; set; }

}
