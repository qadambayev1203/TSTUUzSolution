using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.StatisticalNumbersModel;

public class StatisticalNumbers
{
    public int id { get; set; }
    [MaxLength(250)] public string title { get; set; }
    [MaxLength(500)] public string description { get; set; }
    public string numbers { get; set; }
    [ForeignKey("Files")] public int? icon_id { get; set; }
    public Files? icon_ { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }

}
