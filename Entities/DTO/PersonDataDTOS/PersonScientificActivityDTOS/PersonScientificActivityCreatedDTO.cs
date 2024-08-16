namespace Entities.DTO.PersonDataDTOS.PersonScientificActivityDTOS;

public class PersonScientificActivityCreatedDTO
{
    public required int since_when { get; set; }
    public int? until_when { get; set; }
    public required string whom { get; set; }
    public required string where { get; set; }
}
