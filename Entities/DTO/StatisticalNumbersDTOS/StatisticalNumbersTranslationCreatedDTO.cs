using Entities.Model.EmploymentModel;
using Entities.Model.LanguagesModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StatisticalNumbersDTOS
{
    public class StatisticalNumbersTranslationCreatedDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public string numbers { get; set; }
        public IFormFile? icon_up { get; set; }
        public int? statistical_numbers_id { get; set; }
        public int? language_id { get; set; }

    }
}
