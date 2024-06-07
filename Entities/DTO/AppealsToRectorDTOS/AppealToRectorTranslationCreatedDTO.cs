using Entities.Model.AnyClasses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppealsToRectorDTOS
{
    public class AppealToRectorTranslationCreatedDTO
    {
        public int language_id { get; set; }
        public int country_translation_id { get; set; }
        public int territorie_translation_id { get; set; }
        public int district_translation_id { get; set; }
        public int neighborhood_translation_id { get; set; }
        public string addres { get; set; }
        public string fio_ { get; set; }
        public DateTime birthday { get; set; }
        public int gender_translation_id { get; set; }
        public int employe_translation_id { get; set; }
        public string telephone_number_one { get; set; }
        public string? telephone_number_two { get; set; }
        public string email { get; set; }
        public IFormFile? file_upload_ { get; set; }
        public string appeal { get; set; }
        public int captcha_numbers_sum { get; set; }


    }
}
