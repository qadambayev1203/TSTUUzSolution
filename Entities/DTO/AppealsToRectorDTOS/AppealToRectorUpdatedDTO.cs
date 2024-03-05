using Entities.Model.CountrysModel;
using Entities.Model.DistrictsModel;
using Entities.Model.EmploymentModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
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
    public class AppealToRectorUpdatedDTO
    {
        public int? country_id { get; set; }
        public int? territorie_id { get; set; }
        public int? district_id { get; set; }
        public int? neighborhood_id { get; set; }
        public int addres { get; set; }
        public string fio_ { get; set; }
        public DateTime birthday { get; set; }
        public int? gender_id { get; set; }
        public int? employe_id { get; set; }
        public string email { get; set; }
        public int? file_id { get; set; }
        public string appeal { get; set; }
        public int? status_id { get; set; }
    }
}
