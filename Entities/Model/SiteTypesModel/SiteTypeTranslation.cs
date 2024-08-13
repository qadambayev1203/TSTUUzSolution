using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.SiteTypesModel;

public class SiteTypeTranslation
{
    public int id { get; set; }
    [ForeignKey("SiteType")] public int? site_type_id { get; set; }
    public SiteType? site_type_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
    [MaxLength(250)] public string? type { get; set; }
}
