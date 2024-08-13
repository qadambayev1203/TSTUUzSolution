namespace Entities.DTO.PersonDTOS;

public class PersonUpdatedDataDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fathers_name { get; set; }
    public string? email { get; set; }
    public int gender_id { get; set; }
    public string? pinfl { get; set; }
    public string? passport_text { get; set; }
    public string? passport_number { get; set; }
    public required int departament_id { get; set; }
    public required int employee_type_id { get; set; }
}
