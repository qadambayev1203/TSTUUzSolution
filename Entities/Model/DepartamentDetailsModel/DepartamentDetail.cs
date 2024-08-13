using Entities.Model.DepartamentsModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.DepartamentDetailsModel;

public class DepartamentDetail
{
    public int id { get; set; }
    public string? text_json { get; set; }
    [ForeignKey("Departament")] public required int? departament_id { get; set; }
    public Departament? departament_ { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
