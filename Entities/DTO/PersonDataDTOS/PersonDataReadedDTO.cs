﻿using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.PersonsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PersonDataDTOS
{
    public class PersonDataReadedDTO
    {
        public int id { get; set; }
        public PersonConfReadedDTO? persons_ { get; set; }
        public string? biography_json { get; set; }
        public DateTime? birthday { get; set; }
        public string? degree { get; set; }
        public int? experience_year { get; set; }
        public string? phone_number1 { get; set; }
        public string? phone_number2 { get; set; }
        public string? orchid { get; set; }
        public string? scopus_id { get; set; }
        public string? address { get; set; }
        public int? languages_uz { get; set; }
        public int? languages_en { get; set; }
        public int? languages_ru { get; set; }
        public string? languages_any_title { get; set; }
        public int? languages_any { get; set; }
        public string? experience_json { get; set; }
        public string? scientific_activity_json { get; set; }
        public string? portfolio_json { get; set; }
        public string? blog_json { get; set; }
        public StatusConfReadedDTO? status_ { get; set; }

        // USER

        public string? login { get; set; }
    }
}
