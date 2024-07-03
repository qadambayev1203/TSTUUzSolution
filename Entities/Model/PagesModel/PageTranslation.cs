using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.PagesModel
{
    public class PageTranslation
    {
        public int id { get; set; }
        [MaxLength(250)] public string? title_short { get; set; }
        [MaxLength(500)] public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public DateTime? crated_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        [ForeignKey("FilesTranslation")] public int? img_translation_id { get; set; }
        public FilesTranslation? img_translation_ { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
        [ForeignKey("Page")] public int? page_id { get; set; }
        public Pages? page_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; }
    }
}
