using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteTypeDTOS
{
    public class SiteTypeUpdatedDTO
    {
        public string type { get; set; }
        public int status_id { get; set; }
    }
}
