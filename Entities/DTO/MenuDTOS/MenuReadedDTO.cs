using Entities.DTO.ReadedDTOSConfigurations.BlogConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DepartamentConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.MenuTypesConfDTO;
using Entities.DTO.ReadedDTOSConfigurations.PageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.UsersConfDTOS;
using Entities.Model;
using Entities.Model.BlogsModel;
using Entities.Model.DepartamentsModel;
using Entities.Model.FileModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.StatusModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.MenuDTOS
{
    public class MenuReadedDTO
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public int? position { get; set; }
        public int? high_menu { get; set; }
        public MenuTypeConfReadedDTO? menu_type_ { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public FileConfReadedDTO? icon_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        public string? link_ { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }
        public UserConfReadedDTO? user_ { get; set; }
        public bool top_menu { get; set; }
        public BlogConfRededDTO? blog_ { get; set; }
        public PageConfReadDTO? page_ { get; set; }
        public DepartamentConfReadedDTO? departament_ { get; set; }

    }
}
