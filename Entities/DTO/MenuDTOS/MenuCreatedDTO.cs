using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.MenuDTOS
{
    public class MenuCreatedDTO
    {
        public int parent_id { get; set; }
        public int? position { get; set; }
        public int? high_menu { get; set; }
        public int? menu_type_id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int? icon_id { get; set; }
        public int? link_id { get; set; }
    }
}
