using Entities.Model.BlogsCategoryModel;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.BlogsModel;

public class BlogTranslation
{
    public int id { get; set; }
    [MaxLength(250)] public string? title_short { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
    public DateTime? event_date { get; set; }
    public DateTime? event_end_date { get; set; }
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
    [ForeignKey("FilesTranslation")] public int? img_translation_id { get; set; }
    public FilesTranslation? img_translation_ { get; set; }
    [ForeignKey("BlogCategoryTranslation")] public int? blog_category_translation_id { get; set; }
    public BlogCategoryTranslation? blog_category_translation_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    [ForeignKey("Blog")] public int? blog_id { get; set; }
    public Blog? blog_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("User")] public int? user_id { get; set; }
    public User? user_ { get; set; }

}
