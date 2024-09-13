namespace Entities.DTO.PersonDataDTOS.PersonPortfolioDTOS;

public class PersonPortfolioUpdatedDTO
{
    public required string title { get; set; }
    public string? description { get; set; }
    public string? text { get; set; }
    public int? status_id { get; set; }
}
