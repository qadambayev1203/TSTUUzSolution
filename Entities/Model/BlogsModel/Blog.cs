using Entities.Model.BlogsCategoryModel;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.BlogsModel;

public class Blog
{
    public int id { get; set; }
    [MaxLength(250)] public string? title_short { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
    public DateTime? event_date { get; set; } 
    public DateTime? event_end_date { get; set; } 
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
    [ForeignKey("Files")] public int? img_id { get; set; }
    public Files? img_ { get; set; }
    [ForeignKey("BlogCategory")] public int? blog_category_id { get; set; }
    public BlogCategory? blog_category_ { get; set; }
    public int? position { get; set; }
    public bool? favorite { get; set; }
    [ForeignKey("User")] public int? user_id { get; set; }
    public User? user_ { get; set; }
}
