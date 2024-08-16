namespace Entities.DTO.PersonDataDTOS.PersonScientificActivityDTOS;

public class PersonScientificActivityCreatedAdminDTO
{
    public required int since_when { get; set; }
    public int? until_when { get; set; }
    public required string whom { get; set; }
    public required string where { get; set; }
    public required int person_data_id { get; set; }
}
