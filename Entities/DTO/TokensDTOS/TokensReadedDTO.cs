using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;

namespace Entities.DTO.TokensDTOS;

public class TokensReadedDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public string token { get; set; }
    public StatusConfReadedDTO? status_ { get; set; }
}
