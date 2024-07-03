using Entities.Model.FileModel;
using Entities.Model.SitesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.SiteDeatilConfDTOS
{
    public class SiteDetailConfreadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
    }
}
