using Entities.Model.BlogsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.PagesModel;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(500)] public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("FilesTranslation")] public int? icon_id { get; set; }
        public FilesTranslation? icon_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        public string? link_ { get; set; }
        public bool top_menu { get; set; }
        [ForeignKey("BlogTranslation")] public int? blog_translation_id { get; set; }
        public BlogTranslation? blog_translation_ { get; set; }
        [ForeignKey("PageTranslation")] public int? page_translation_id { get; set; }
        public PageTranslation? page_translation_ { get; set; }
        [ForeignKey("DepartamentTranslation")] public int? departament_translation_id { get; set; }
        public DepartamentTranslation? departament_translation_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_id { get; set; }
        public StatusTranslation? status_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; } 
    }
}
