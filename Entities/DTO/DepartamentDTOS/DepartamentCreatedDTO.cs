using Entities.Model.DepartamentsTypeModel;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.DTO.DepartamentDTOS
{
    public class DepartamentCreatedDTO
    {
        public string title_short { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string text { get; set; }
        public int parent_id { get; set; }
        public IFormFile? img_up { get; set; }
        public IFormFile? img_icon_up { get; set; }
        public int? position { get; set; }
        public bool favorite { get; set; }
        public int departament_type_id { get; set; }

    }
}
