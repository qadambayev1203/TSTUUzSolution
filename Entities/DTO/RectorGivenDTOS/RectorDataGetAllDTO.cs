using Entities.DTO.PersonDTOS;

namespace Entities.DTO.RectorGivenDTOS;

public class RectorDataGetAllDTO
{
    public int id { get; set; }
    public PersonRectorConfReadedDTOAll? persons_ { get; set; }
}
