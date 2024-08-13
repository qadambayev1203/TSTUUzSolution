using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model.EmployeeTypesModel;

public class EmployeeType
{
    public int id { get; set; }
    [MaxLength(250)] public string title { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
