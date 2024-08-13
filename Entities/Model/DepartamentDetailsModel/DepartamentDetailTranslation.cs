using Entities.Model.DepartamentsModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.DepartamentDetailsModel;

public class DepartamentDetailTranslation
{
    public int id { get; set; }
    public string? text_json { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("DepartamentTranslation")] public required int? departament_translation_id { get; set; }
    public DepartamentTranslation? departament_translation_ { get; set; }
    [ForeignKey("DepartamentDetail")] public int? departament_detail_id { get; set; }
    public DepartamentDetail? departament_detail_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
}
