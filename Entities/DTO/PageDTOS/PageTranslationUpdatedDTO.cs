﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.PageDTOS
{
    public class PageTranslationUpdatedDTO
    {
        public string? title_short { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? text { get; set; }
        public int? page_id { get; set; }
        public int? status_translation_id { get; set; }
        public int? img_translation_id { get; set; }
        public int? position { get; set; }
        public bool? favorite { get; set; }
    }
}
