using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.GenderModel;

public class Gender
{
    public int id { get; set; }
    [MaxLength(250)] public string? gender { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
