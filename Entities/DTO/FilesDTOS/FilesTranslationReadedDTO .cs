using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.FilesDTOS
{
    public class FilesTranslationReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public Files? files_ { get; set; }
        public Language? languages_ { get; set; }
        public StatusTranslation? status_translation_ { get; set; }
    }
}
