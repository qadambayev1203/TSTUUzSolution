using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.Model.LanguagesModel;

namespace Entities.Model.StatisticalNumbersModel;

public class StatisticalNumbersTranslation
{
    public int id { get; set; }
    [MaxLength(250)] public string title { get; set; }
    [MaxLength(500)] public string description { get; set; }
    public string numbers { get; set; }
    [ForeignKey("FilesTranslation")] public int? icon_id { get; set; }
    public FilesTranslation? icon_ { get; set; }
    [ForeignKey("StatisticalNumbers")] public int? statistical_numbers_id { get; set; }
    public StatisticalNumbers? statistical_numbers_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
}
