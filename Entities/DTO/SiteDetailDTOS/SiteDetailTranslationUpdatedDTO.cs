﻿using Microsoft.AspNetCore.Http;

namespace Entities.DTO.SiteDetailDTOS;

public class SiteDetailTranslationUpdatedDTO
{
    public int site_detail_id { get; set; }
    public int language_id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public IFormFile? logo_w_up { get; set; }
    public IFormFile? logo_b_up { get; set; }
    public IFormFile? favicon_up { get; set; }
    public string socials { get; set; }
    public string details { get; set; }
    public int site_translation_id { get; set; }
    public int status_translation_id { get; set; }
}
