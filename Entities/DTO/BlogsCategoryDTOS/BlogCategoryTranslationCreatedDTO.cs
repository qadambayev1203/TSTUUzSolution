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
    public class BlogCategoryTranslationCreatedDTO
    {
        public string title { get; set; }
        public int language_id { get; set; }
        public int blog_category_id { get; set; }
    }

}
