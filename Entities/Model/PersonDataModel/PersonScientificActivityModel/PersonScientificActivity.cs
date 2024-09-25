using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.PersonDataModel.PersonScientificActivityModel;

public class PersonScientificActivity
{
    public int id { get; set; }
    public int? since_when { get; set; }
    public int? until_when { get; set; }
    public string? whom { get; set; }
    public string? where { get; set; }
    [ForeignKey("PersonData")] public int? person_data_id { get; set; }
    public PersonData? person_data_ { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
    public int? confirmed { get; set; }
}
