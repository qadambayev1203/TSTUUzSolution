using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.Model.FileModel;
using Entities.Model.LanguagesModel;
using Entities.Model.StatisticalNumbersModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StatisticalNumbersDTOS
{
    public class StatisticalNumbersTranslationConfReadedDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string numbers { get; set; }
    }
}
