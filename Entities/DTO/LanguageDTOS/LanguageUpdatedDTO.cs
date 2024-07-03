using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.LanguageDTOS
{
    public class LanguageUpdatedDTO
    {
        public string title { get; set; }
        public string title_short { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public string details { get; set; }
        public IFormFile? img_upload { get; set; }
        public int status_id { get; set; }
    }
}
