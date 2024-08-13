using Entities.Model.LanguagesModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.StatusModel;

public  class StatusTranslation
{
    public int id { get; set; }
    [MaxLength(250)] public string? status { get; set; }
    [MaxLength(250)] public string? name { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    public bool? is_deleted { get; set; }

}
