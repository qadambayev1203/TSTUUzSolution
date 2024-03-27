using Entities.Model.FileModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.MenuModel
{
    public class Menu
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public int? position { get; set; }
        public int? high_menu { get; set; }
        [ForeignKey("MenuType")]public int? menu_type_id { get; set; }
        public MenuType? menu_type_ { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        [ForeignKey("Files")] public int? icon_id { get; set; }
        public Files? icon_ { get; set; }
        public DateTime? created_at { get; set; } = DateTime.UtcNow;
        public DateTime? updated_at { get; set; }
        public string? link_ { get; set; }
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status? status_ { get; set; }
        [ForeignKey("User")] public int? user_id { get; set; }
        public User? user_ { get; set; }

    }
}
