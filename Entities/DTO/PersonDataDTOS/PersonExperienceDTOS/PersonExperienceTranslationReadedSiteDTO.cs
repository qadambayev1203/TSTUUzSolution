﻿using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;

namespace Entities.DTO.PersonDataDTOS.PersonExperienceDTOS;

public class PersonExperienceTranslationReadedSiteDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? person_data_id { get; set; }
    public DateTime? crated_at { get; set; }
    public DateTime? updated_at { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? person_experience_id { get; set; }
}