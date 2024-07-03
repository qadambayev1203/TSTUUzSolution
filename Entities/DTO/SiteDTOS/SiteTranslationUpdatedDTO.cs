using Entities.Model.SiteTypesModel;
using Entities.Model.StatusModel;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.LanguagesModel;
using Entities.Model.SitesModel;

namespace Entities.DTO.SiteDTOS
{
    public class SiteTranslationUpdatedDTO
    {
        public int site_id { get; set; }
        public int language_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int status_translation_id { get; set; }
        public int site_type_translation_id { get; set; }
        

    }
}
