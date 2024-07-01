using Entities.Model;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.FilesDTOS
{
    public class FilesTranslationUpdatedDTO
    {
        public string title { get; set; }
        public IFormFile? url { get; set; }
        public int? files_id { get; set; }
        public int language_id { get; set; }
        public int status_translation_id { get; set; }
    }
}
