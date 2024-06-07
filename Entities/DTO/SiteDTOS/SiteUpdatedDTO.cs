using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteDTOS
{
    public class SiteUpdatedDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public int status_id { get; set; }
        public int site_type_id { get; set; }
        
    }
}
