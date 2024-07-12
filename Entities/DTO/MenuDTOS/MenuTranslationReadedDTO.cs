using Entities.DTO.BlogsDTOS;
using Entities.DTO.PageDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuTypesConfDTO;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.MenuModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.PagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.MenuDTOS
{
    public class MenuTranslationReadedDTO
    {
        public int id { get; set; }
        public MenuConfReadedDTO? menu_ { get; set; }
        public int? parent_id { get; set; }
        public int? position { get; set; }
        public int? high_menu { get; set; }
        public MenuTypeTranslationConfReadedDTO? menu_type_translation_ { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public FileTranslationConfReadedDTO? icon_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        public string? link_ { get; set; }
        public StatusTranslationConfReadedDTO? status_ { get; set; }
        public LanguageConfReadedDTO? language_ { get; set; }
        public UserConfReadedDTO? user_ { get; set; }
        public bool top_menu { get; set; }
        public BlogTranslationConfReadedDTO? blog_translation_ { get; set; }
        public PageTranslationConfReadedDTO? page_translation_ { get; set; }
        public DepartamentTranslationConfReadedDTO? departament_translation_ { get; set; } 
    }
}
