using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model;

public class UserType
{
    public int id { get; set; }
    [MaxLength(250)] public string? type { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
