
using Entities.DTO.PersonDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.PersonDataDTOS;

public class PersonDataTranslationReadedEmployeeTypeDTO
{
    public int id { get; set; }
    public PesonTranslationSiteConfDTO? persons_translation_ { get; set; }
    public PesonDataConfDTO? persons_data_ { get; set; }
    public string? biography_json { get; set; }
    public DateTime? birthday { get; set; }
    public string? degree { get; set; }
    public int? experience_year { get; set; }
    public string? phone_number1 { get; set; }
    public string? phone_number2 { get; set; }
    public string? orchid { get; set; }
    public string? scopus_id { get; set; }
    public string? address { get; set; }
    public int? languages_uz { get; set; }
    public int? languages_en { get; set; }
    public int? languages_ru { get; set; }
    public string? languages_any_title { get; set; }
    public int? languages_any { get; set; }
    public string? experience_json { get; set; }
    public string? scientific_activity_json { get; set; }
    public string? portfolio_json { get; set; }
    public string? blog_json { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
}
