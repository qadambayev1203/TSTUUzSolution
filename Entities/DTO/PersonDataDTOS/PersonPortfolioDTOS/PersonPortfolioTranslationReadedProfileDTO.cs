﻿using Entities.DTO.ReadedDTOSConfigurations.LanguageConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.PersonDataDTOS.PersonPortfolioDTOS;

public class PersonPortfolioTranslationReadedProfileDTO
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? person_data_id { get; set; }
    public DateTime? crated_at { get; set; }
    public DateTime? updated_at { get; set; }
    public LanguageConfReadedDTO? language_ { get; set; }
    public int? person_portfolio_id { get; set; }
    public StatusTranslationConfReadedDTO? status_ { get; set; }
}