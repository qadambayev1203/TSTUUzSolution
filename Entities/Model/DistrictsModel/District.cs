using Entities.Model.StatusModel;
using Entities.Model.TerritoriesModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.DistrictsModel;

public class District
{
    public int id { get; set; }
    [ForeignKey("Territorie")] public int? territorie_id { get; set; }
    public Territorie territorie_ { get; set; }
    [MaxLength(250)] public string title { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
