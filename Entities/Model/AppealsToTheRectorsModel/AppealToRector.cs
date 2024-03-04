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

namespace Entities.Model.AppealsToTheRectorsModel
{
    public class AppealToRector
    {
        public int id { get; set; }
        [ForeignKey("Country")] public int? country_id { get; set; }
        public Country country_ { get; set; }
        [ForeignKey("Territorie")] public int? territorie_id { get; set; }
        public Territorie territorie_ { get; set; }
        [ForeignKey("District")] public int? district_id { get; set; }
        public District? district_ { get; set; }
        [ForeignKey("Neighborhood")] public int? neighborhood_id { get; set; }
        public Neighborhood neighborhood_ { get; set; }
        public int addres { get; set; }
        public string fio_ { get; set; }
        public DateTime birthday { get; set; }
        [ForeignKey("Gender")] public int? gender_id { get; set; }
        public Gender? gender_ { get; set; }
        [ForeignKey("Employment")] public int? employe_id { get; set; }
        public Employment? employe_ { get; set; }
        public string email { get; set; }
        [ForeignKey("Files")] public int? file_id { get; set; }
        public Files file_ { get; set; }
        public string appeal { get; set; }

    }
}
