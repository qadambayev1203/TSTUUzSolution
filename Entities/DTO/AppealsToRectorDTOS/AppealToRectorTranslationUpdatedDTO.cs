using Entities.Model.AppealsToTheRectorsModel;
using Entities.Model.CountrysModel;
using Entities.Model.DistrictsModel;
using Entities.Model.EmploymentModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.LanguagesModel;
using Entities.Model.NeighborhoodsModel;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppealsToRectorDTOS
{
    public class AppealToRectorTranslationUpdatedDTO
    {
        public int? language_id { get; set; }
        public int? appeal_to_rector_id { get; set; }
        public int? country_translation_id { get; set; }
        public int? territorie_translation_id { get; set; }
        public int? district_translation_id { get; set; }
        public int? neighborhood_translation_id { get; set; }
        public int addres { get; set; }
        public string fio_ { get; set; }
        public DateTime birthday { get; set; }
        public int? gender_translation_id { get; set; }
        public int? employe_translation_id { get; set; }
        public string email { get; set; }
        public int? file_translation_id { get; set; }
        public string appeal { get; set; }
        public int? status_translation_id { get; set; }
    }
}
