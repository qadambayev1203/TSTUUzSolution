using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.BlogsCategoryModel;

public class BlogCategoryTranslation
{
    public int id { get; set; }
    [MaxLength(250)] public string? title { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("BlogCategory")] public int? blog_category_id { get; set; }
    public BlogCategory? blog_category_ { get; set; }
}
