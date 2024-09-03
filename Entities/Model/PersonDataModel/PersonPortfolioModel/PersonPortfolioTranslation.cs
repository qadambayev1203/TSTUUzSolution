using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.Model.LanguagesModel;

namespace Entities.Model.PersonDataModel.PersonPortfolioModel;

public class PersonPortfolioTranslation
{
    public int id { get; set; }
    [MaxLength(500)] public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_id { get; set; }
    public StatusTranslation? status_ { get; set; }
    [ForeignKey("PersonDataTranslation")] public int? person_data_id { get; set; }
    public PersonDataTranslation? person_data_ { get; set; }
    public DateTime? crated_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("PersonPortfolio")] public int? person_portfolio_id { get; set; }
    public PersonPortfolio? person_portfolio_ { get; set; }
}
