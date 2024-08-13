using Microsoft.AspNetCore.Http;

namespace Entities.DTO.UserProfilDTOS;

public class UserProfilUpdatedDTO
{
    public string login { get; set; }
    public string password { get; set; }
    public string oldPassword { get; set; }
    public PersonUserProfilUpdatedDTO? person_ { get; set; }
    public IFormFile? img_up { get; set; }
}
