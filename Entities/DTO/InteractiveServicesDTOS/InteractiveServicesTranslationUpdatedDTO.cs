using Entities.Model.FileModel;
using Entities.Model.InteractiveServicesModel;
using Entities.Model.LanguagesModel;
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
    public class InteractiveServicesTranslationUpdatedDTO
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? url_ { get; set; }
        public bool? favorite { get; set; }
        public int? interactive_services_id { get; set; }
        public IFormFile? img_up { get; set; }
        public IFormFile? icon_up { get; set; }
        public int? language_id { get; set; }
        public int? status_translation_id { get; set; }
    }
}
