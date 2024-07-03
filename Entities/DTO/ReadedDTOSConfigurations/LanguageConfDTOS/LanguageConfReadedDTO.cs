using Entities.Model.FileModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS
{
    public class LanguageConfReadedDTO
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? title_short { get; set; }
        public string? code { get; set; }
       
    }
}
