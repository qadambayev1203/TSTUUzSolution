using Entities.Model.BlogsCategoryModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.BlogsCategoryDTOS
{
    public class BlogCategoryTranslationReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        public Language? language_ { get; set; }
        public BlogCategory? blog_category_ { get; set; }
    }

}
