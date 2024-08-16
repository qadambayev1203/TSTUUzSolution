using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.PersonDataModel.PersonScientificActivityModel;

public class PersonScientificActivityTranslation
{
    public int id { get; set; }
    public int? since_when { get; set; }
    public int? until_when { get; set; }
    public string? whom { get; set; }
    public string? where { get; set; }
    [ForeignKey("PersonScientificActivity")] public int? person_scientific_activity_id { get; set; }
    public PersonScientificActivity? person_scientific_activity_ { get; set; }
    [ForeignKey("PersonDataTranslation")] public int? person_data_translation_id { get; set; }
    public PersonDataTranslation? person_data_translation_ { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
    public StatusTranslation? status_translation_ { get; set; }
}
