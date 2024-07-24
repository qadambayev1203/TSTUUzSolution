using Entities.DTO.EmploymentsDTOS;
using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.NeighborhoodConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
using Entities.Model.StatusModel;

namespace Entities.DTO.AppealsToRectorDTOS
{
    public class AppealToRectorTranslationReadedDTO
    {
        public int id { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public CountryTranslationReadedConfDTO? country_translation_ { get; set; }
        public TerritorieTranslationConfReadedDTO? territorie_translation_ { get; set; }
        public DistrictTranslationConfReadedDTO? district_translation_ { get; set; }
        public NeighborhoodTranslationConfReadedDTO? neighborhood_translation_ { get; set; }
        public string addres { get; set; }
        public string fio_ { get; set; }
        public DateTime birthday { get; set; }
        public GenderTranslationConfReadedDTO? gender_translation_ { get; set; }
        public EmploymentTranslationConfRededDTO? employe_translation_ { get; set; }
        public string telephone_number_one { get; set; }
        public string telephone_number_two { get; set; }
        public string email { get; set; }
        public FileTranslationConfReadedDTO file_translation_ { get; set; }
        public string appeal { get; set; }
        public bool? confirm { get; set; }

        public DateTime created_at { get; set; }
    }
}
