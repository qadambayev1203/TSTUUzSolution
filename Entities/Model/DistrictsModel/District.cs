using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.DistrictsModel
{
    public class District
    {
        public int id { get; set; }
        [ForeignKey("Territorie")] public int? territorie_id { get; set; }
        public Territorie territorie_ { get; set; }
        public string title { get; set; }
    }
}
