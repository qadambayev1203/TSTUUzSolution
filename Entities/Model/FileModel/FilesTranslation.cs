using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.FileModel
{
    public class FilesTranslation
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        [ForeignKey("Files")]        public int? files_id { get; set; }
        public Files? files_ { get; set; }
        [ForeignKey("Language")]        public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("StatusTranslation")]        public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
