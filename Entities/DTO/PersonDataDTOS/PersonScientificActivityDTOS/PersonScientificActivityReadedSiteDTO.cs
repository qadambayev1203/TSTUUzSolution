namespace Entities.DTO.PersonDataDTOS.PersonScientificActivityDTOS;

public class PersonScientificActivityReadedSiteDTO
{
    public int id { get; set; }
    public int? since_when { get; set; }
    public int? until_when { get; set; }
    public string? whom { get; set; }
    public string? where { get; set; }
    public int? person_data_id { get; set; }
}
