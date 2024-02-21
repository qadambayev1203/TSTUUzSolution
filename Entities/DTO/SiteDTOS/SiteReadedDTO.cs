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
    public class SiteReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public Status? status_ { get; set; }
        public SiteType? site_type_ { get; set; }
        public User? user_ { get; set; }
        public DateTime? created_at { get; set; } 
        public DateTime? updated_at { get; set; }
    }
}
