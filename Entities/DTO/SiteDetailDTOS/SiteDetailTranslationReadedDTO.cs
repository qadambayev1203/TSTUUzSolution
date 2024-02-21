using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.SiteDetailsModel;
using Entities.Model.SitesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.SiteDetailDTOS
{
    public class SiteDetailTranslationReadedDTO
    {
        public int id { get; set; }
        public SiteDetail? site_detail_ { get; set; }
        public Language? language_ { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public FilesTranslation? logo_w_ { get; set; }
        public FilesTranslation? logo_b_ { get; set; }
        public FilesTranslation? favicon_ { get; set; }
        public string? socials { get; set; }
        public string? details { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? update_at { get; set; }
        public SiteTranslation? site_translation_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
