using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.FileModel;

public class Files
{
    public int id { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    [MaxLength(500)] public string? url { get; set; }
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
    [ForeignKey("User")] public int? user_id { get; set; }
    public User? user_ { get; set; }

}
