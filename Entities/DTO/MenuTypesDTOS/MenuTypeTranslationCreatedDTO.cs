using Entities.Model.LanguagesModel;
using Entities.Model.MenuTypesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.MenuTypesDTOS
{
    public class MenuTypeTranslationCreatedDTO
    {
        public string title { get; set; }
        public int menu_type_id { get; set; }
        public int language_id { get; set; }
    }
}
