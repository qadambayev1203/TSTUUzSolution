using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.BlogsDTOS
{
    public class BlogTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public int? blog_id { get; set; }
    }
}
