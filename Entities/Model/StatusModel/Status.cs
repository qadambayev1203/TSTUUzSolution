using System.ComponentModel.DataAnnotations;

namespace Entities.Model.StatusModel;

public class Status
{
    public int id { get; set; }
    [MaxLength(250)] public string? status { get; set; }
    [MaxLength(250)] public string? name { get; set; }
    public bool? is_deleted { get; set; }
}
