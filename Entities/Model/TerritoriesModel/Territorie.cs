using Entities.Model.LanguagesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.TerritoriesModel
{
    public class Territorie
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
