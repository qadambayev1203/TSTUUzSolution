using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.MenuTypesModel
{
    public class MenuTypeTranslation
    {
        public int id { get; set; }
        [MaxLength(250)] public string? title { get; set; }
        [ForeignKey("MenuType")] public int? menu_type_id { get; set; }
        public MenuType? menu_type_ { get; set; }
        [ForeignKey("StatusTranslation")] public int? status_translation_id { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
        [ForeignKey("Language")] public int? language_id { get; set; }
        public Language? language_ { get; set; }
    }
}
