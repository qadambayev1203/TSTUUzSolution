namespace Entities.DTO;

public class UserAuthInfoDTO
{
    public UserDTO UserDetails { get; set; }
    public string Token { get; set; }
    public string OAuth2Token { get; set; }
}

