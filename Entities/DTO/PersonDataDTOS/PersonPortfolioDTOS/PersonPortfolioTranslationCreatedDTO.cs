namespace Entities.DTO.PersonDataDTOS.PersonPortfolioDTOS;

public class PersonPortfolioTranslationCreatedDTO
{
    public int id { get; set; }
    public required string title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? language_id { get; set; }
    public int? person_portfolio_id { get; set; }
}
