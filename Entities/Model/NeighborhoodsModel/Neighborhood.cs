using Entities.Model.DistrictsModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.NeighborhoodsModel;

public class Neighborhood
{
    public int id { get; set; }
    [ForeignKey("District")] public int? district_id { get; set; }
    public District? district_ { get; set; }
    [MaxLength(250)] public string? title { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
