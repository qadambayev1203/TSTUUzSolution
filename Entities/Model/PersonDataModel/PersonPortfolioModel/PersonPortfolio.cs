using Entities.Model.StatusModel;   
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model.PersonDataModel.PersonPortfolioModel;

public class PersonPortfolio
{
    public int id { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
    [ForeignKey("PersonData")] public int? person_data_id { get; set; }
    public PersonData? person_data_ { get; set; }
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
}
