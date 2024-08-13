namespace Entities.DTO.UserCrudDTOS;

public class UserCrudUpdatedDTO
{
    public required string login { get; set; }
    public required string password { get; set; }
    public string email { get; set; }
    public required int user_type_id { get; set; }
    public required int person_id { get; set; }
    public required int status_id { get; set; }
    public bool removed { get; set; }
    public bool active { get; set; }
}
