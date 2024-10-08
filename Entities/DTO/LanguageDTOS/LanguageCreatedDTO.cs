﻿using Microsoft.AspNetCore.Http;

namespace Entities.DTO.LanguageDTOS;

public class LanguageCreatedDTO
{
    public string title { get; set; }
    public string title_short { get; set; }
    public string description { get; set; }
    public string code { get; set; }
    public string details { get; set; }
    public IFormFile? img_upload { get; set; }
}
