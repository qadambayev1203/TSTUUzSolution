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
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogConfDTOS;

namespace Entities.DTO.BlogsDTOS
{
    public class BlogTranslationReadedSelectDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int? blog_id { get; set; }
        public DateTime? event_date { get; set; }
        public DateTime? event_end_date { get; set; }
        public StatusTranslationConfReadedDTO? status_translation_ { get; set; }
       
    }
}
