﻿using Microsoft.AspNetCore.Http;

namespace Entities.DTO.InteractiveServicesDTOS;

public class InteractiveServicesCreatedDTO
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? url_ { get; set; }
    public bool? favorite { get; set; }
    public IFormFile? img_up { get; set; }
    public IFormFile? icon_up { get; set; }

}
