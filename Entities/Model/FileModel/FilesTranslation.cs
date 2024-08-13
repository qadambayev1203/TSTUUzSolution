using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.FileModel;

public class FilesTranslation
{
    public int id { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    [MaxLength(500)] public string? url { get; set; }
    [ForeignKey("Files")] public int? files_id { get; set; }
    public Files? files_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
    [ForeignKey("User")] public int? user_id { get; set; }
    public User? user_ { get; set; }
}
