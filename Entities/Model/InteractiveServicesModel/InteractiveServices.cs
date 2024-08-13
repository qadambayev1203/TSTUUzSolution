using Entities.Model.FileModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.Model.StatusModel;

namespace Entities.Model.InteractiveServicesModel;

public class InteractiveServices
{
    public int id { get; set; }
    [MaxLength(250)] public string? title { get; set; }
    [MaxLength(250)] public string? description { get; set; }
    [MaxLength(500)] public string? url_ { get; set; }
    public bool? favorite { get; set; }
    [ForeignKey("Files")] public int? img_id { get; set; }
    public Files? img_ { get; set; }
    [ForeignKey("Files")] public int? icon_id { get; set; }
    public Files? icon_ { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
