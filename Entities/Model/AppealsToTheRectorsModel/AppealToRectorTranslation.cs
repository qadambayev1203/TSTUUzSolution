using Entities.Model.CountrysModel;
using Entities.Model.DistrictsModel;
using Entities.Model.EmploymentModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.NeighborhoodsModel;
using Entities.Model.TerritoriesModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.AppealsToTheRectorsModel;

public class AppealToRectorTranslation
{
    public int id { get; set; }
    [ForeignKey("Language")] public int? language_id { get; set; }
    public Language? language_ { get; set; }
    [ForeignKey("CountryTranslation")] public int? country_translation_id { get; set; }
    public CountryTranslation? country_translation_ { get; set; }
    [ForeignKey("TerritorieTranslation")] public int? territorie_translation_id { get; set; }
    public TerritorieTranslation? territorie_translation_ { get; set; }
    [ForeignKey("DistrictTranslation")] public int? district_translation_id { get; set; }
    public DistrictTranslation? district_translation_ { get; set; }
    [ForeignKey("NeighborhoodTranslation")] public int? neighborhood_translation_id { get; set; }
    public NeighborhoodTranslation? neighborhood_translation_ { get; set; }
    [MaxLength(500)] public string? addres { get; set; }
    [MaxLength(300)] public string? fio_ { get; set; }
    public DateTime? birthday { get; set; }
    [ForeignKey("GenderTranslation")] public int? gender_translation_id { get; set; }
    public GenderTranslation? gender_translation_ { get; set; }
    [ForeignKey("EmploymentTranslation")] public int? employe_translation_id { get; set; }
    public EmploymentTranslation? employe_translation_ { get; set; }
    [MaxLength(50)] public string? telephone_number_one { get; set; }
    [MaxLength(50)] public string? telephone_number_two { get; set; }
    [MaxLength(150)] public string? email { get; set; }
    [ForeignKey("FilesTranslation")] public int? file_translation_id { get; set; }
    public FilesTranslation? file_translation_ { get; set; }
    public string? appeal { get; set; }
    public bool? confirm { get; set; }
    public DateTime? created_at { get; set; }
}
