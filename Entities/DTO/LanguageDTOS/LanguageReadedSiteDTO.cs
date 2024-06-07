using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.LanguageDTOS
{
    public class LanguageReadedSiteDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? title_short { get; set; }
        public string? description { get; set; }
        public string? code { get; set; }
        public string? details { get; set; }
        public FileConfReadedDTO? img_ { get; set; }
    }
}
