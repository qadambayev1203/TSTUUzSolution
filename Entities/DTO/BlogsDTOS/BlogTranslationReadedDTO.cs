using Entities.Model.BlogsCategoryModel;
using Entities.Model.BlogsModel;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.BlogsDTOS
{
    public class BlogTranslationReadedDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public DateTime? crated_at { get; set; } 
        public DateTime? updated_at { get; set; }
        public FilesTranslation? img_translation_ { get; set; }
        public BlogCategoryTranslation? blog_category_translation_ { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
        public Blog? blog_ { get; set; }
        public Language? language_ { get; set; }
        public User? user_ { get; set; }
    }
}
