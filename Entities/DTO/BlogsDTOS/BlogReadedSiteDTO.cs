using Entities.Model.BlogsCategoryModel;
using Entities.Model.FileModel;
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
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.BlogCategoryConfDTOS;

namespace Entities.DTO.BlogsDTOS
{
    public class BlogReadedSiteDTO
    {
        public int id { get; set; }
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public DateTime? event_date { get; set; }
        public DateTime? event_end_date { get; set; }
        public FileConfReadedDTO? img_ { get; set; }
        public BlogCategoryReadedConfDTO? blog_category_ { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
    }
}
