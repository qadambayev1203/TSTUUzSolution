using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.DepartamentsTypeModel
{
    public class DepartamentType
    {
        public int id { get; set; }
        [MaxLength(300)] public string? type { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
    }
}
