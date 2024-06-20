using Entities.Model.FileModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;

namespace Entities.Model.InteractiveServicesModel
{
    public class InteractiveServicesTranslation
    {
        public int id { get; set; }
        [MaxLength(250)] public string? title { get; set; }
        [MaxLength(250)] public string? description { get; set; }
        [MaxLength(500)] public string? url_ { get; set; }
        [ForeignKey("InteractiveServices")] public int? interactive_services_id { get; set; }
        public InteractiveServices? interactive_services_ { get; set; }
        [ForeignKey("FilesTranslation")] public int? img_id { get; set; }
        public FilesTranslation? img_ { get; set; }
        [ForeignKey("FilesTranslation")] public int? icon_id { get; set; }
        public FilesTranslation? icon_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public bool? favorite { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
