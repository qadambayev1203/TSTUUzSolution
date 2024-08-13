using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.SitesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.SiteDetailsModel;

public class SiteDetailTranslation
{
    public int id { get; set; }
    [ForeignKey("SiteDetail")] public int? site_detail_id { get; set; }
    public SiteDetail? site_detail_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    public string? description { get; set; }
    [ForeignKey("FilesTranslation")] public int? logo_w_id { get; set; }
    public FilesTranslation? logo_w_ { get; set; }
    [ForeignKey("FilesTranslation")] public int? logo_b_id { get; set; }
    public FilesTranslation? logo_b_ { get; set; }
    [ForeignKey("FilesTranslation")] public int? favicon_id { get; set; }
    public FilesTranslation? favicon_ { get; set; }
    public string? socials { get; set; }
    public string? details { get; set; }
    public DateTime? created_at { get; set; } = DateTime.UtcNow;
    public DateTime? update_at { get; set; }
    [ForeignKey("SiteTranslation")] public int? site_translation_id { get; set; }
    public SiteTranslation? site_translation_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
}
