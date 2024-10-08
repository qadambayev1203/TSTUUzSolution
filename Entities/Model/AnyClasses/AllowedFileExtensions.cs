﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model.AnyClasses;

public class AllowedFileExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedFileExtensionsAttribute(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_extensions.Contains(fileExtension))
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        return ValidationResult.Success;
    }

    private string GetErrorMessage()
    {
        return $"Only {_extensions} file types are allowed.";
    }
}
