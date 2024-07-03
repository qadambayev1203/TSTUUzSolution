using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.DTO.InteractiveServicesDTOS
{
    public class InteractiveServicesUpdatedDTO
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? url_ { get; set; }
        public bool? favorite { get; set; }
        public IFormFile? img_up { get; set; }
        public IFormFile? icon_up { get; set; }
        public int? status_id { get; set; }
    }
}
