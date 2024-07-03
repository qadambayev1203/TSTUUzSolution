using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
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
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public BlogCategoryReadedConfDTO? blog_category_ { get; set; }
    }

}
