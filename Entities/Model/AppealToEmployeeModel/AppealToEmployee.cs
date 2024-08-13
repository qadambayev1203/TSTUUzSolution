using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.AppealToEmployeeModel;

public class AppealToEmployee
{
    public int id { get; set; }
    [MaxLength(150)] public string? full_name { get; set; }
    [MaxLength(150)] public string? email { get; set; }
    [MaxLength(250)] public string? subject { get; set; }
    public string? message { get; set; }
    public DateTime? created_at { get; set; }
    [ForeignKey("User")] public int? user_id { get; set; }
    public User? user_ { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
