using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.MenuModel
{
    public class MenuTranslation
    {
        public int id { get; set; }
        [ForeignKey("Menu")] public int? menu_id { get; set; }
        public Menu? menu_ { get; set; }
        public int? parent_id { get; set; }
        public int? position { get; set; }
        public int? high_menu { get; set; }
        [ForeignKey("MenuTypeTranslation")] public int? menu_type_translation_id { get; set; }
        public MenuTypeTranslation? menu_type_translation_ { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("FilesTranslation")] public int? icon_id { get; set; }
        public FilesTranslation? icon_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        public int? link_id { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_id { get; set; }
        public StatusTranslation? status_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; }
    }
}
