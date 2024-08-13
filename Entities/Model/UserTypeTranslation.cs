using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model;

public class UserTypeTranslation
{
    public int id { get; set; }
    [MaxLength(250)] public string? type { get; set; }
    [ForeignKey("UserType")] public int user_types_id { get; set; }
    public UserType? user_types_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }

}
